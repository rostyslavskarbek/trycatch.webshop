using System.Xml.Linq;

namespace TryCatch.XmlDal
{
    public abstract class EntityXmlRepository<T> : XmlRepositoryBase<T>
    {
        private XElement _parentElement;

        protected EntityXmlRepository(XName entityName)
            : base(entityName)
        {
        }

        public override XElement ParentElement
        {
            get
            {
                return _parentElement ?? (_parentElement = GetParentElement());
            }
            protected set
            {
                _parentElement = value;
            }
        }

        /// <summary>
        /// Gets the parent element for this node type
        /// </summary>
        protected abstract XElement GetParentElement();
    }
}
