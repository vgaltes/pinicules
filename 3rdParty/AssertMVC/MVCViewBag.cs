using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace AssertMVC
{
    public class MVCViewBag
    {
        ViewDataDictionary viewData;

        public MVCViewBag(ViewDataDictionary viewData)
        {
            this.viewData = viewData;
        }

        public void WithPropertyEqualsTo(string propertyName, object value)
        {
            Assert.AreEqual(value, viewData[propertyName]);
        }
    }
}
