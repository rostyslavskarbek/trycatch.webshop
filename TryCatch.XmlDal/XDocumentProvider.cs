using System;
using System.IO;
using System.Xml.Linq;

namespace TryCatch.XmlDal
{
    public abstract class XDocumentProvider
    {
        private static bool _pendingChanges;

        private bool _documentLoadedFromFile;

        readonly FileSystemWatcher _fileWatcher;

        public event EventHandler CurrentDocumentChanged;

        private XDocument _loadedDocument;

        public string FilePath { get; set; }

        protected XDocumentProvider()
        {
            _fileWatcher = new FileSystemWatcher { NotifyFilter = NotifyFilters.LastWrite };
            _fileWatcher.Changed += fileWatcher_Changed;
        }

        void fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (_documentLoadedFromFile && !_pendingChanges)
            {
                GetDocument(true);
            }
        }

        public XDocument GetDocument(bool refresh = false)
        {
            if (refresh || _loadedDocument == null)
            {
                if (File.Exists(FilePath))
                {
                    _loadedDocument = XDocument.Load(FilePath);
                    _documentLoadedFromFile = true;

                    if (_fileWatcher.Path != Environment.CurrentDirectory)
                    {
                        _fileWatcher.Path = Environment.CurrentDirectory;
                        _fileWatcher.Filter = FilePath;
                        _fileWatcher.EnableRaisingEvents = true;
                    }
                }
                else
                {
                    throw new FileNotFoundException(string.Format("XML file {0} is not found", FilePath));
                }

                if (CurrentDocumentChanged != null) CurrentDocumentChanged(this, EventArgs.Empty);
            }

            return _loadedDocument;
        }

        /// <summary>
        /// Creates a new XDocument with a determined schemma.
        /// </summary>
        public abstract XDocument CreateNewDocument();

        public void Save()
        {
            if (_loadedDocument == null)
                throw new InvalidOperationException();

            try
            {
                // tells the file watcher that he cannot raise the changed event, because his function is to capture external changes.
                _pendingChanges = true;
                _loadedDocument.Save(FilePath);
            }
            finally
            {
                _pendingChanges = false;
            }
        }
    }
}
