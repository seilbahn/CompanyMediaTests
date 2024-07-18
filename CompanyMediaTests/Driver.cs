using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using CompanyMediaTests.Utility;

namespace CompanyMediaTests
{
    /// <summary>
    /// The class Driver is designed to implement added functionality
    /// to IWebDriver interface.<br/>
    /// At this moment there are these features:<br/>
    /// 1) Logging via the class Beaver;<br/>
    /// 2) Waitings for a web element.<br/>
    /// For tests it's better to use this class,
    /// for the classes that implement PageObject pattern
    /// it's recommend to use the basic IWebDriver interface.<br/>
    /// If there is no needed feature, the one may be implemented here,
    /// or via creating a new one class.
    /// </summary>
    internal class Driver : EventFiringWebDriver
    {
        /// <summary>
        /// The reference to the Beaver class instance.<br/>
        /// By default the log file is stored in the test project
        /// folder in My Documents.
        /// </summary>
        public Beaver Logger { get; set; }

        /// <summary>
        /// The constructor initializes a new instance of the class Driver.<br/>
        /// </summary>
        /// <param name="driver">
        /// The reference to the instance of the class that implements the interface IWebDriver.
        /// </param>
        public Driver(IWebDriver driver) : base(driver)
        {
            Navigating += new EventHandler<WebDriverNavigationEventArgs>(Driver_Navigating);
            Navigated += new EventHandler<WebDriverNavigationEventArgs>(Driver_Navigated);
            NavigatingBack += new EventHandler<WebDriverNavigationEventArgs>(Driver_NavigatingBack);
            NavigatedBack += new EventHandler<WebDriverNavigationEventArgs>(Driver_NavigatedBack);
            NavigatingForward += new EventHandler<WebDriverNavigationEventArgs>(Driver_NavigatingForward);
            NavigatedForward += new EventHandler<WebDriverNavigationEventArgs>(Driver_NavigatedForward);
            ElementClicking += new EventHandler<WebElementEventArgs>(Driver_ElementClicking);
            ElementClicked += new EventHandler<WebElementEventArgs>(Driver_ElementClicked);
            ElementValueChanging += new EventHandler<WebElementValueEventArgs>(Driver_ElementValueChanging);
            ElementValueChanged += new EventHandler<WebElementValueEventArgs>(Driver_ElementValueChanged);
            FindingElement += new EventHandler<FindElementEventArgs>(Driver_FindingElement);
            FindElementCompleted += new EventHandler<FindElementEventArgs>(Driver_FindElementCompleted);
            GettingShadowRoot += new EventHandler<GetShadowRootEventArgs>(Driver_GettingShadowRoot);
            GetShadowRootCompleted += new EventHandler<GetShadowRootEventArgs>(Driver_GetShadowRootCompleted);
            ScriptExecuting += new EventHandler<WebDriverScriptEventArgs>(Driver_ScriptExecuting);
            ScriptExecuted += new EventHandler<WebDriverScriptEventArgs>(Driver_ScriptExecuted);
            ExceptionThrown += new EventHandler<WebDriverExceptionEventArgs>(Driver_ExceptionThrown);
            Logger = new Beaver(Path.Combine(Options.LogsDirectoryPath, Helper.RandomString(new Random(), 3)).ToString());
        }

        /// <summary>
        /// The constructor initializes a new instance of the class Driver.<br/>
        /// </summary>
        /// <param name="driver">
        /// The reference to the instance of the class that implements the interface IWebDriver.
        /// </param>
        /// <param name="logger">
        /// The reference to the instance of the class Beaver.
        /// </param>
        public Driver(IWebDriver driver, Beaver logger) : this(driver)
        {  
            Logger = logger;
        }

        /// <summary>
        /// The method WaitDocumentReadyState creates a maximum delay of 10 seconds
        /// until the script document.readyState is executed.
        /// </summary>
        public void WaitDocumentReadyState()
        {
            _ = Manage().Timeouts().ImplicitWait;
            WebDriverWait wait = new WebDriverWait(this, TimeSpan.FromSeconds(10));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        /// <summary>
        /// The method IsElementPresent checks if there is a specified web element on the web page or not.
        /// </summary>
        /// <param name="localor">The locator of the searched web element.</param>
        /// <returns>
        /// True - if the specified web element is present on the web page.<br/>
        /// False - if the specified web element is absent on the web page.
        /// </returns>
        /// <exception cref="NoSuchElementException">
        /// If the specified web element is absent on the web page then
        /// the method throws the exception NoSuchElementException
        /// and logs the exception NoSuchElementException with the status Error.<br/>
        /// </exception>
        public bool IsElementPresent(By localor)
        {
            try
            {
                IWebElement webElement = this.FindElement(localor, true);
                return webElement.Displayed && webElement.Enabled;
            }
            catch (NoSuchElementException nse)
            {
                Logger.Logger.Error($"The web element {localor} was not found. {nse.Message}");
                throw new NoSuchElementException(nse.Message);
            }            
        }
        
        private void Driver_Navigating(object? sender, WebDriverNavigationEventArgs e)
        {
            Logger.Logger.Information($"Navigating to {e.Url}");
        }

        private void Driver_Navigated(object? sender, WebDriverNavigationEventArgs e)
        {
            Logger.Logger.Information($"Navigated to {e.Url}");
        }

        private void Driver_NavigatingBack(object? sender, WebDriverNavigationEventArgs e)
        {
            Logger.Logger.Information($"Navigating back to {e.Url}");
        }

        private void Driver_NavigatedBack(object? sender, WebDriverNavigationEventArgs e)
        {
            Logger.Logger.Information($"Navigated back to {e.Url}");
        }

        private void Driver_NavigatingForward(object? sender, WebDriverNavigationEventArgs e)
        {
            Logger.Logger.Information($"Navigating forward to {e.Url}");
        }

        private void Driver_NavigatedForward(object? sender, WebDriverNavigationEventArgs e)
        {
            Logger.Logger.Information($"Navigated forward to {e.Url}");
        }

        private void Driver_ElementClicking(object? sender, WebElementEventArgs e)
        {
            Logger.Logger.Information($"Clicking on the element {e.Element.TagName} {e.Element.Text}");
        }

        private void Driver_ElementClicked(object? sender, WebElementEventArgs e)
        {
            Logger.Logger.Information($"Clicked on the element {e}");
        }

        private void Driver_ElementValueChanging(object? sender, WebElementValueEventArgs e)
        {
            Logger.Logger.Information($"Element {e.Element.TagName} {e.Element.Text} value changing. Expecting value: {e.Value}");
        }

        private void Driver_ElementValueChanged(object? sender, WebElementValueEventArgs e)
        {
            Logger.Logger.Information($"Element {e.Element.TagName} {e.Element.Text} value changed. New value: {e.Value}");
        }

        private void Driver_FindingElement(object? sender, FindElementEventArgs e)
        {
            Logger.Logger.Information($"Finding element: {e.FindMethod} {e.Element}");
        }

        private void Driver_FindElementCompleted(object? sender, FindElementEventArgs e)
        {
            Logger.Logger.Information($"Find element completed: {e.FindMethod} {e.Element}");
        }

        private void Driver_GettingShadowRoot(object? sender, GetShadowRootEventArgs e)
        {
            Logger.Logger.Information($"Getting shadow root. {e.SearchContext}");
        }

        private void Driver_GetShadowRootCompleted(object? sender, GetShadowRootEventArgs e)
        {
            Logger.Logger.Information($"Get shadow root completed. {e.SearchContext}");
        }

        private void Driver_ScriptExecuting(object? sender, WebDriverScriptEventArgs e)
        {
            Logger.Logger.Information($"Script executing: {e.Script}");
        }

        private void Driver_ScriptExecuted(object? sender, WebDriverScriptEventArgs e)
        {
            Logger.Logger.Information($"Script executed: {e.Script}");
        }

        private void Driver_ExceptionThrown(object? sender, WebDriverExceptionEventArgs e)
        {
            Logger.Logger.Error($"Message: {e.ThrownException.Message}\nStack trace:\n{e.ThrownException.StackTrace}");
        }
    }
}