using System;
using System.IO;
using System.Xml.Linq;

namespace TryCatch.XmlDal
{
    class ArticlesXDocumentProvider : XDocumentProvider
    {
        internal ArticlesXDocumentProvider()
        {
            const string fileName = "Articles.xml";
            var dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            FilePath = Path.Combine(dataDirectory, fileName);
        }

        public override XDocument CreateNewDocument()
        {
            throw new NotImplementedException();
        }
    }
}
