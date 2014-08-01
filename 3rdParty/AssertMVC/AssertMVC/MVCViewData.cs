using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace AssertMVC
{
    public class MVCViewData
    {
        ViewDataDictionary viewData;

        public MVCViewData(ViewDataDictionary viewData)
        {
            this.viewData = viewData;
        }

        public void WithPropertyEqualsTo(string propertyName, object value)
        {
            Assert.AreEqual(value, viewData[propertyName]);
        }
    }
}
