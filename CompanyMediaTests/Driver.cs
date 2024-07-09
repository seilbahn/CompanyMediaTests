using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace CompanyMediaTests
{
    internal class Driver : EventFiringWebDriver
    {
        public Beaver Log { get; set; }

        public Driver(IWebDriver parentDriver, Beaver logger) : base(parentDriver)
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

            Log = logger;
        }

        public void WaitDocumentReadyState()
        {
            _ = Manage().Timeouts().ImplicitWait;
            WebDriverWait wait = new WebDriverWait(this, TimeSpan.FromSeconds(10));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        private void Driver_Navigating(object? sender, WebDriverNavigationEventArgs e)
        {
            Log.Logger.Information($"Navigating to {e.Url}");
        }

        private void Driver_Navigated(object? sender, WebDriverNavigationEventArgs e)
        {
            Log.Logger.Information($"Navigated to {e.Url}");
        }

        private void Driver_NavigatingBack(object? sender, WebDriverNavigationEventArgs e)
        {
            Log.Logger.Information($"Navigating back to {e.Url}");
        }

        private void Driver_NavigatedBack(object? sender, WebDriverNavigationEventArgs e)
        {
            Log.Logger.Information($"Navigated back to {e.Url}");
        }

        private void Driver_NavigatingForward(object? sender, WebDriverNavigationEventArgs e)
        {
            Log.Logger.Information($"Navigating forward to {e.Url}");
        }

        private void Driver_NavigatedForward(object? sender, WebDriverNavigationEventArgs e)
        {
            Log.Logger.Information($"Navigated forward to {e.Url}");
        }

        private void Driver_ElementClicking(object? sender, WebElementEventArgs e)
        {
            Log.Logger.Information($"Clicking on the element {e.Element.TagName} {e.Element.Text}");
        }

        private void Driver_ElementClicked(object? sender, WebElementEventArgs e)
        {
            Log.Logger.Information($"Clicked on the element {e}");
        }

        private void Driver_ElementValueChanging(object? sender, WebElementValueEventArgs e)
        {
            Log.Logger.Information($"Element {e.Element.TagName} {e.Element.Text} value changing. Expecting value: {e.Value}");
        }

        private void Driver_ElementValueChanged(object? sender, WebElementValueEventArgs e)
        {
            Log.Logger.Information($"Element {e.Element.TagName} {e.Element.Text} value changed. New value: {e.Value}");
        }

        private void Driver_FindingElement(object? sender, FindElementEventArgs e)
        {
            Log.Logger.Information($"Finding element: {e.FindMethod} {e.Element}");
        }

        private void Driver_FindElementCompleted(object? sender, FindElementEventArgs e)
        {
            Log.Logger.Information($"Find element completed: {e.FindMethod} {e.Element}");
        }

        private void Driver_GettingShadowRoot(object? sender, GetShadowRootEventArgs e)
        {
            Log.Logger.Information($"Getting shadow root. {e.SearchContext}");
        }

        private void Driver_GetShadowRootCompleted(object? sender, GetShadowRootEventArgs e)
        {
            Log.Logger.Information($"Get shadow root completed. {e.SearchContext}");
        }

        private void Driver_ScriptExecuting(object? sender, WebDriverScriptEventArgs e)
        {
            Log.Logger.Information($"Script executing: {e.Script}");
        }

        private void Driver_ScriptExecuted(object? sender, WebDriverScriptEventArgs e)
        {
            Log.Logger.Information($"Script executed: {e.Script}");
        }

        private void Driver_ExceptionThrown(object? sender, WebDriverExceptionEventArgs e)
        {
            Log.Logger.Error($"Message: {e.ThrownException.Message}\nStack trace:\n{e.ThrownException.StackTrace}");
        }
    }
}