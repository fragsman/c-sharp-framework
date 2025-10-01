using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.POM
{
    public class ProductDetailPage : BasePage
    {
        private readonly By addToCartBtn = By.Name("add-to-cart");

        public ProductDetailPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickAddToCartButton()
        {
            HeaderBar headerBar = new HeaderBar(driver);
            int prevItemsInCart = headerBar.GetCurrentItemsInCart();
            Interactor.ClickElement(driver, addToCartBtn);
            int currentItemsInCart = headerBar.GetCurrentItemsInCart();
            int retry = 0;
            //waits for the number to be updated (the page takes a while to update the cart number)
            while (prevItemsInCart == currentItemsInCart && retry <= 10)
            {
                try
                {
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    Logger.Error(e.ToString());
                }
                currentItemsInCart = headerBar.GetCurrentItemsInCart();
                retry++;
            }
        }
    }
}
