using AssertMVC.Tests.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace AssertMVC.Tests
{
    [TestClass]
    public class MVCViewResultTest
    {
        TestController controller = new TestController();

        [TestMethod]
        public void TestViewHasName()
        {
            string viewName = "TestViewName";
         
            var result = controller.IndexView(viewName);

            result.ShouldBe<ViewResult>().WithName(viewName);
        }

        [TestMethod]
        public void TestViewHasNameWithFunctionComparision()
        {
            string viewName = "TestViewName";

            var result = controller.IndexView(viewName);

            result.ShouldBe<ViewResult>().WithName(n => n == viewName);
        }

        [TestMethod]
        public void TestPartialViewHasName()
        {
            string viewName = "TestPartialViewName";

            var result = controller.IndexPartialView(viewName);

            result.ShouldBe<PartialViewResult>().WithName(viewName);
        }


        [TestMethod]
        public void TestIsDefault()
        {
            var result = controller.DefaultView();

            result.ShouldBe<ViewResult>().Default();
        }

        [TestMethod]
        public void TestPartialViewIsDefault()
        {
            var result = controller.DefaultPartialView();

            result.ShouldBe<PartialViewResult>().Default();
        }

        [TestMethod]
        public void TestWithLayout()
        {
            var layoutName = "_layoutName";
            var viewName = "TestViewName";

            var result = controller.ViewWithLayout(viewName, layoutName);

            result.ShouldBe<ViewResult>().WithLayout(layoutName);
        }

        [TestMethod]
        public void TestWithLayoutWithFunctionComparision()
        {
            var layoutName = "_layoutName";
            var viewName = "TestViewName";

            var result = controller.ViewWithLayout(viewName, layoutName);

            result.ShouldBe<ViewResult>().WithLayout(l => l == layoutName);
        }

        [TestMethod]
        public void TestWithModel()
        {
            var result = controller.ViewWithModel();

            result.ShouldBe<ViewResult>().WithModel();
        }

        [TestMethod]
        public void TestPartialViewWithModel()
        {
            var result = controller.PartialViewWithModel();

            result.ShouldBe<PartialViewResult>().WithModel();
        }

        [TestMethod]
        public void TestWithModelOfType()
        {
            var model = 1;

            var result = controller.ViewWithModel(model);

            result.ShouldBe<ViewResult>().WithModel().OfType<int>();
        }

        [TestMethod]
        public void TestWithViewBagProperty()
        {
            string propertyName = "propertyName";
            string value = "value";
            var result = controller.ViewWithViewBag(propertyName, value);

            result.ShouldBe<ViewResult>().WithViewBag();
        }

        [TestMethod]
        public void TestWithViewBagPropertyValue()
        {
            string propertyName = "propertyName";
            string value = "value";
            var result = controller.ViewWithViewBag(propertyName, value);

            result.ShouldBe<ViewResult>().WithViewBag().WithPropertyEqualsTo(propertyName, value);
        }

        [TestMethod]
        public void TestWithViewDataProperty()
        {
            string propertyName = "propertyName";
            string value = "value";
            var result = controller.ViewWithViewData(propertyName, value);

            result.ShouldBe<ViewResult>().WithViewData();
        }

        [TestMethod]
        public void TestWithViewDataPropertyValue()
        {
            string propertyName = "propertyName";
            string value = "value";
            var result = controller.ViewWithViewData(propertyName, value);

            result.ShouldBe<ViewResult>().WithViewData().WithPropertyEqualsTo(propertyName, value);
        }
    }
}
