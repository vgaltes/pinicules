using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssertMVC
{
    public class MVCModel
    {
        object model = null;

        public MVCModel(object model)
        {
            this.model = model;
        }

        public T OfType<T>()
        {
            Assert.IsInstanceOfType(model, typeof(T));
            return (T)model;
        }
    }
}
