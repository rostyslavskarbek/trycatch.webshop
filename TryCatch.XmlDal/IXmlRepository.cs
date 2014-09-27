using System.Collections.Generic;

namespace TryCatch.XmlDal
{
    public interface IXmlRepository <T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
    }
}
