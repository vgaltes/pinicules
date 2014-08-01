using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace AssertMVC
{
    public static class MVCViewResult
    {
        public static void WithLayout(this ViewResult result, string layoutName)
        {
            Assert.AreEqual(layoutName, result.MasterName);
        }

        public static void WithLayout(this ViewResult result, Func<string, bool> evalutationFunction)
        {
            Assert.IsTrue(evalutationFunction(result.MasterName));
        }
    }
}