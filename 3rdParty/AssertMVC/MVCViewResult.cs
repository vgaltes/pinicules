using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace AssertMVC
{
    public static class MVCViewResult
    {
        public static void WithLayout(this ViewResult result, string layoutName)
        {
            Assert.AreEqual(layoutName, result.MasterName);
        }
    }
}