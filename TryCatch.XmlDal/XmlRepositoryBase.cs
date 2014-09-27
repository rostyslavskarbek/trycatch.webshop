using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TryCatch.XmlDal
{
    public abstract class XmlRepositoryBase<T> : IXmlRepository<T>
    {
        protected XDocumentProvider DocumentProvider;
        
        public virtual XElement ParentElement { get; protected set; }

        protected XmlRepositoryBase(XName elementName)
        {
            ElementName = elementName;
            DocumentProvider = new ArticlesXDocumentProvider();
            DocumentProvider.CurrentDocumentChanged += (sender, eventArgs) => ParentElement = null;
        }

        public IEnumerable<T> GetAll()
        {
            return ParentElement.Elements(ElementName).Select(Selector);
        }

        public abstract T GetById(string id);
        
        protected XName ElementName { get; private set; }

        protected abstract Func<XElement, T> Selector { get; }
    }
}


