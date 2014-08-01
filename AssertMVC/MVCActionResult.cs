using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace AssertMVC
{
    public static class MVCActionResult
    {
        public static T ShouldBe<T>(this ActionResult result) where T : ActionResult
        {
            var viewResult = result as T;
            Assert.IsNotNull(viewResult);
            return viewResult;
        }
    }
}