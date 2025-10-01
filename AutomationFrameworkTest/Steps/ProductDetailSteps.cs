using AutomationFrameworkTest.Support;
using Reqnroll;
using AutomationFramework.POM;

namespace AutomationFrameworkTest.Steps
{
    [Binding]
    public class ProductDetailSteps : BaseStep
    {
        public ProductDetailSteps(MyHooks myHooks) : base(myHooks)
        {
        }

        [Given("user adds the product to the cart")]
        public void GivenUserAddsTheProductToTheCart()
        {
            ProductDetailPage productDetailPage = new ProductDetailPage(GetDriver());
            productDetailPage.ClickAddToCartButton();
        }

    }
}
