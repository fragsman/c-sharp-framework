using AutomationFramework.POCO;
using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.POM
{
    public class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            WaitForBlockingOverlays();
        }

        private readonly By firstNameInput = By.CssSelector("#billing_first_name");
        private readonly By lastNameInput = By.CssSelector("#billing_last_name");
        private readonly By addressLine1Input = By.Name("billing_address_1");
        private readonly By cityInput = By.Name("billing_city");
        private readonly By postalCodeInput = By.Name("billing_postcode");
        private readonly By emailInput = By.Name("billing_email");
        private readonly By placeOrderBtn = By.CssSelector("#place_order");
        private readonly By countrySelect = By.CssSelector("span.select2-selection span");
        private readonly By countrySelectResults = By.CssSelector("span.select2-results");
        private readonly By stateSelect = By.Id("select2-billing_state-container");

        public void SetBillingAddress(BillingAddress ba)
        {
            EnterFirstName(ba.firstName);
            EnterLastName(ba.lastName);
            EnterCountry(ba.country);
            EnterAddressLine1(ba.addressLineOne);
            EnterCity(ba.city);
            EnterState(ba.state);
            EnterPostalCode(ba.postalCode);
            EnterEmail(ba.email);
        }

        public void EnterFirstName(string firstName)
        {
            Interactor.FindElement(driver, firstNameInput).SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            Interactor.FindElement(driver, lastNameInput).SendKeys(lastName);
        }

        public void EnterAddressLine1(string addressLine1)
        {
            Interactor.FindElement(driver, addressLine1Input).SendKeys(addressLine1);
            WaitForBlockingOverlays();
        }

        public void EnterCity(string city)
        {
            Interactor.FindElement(driver, cityInput).SendKeys(city);
            WaitForBlockingOverlays();
        }

        public void EnterPostalCode(string postalCode)
        {
            Interactor.FindElement(driver, postalCodeInput).SendKeys(postalCode);
            WaitForBlockingOverlays();
        }

        public void EnterEmail(string email)
        {
            Interactor.FindElement(driver, emailInput).SendKeys(email);
        }

        public void PlaceOrder()
        {
            Interactor.ClickElement(driver, placeOrderBtn);
        }

        public void EnterCountry(string country)
        {
            Interactor.SelectOption(driver, countrySelect, country);
            WaitForBlockingOverlays();
        }

        public void EnterState(string stateText)
        {
            Interactor.SelectOption(driver, stateSelect, stateText);
            WaitForBlockingOverlays();
        }

        public void SelectNthCountry(int countryPosition)
        {
            Interactor.ClickElement(driver, countrySelect);
            IWebElement selectCountryResults = Interactor.FindElement(driver, countrySelectResults);
            Interactor.SelectNthElement(selectCountryResults, countryPosition);
        }

        public string GetCurrentSelectedCountry()
        {
            return Interactor.GetElementText(driver, countrySelect);
        }
    }
}
