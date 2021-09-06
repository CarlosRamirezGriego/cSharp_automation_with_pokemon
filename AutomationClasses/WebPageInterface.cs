using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using static AutomationClasses.AutomationOptions;

namespace PageObjects
{
    public class WebPageAbstract
    {
        public IWebDriver testDriver { get; set; }
        public int explicitWait { get; private set; } = 10;
        public const int defaultExplicit = 10;
        public int milisecondsInterval { get; private set; } = 10;
        public ElementAbstract testElement = new ElementAbstract();
        public bool isSeleniumGrid { get; private set; } = false;
        public bool HighLightElements = false;
        public TestBrowser testBrowser;

        public WebPageAbstract()
        {
        }

        public WebPageAbstract(TestBrowser testBrowser, string url)
        {
            OpenBrowser(testBrowser, url);
        }

        public WebPageAbstract(IWebDriver driver)
        {
            testDriver = driver;
        }

        public WebPageAbstract(TestBrowser testBrowser)
        {
            OpenBrowser(testBrowser);
        }

        public void OpenBrowser(TestBrowser testBrowser)
        {
            this.testBrowser = testBrowser;
            if (this.testBrowser == TestBrowser.CHROME)
            {
                testDriver = new ChromeDriver();
                isSeleniumGrid = false;
            }
            else
            {
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                service.Host = "::1";
                testDriver = new FirefoxDriver(service);
                isSeleniumGrid = false;
            }
        }



        public void OpenBrowser(TestBrowser testBrowser, string url)
        {
            this.testBrowser = testBrowser;
            if (this.testBrowser == TestBrowser.CHROME)
            {
                isSeleniumGrid = true;
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.PlatformName = "LINUX";
                testDriver = new RemoteWebDriver(new Uri(url), chromeOptions);
            }
            else
            {
                isSeleniumGrid = true;
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                firefoxOptions.PlatformName = "LINUX";
                testDriver = new RemoteWebDriver(new Uri(url), firefoxOptions);
            }
        }

        public void UpdateSearchInterval(int i)
        {
            if (i > 0 && i <= 100)
            {
                milisecondsInterval = i;
            }
        }

        public void LoadWebPage(string url)
        {
            testDriver.Navigate().GoToUrl(url);
        }

        public void MaximizeWindow()
        {
            testDriver.Manage().Window.Maximize();
        }

        public string ReturnWebPageTitle()
        {
            return testDriver.Title;
        }

        public string ReturnPageURL()
        {
            return testDriver.Url;
        }

        public string ReturnPageSourceCode()
        {
            return testDriver.PageSource;
        }

        public void CloseBrowser()
        {
            if (isSeleniumGrid)
            {
                testDriver.Quit();
            }
            else
            {
                testDriver.Close();
            }
        }


        public void MinimizeWindow()
        {
            testDriver.Manage().Window.Minimize();
        }


        public void RefreshBrowser()
        {
            testDriver.Navigate().Refresh();
        }


        public void UpdateExplicitWait(int seconds)
        {
            explicitWait = seconds;
        }


        public void HighLightAllTheElementsThatMatch(ElementAbstract we)
        {
            List<IWebElement> sourceElements = new List<IWebElement>();
            IJavaScriptExecutor js = (IJavaScriptExecutor)testDriver;
            foreach (IWebElement iwe in we.allMatchingResults)
            {
                js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", iwe, "color: yellow;  border: 2px solid yellow;");
                if (iwe.GetAttribute("style") != null)
                {
                    Thread.Sleep(250);
                }
            }
            foreach (IWebElement iwe in we.allMatchingResults)
            {
                js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", iwe, "");
            }
        }


        #region Page Objects Search

        public ElementAbstract SearchElementWithThisText(string text)
        {
            ElementAbstract match = new ElementAbstract();
            IReadOnlyList<IWebElement> listMatches = testDriver.FindElements(By.XPath("//*[text()='"+text+"']"));
            foreach (IWebElement iwe in listMatches)
            {
                if (iwe.Displayed)
                {
                    match.allMatchingResults.Add(iwe);
                }
            }
            match.CountMatchingElements();
            return match;
        }

        public ElementAbstract SearchForTheseSelectorsData(ElementAbstract we)
        {
            if (we.expectedMatches == ExpectedMatchingElements.ONE)
            {
                return ThisElementShouldHaveOneMatch(we);
            }
            else if (we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                return ThisElementShouldHaveMultipleMatches(we);
            }
            else
            {
                return ThisElementShouldHaveNoMatch(we);
            }
        }

        public bool IsThisElementPresent(ElementAbstract we)
        {
            we.ResetElement();
            if (we.expectedMatches == ExpectedMatchingElements.ONE)
            {
                if (we.isSlowElement)
                {
                    Thread.Sleep(500);
                    this.explicitWait = 30;
                }
                List<IWebElement> matchingResults = SearchLoop(ExpectedMatchingElements.ONE, we.selectorMethod, we.selector);
                ThisElementShouldBeVisible(we);
                int amountElements = matchingResults.Count;
                if (amountElements == 1)
                {
                    if (ValidateElementsAreVisible(matchingResults))
                    {
                        we.allMatchingResults = matchingResults;
                        we.CountMatchingElements();
                        we.hasBeenSearched = true;
                        if (HighLightElements)
                        {
                            HighLightAllTheElementsThatMatch(we);
                        }
                        this.explicitWait = defaultExplicit;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new InvalidOperationException("The Element with selector Method " + we.selectorMethod.ToString() + " and Search String \"" + we.selector + "\" returned " + amountElements.ToString() + " elements. We expected only one");
                }
            }
            else
            {
                throw new InvalidOperationException("The Method only work with Elements that expect ONE matching result");
            }
        }

        //This looks for a Child Element search results in side a Parent Element, by default in the Element 1 of the Parent
        public ElementAbstract SearchForTheseSelectorsData(ElementAbstract parent, ElementAbstract child)
        {
            if (!parent.hasBeenSearched)
            {
                parent = SearchForTheseSelectorsData(parent);
            }
            if (parent.amountElements > 1 || parent.amountElements == 1)
            {
                IWebElement parentIWE = parent.ReturnTheIWebElementInPosition(1);
                if (child.expectedMatches == ExpectedMatchingElements.ONE)
                {
                    return ThisElementShouldHaveOneMatch(child, parentIWE);
                }
                else if (child.expectedMatches == ExpectedMatchingElements.MANY)
                {
                    return ThisElementShouldHaveMultipleMatches(child, parentIWE);
                }
                else
                {
                    return ThisElementShouldHaveNoMatch(child, parentIWE);
                }
            }
            else
            {
                throw new InvalidOperationException("The Parent Element with selector Method " + parent.selectorMethod.ToString() + " and Search String \"" + parent.selector + "\" had Zero matches");
            }
        }

        //This looks for a Child Element search results in side a Parent Element, in the Element that the user specifies from the Parent
        public ElementAbstract SearchForTheseSelectorsData(ElementAbstract parent, ElementAbstract child, int positionIWE)
        {
            if (!parent.hasBeenSearched)
            {
                parent = SearchForTheseSelectorsData(parent);
            }
            if (positionIWE > 0 && positionIWE <= parent.amountElements)
            {
                if (parent.amountElements > 1 || parent.amountElements == 1)
                {
                    IWebElement parentIWE = parent.ReturnTheIWebElementInPosition(positionIWE);
                    if (child.expectedMatches == ExpectedMatchingElements.ONE)
                    {
                        return ThisElementShouldHaveOneMatch(child, parentIWE);
                    }
                    else if (child.expectedMatches == ExpectedMatchingElements.MANY)
                    {
                        return ThisElementShouldHaveMultipleMatches(child, parentIWE);
                    }
                    else
                    {
                        return ThisElementShouldHaveNoMatch(child, parentIWE);
                    }
                }
                else
                {
                    throw new InvalidOperationException("The Parent Element with selector Method " + parent.selectorMethod.ToString() + " and Search String \"" + parent.selector + "\" had Zero matches");
                }
            }
            else
            {
                throw new InvalidOperationException("The Parent Element with selector Method " + parent.selectorMethod.ToString() + " and Search String \"" + parent.selector + "\" had only " + parent.amountElements.ToString() + " elements");
            }

        }

        #endregion

        #region Page Object Actions

        #region Click Elements
        public void ClickThisElement(ElementAbstract we)
        {
            if (we.expectedMatches == ExpectedMatchingElements.NONE || we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \""
                + we.selector + "\" is currently expecting No or Multiple matches, this function only works with elements that expect one match");
            }
            else
            {
                if (we.hasBeenSearched)
                {
                    IWebElement result = we.ReturnTheIWebElementInPosition(1);
                    if (we.needsScrolling)
                    {
                        ScrollToThisElement(we);
                    }
                    if (we.isSlowElement)
                    { Thread.Sleep(200); }
                    ActualClickAction(result);
                }
                else
                {
                    SearchForTheseSelectorsData(we);
                    IWebElement result = we.ReturnTheIWebElementInPosition(1);
                    if (we.needsScrolling)
                    {
                        ScrollToThisElement(we);
                    }
                    if (we.isSlowElement)
                    { Thread.Sleep(200); }
                    ActualClickAction(result);
                }
            }
        }

        public void ClickElementFromListByIndex(ElementAbstract we, int index)
        {
            if (we.hasBeenSearched)
            {
                if (we.amountElements >= index && we.amountElements > 0)
                {
                    if (we.needsScrolling)
                    {
                        ScrollToThisElement(we);
                    }
                    if (we.isSlowElement)
                    { Thread.Sleep(200); }
                    IWebElement result = we.ReturnTheIWebElementInPosition(index);
                    ActualClickAction(result);
                }
                else
                {
                    throw new InvalidOperationException("Click Index provided is out of range from the actual available elements");
                }
            }
            else
            {
                SearchForTheseSelectorsData(we);
                if (we.amountElements >= index && we.amountElements > 0)
                {
                    if (we.needsScrolling)
                    {
                        ScrollToThisElement(we);
                    }
                    if (we.isSlowElement)
                    { Thread.Sleep(200); }
                    IWebElement result = we.ReturnTheIWebElementInPosition(index);
                    ActualClickAction(result);
                }
                else
                {
                    throw new InvalidOperationException("Click Index provided is out of range from the actual available elements");
                }
            }

        }

        private void ActualClickAction(IWebElement iwe)
        {
            Actions actions = new Actions(testDriver);
            actions.Click(iwe);
            actions.Perform();
        }

        #endregion

        #region EnterText in Element

        public void EnterTextInThisElement(ElementAbstract we, string text)
        {
            if (we.expectedMatches == ExpectedMatchingElements.NONE || we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \""
                + we.selector + "\" is currently expecting No or Multiple matches, this function only works with elements that expect one match");
            }
            else
            {
                int cycles = (explicitWait * 1000) / milisecondsInterval / 2;
                int counter = 0;
                bool mainCheck = false;
                while (counter <= cycles)
                {
                    ThisElementShouldExistRegardlessVisibility(we);
                    List<IWebElement> result = we.allMatchingResults;
                    bool isVisible = ValidateElementsAreVisible(result);
                    bool isEnabled = ValidateElementsAreEnabled(result);
                    {
                        if (isVisible && isEnabled)
                        {
                            mainCheck = true;
                            break;
                        }
                    }
                    counter = counter + 1;
                }
                if (mainCheck)
                {
                    IWebElement result = we.ReturnTheIWebElementInPosition(1);
                    if (we.needsScrolling)
                    {
                        ScrollToThisElement(we);
                    }
                    ActualEnterTextAction(result, text);
                }
                else
                {
                    throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \"" + we.selector + "\" was never set to visible State");
                }
            }
        }

        public void PressBackSpaceInThisElement(ElementAbstract we, int times)
        {
            if (we.expectedMatches == ExpectedMatchingElements.NONE || we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \""
                + we.selector + "\" is currently expecting No or Multiple matches, this function only works with elements that expect one match");
            }
            else
            {
                int cycles = (explicitWait * 1000) / milisecondsInterval / 2;
                int counter = 0;
                bool mainCheck = false;
                while (counter <= cycles)
                {
                    ThisElementShouldExistRegardlessVisibility(we);
                    List<IWebElement> result = we.allMatchingResults;
                    bool isVisible = ValidateElementsAreVisible(result);
                    bool isEnabled = ValidateElementsAreEnabled(result);
                    {
                        if (isVisible && isEnabled)
                        {
                            mainCheck = true;
                            break;
                        }
                    }
                    counter = counter + 1;
                }
                if (mainCheck)
                {
                    IWebElement result = we.ReturnTheIWebElementInPosition(1);
                    if (we.needsScrolling)
                    {
                        ScrollToThisElement(we);
                    }
                    while (times > 0)
                    {
                        result.SendKeys(Keys.Backspace);
                        times = times - 1;
                    }
                }
                else
                {
                    throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \"" + we.selector + "\" was never set to visible State");
                }
            }
        }

        public void PressEnterInThisElement(ElementAbstract we)
        {
            if (we.expectedMatches == ExpectedMatchingElements.NONE || we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \""
                + we.selector + "\" is currently expecting No or Multiple matches, this function only works with elements that expect one match");
            }
            else
            {
                int cycles = (explicitWait * 1000) / milisecondsInterval / 2;
                int counter = 0;
                bool mainCheck = false;
                while (counter <= cycles)
                {
                    ThisElementShouldExistRegardlessVisibility(we);
                    List<IWebElement> result = we.allMatchingResults;
                    bool isVisible = ValidateElementsAreVisible(result);
                    bool isEnabled = ValidateElementsAreEnabled(result);
                    {
                        if (isVisible && isEnabled)
                        {
                            mainCheck = true;
                            break;
                        }
                    }
                    counter = counter + 1;
                }
                if (mainCheck)
                {
                    IWebElement result = we.ReturnTheIWebElementInPosition(1);
                    if (we.needsScrolling)
                    {
                        ScrollToThisElement(we);
                    }
                    result.SendKeys(Keys.Enter);
                }
                else
                {
                    throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \"" + we.selector + "\" was never set to visible State");
                }
            }
        }


        private void ActualEnterTextAction(IWebElement iwe, string text)
        {
            iwe.SendKeys(text);
        }


        #endregion

        #region Get Text From Element

        public string GetThisElementText(ElementAbstract we)
        {
            if (we.expectedMatches == ExpectedMatchingElements.NONE || we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \""
                + we.selector + "\" is currently expecting No or Multiple matches, this function only works with elements that expect one match");
            }
            else
            {
                int cycles = (explicitWait * 1000) / milisecondsInterval / 2;
                int counter = 0;
                bool mainCheck = false;
                while (counter <= cycles)
                {
                    ThisElementShouldExistRegardlessVisibility(we);
                    List<IWebElement> result = we.allMatchingResults;
                    if (result.Count == 1)
                    {
                        mainCheck = true;
                        break;
                    }
                    result.Clear();
                    counter = counter + 1;
                }
                if (mainCheck)
                {
                    IWebElement result = we.ReturnTheIWebElementInPosition(1);
                    if (we.needsScrolling)
                    {
                        ScrollToThisElement(we);
                    }
                    return result.Text;
                }
                else
                {
                    throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \"" + we.selector + "\" was never set to visible State");
                }


            }
        }


        public ElementAbstract ValidateAnElementHasThisText(ElementAbstract we, string text)
        {
            if (we.expectedMatches == ExpectedMatchingElements.NONE || we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \""
                + we.selector + "\" is currently expecting No or Multiple matches, this function only works with elements that expect one match");
            }
            else
            {
                int cycles = (explicitWait * 1000) / milisecondsInterval / 2;
                int counter = 0;
                bool mainCheck = false;
                while (counter <= cycles)
                {
                    ThisElementShouldExistRegardlessVisibility(we);
                    List<IWebElement> result = we.allMatchingResults;
                    bool hasText = ValidateAnElementHasThisText(result, text);
                    {
                        if (hasText)
                        {
                            mainCheck = true;
                            break;
                        }
                    }
                    counter = counter + 1;
                }
                if (mainCheck)
                {
                    return we;
                }
                else
                {
                    throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \"" + we.selector + "\" didnt have the text " + text);
                }
            }
        }

        #endregion

        #region Scroll To Elements
        public void MoveIntoViewToThisElement(ElementAbstract we)
        {
            if (we.expectedMatches == ExpectedMatchingElements.NONE || we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \""
                + we.selector + "\" is currently expecting No or Multiple matches, this function only works with elements that expect one match");
            }
            else
            {

                ThisElementShouldExistRegardlessVisibility(we);
                Actions actions = new Actions(testDriver);
                IWebElement result = we.ReturnTheIWebElementInPosition(1);
                actions.MoveToElement(result);
                actions.Perform();
            }

        }

        public void ScrollToThisElement(ElementAbstract we)
        {
            if (we.expectedMatches == ExpectedMatchingElements.NONE || we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \""
                + we.selector + "\" is currently expecting No or Multiple matches, this function only works with elements that expect one match");
            }
            else
            {
                ThisElementShouldExistRegardlessVisibility(we);
                IJavaScriptExecutor js = (IJavaScriptExecutor)testDriver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", we.ReturnTheIWebElementInPosition(1));
            }
        }


        public void ScrollToThisElement(IWebElement iwe)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)testDriver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", iwe);
        }

        #endregion

        #region InvisibilityCheck
        public ElementAbstract ThisElementShouldNotBeVisible(ElementAbstract we)
        {
            if (we.expectedMatches == ExpectedMatchingElements.NONE || we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \""
                + we.selector + "\" is currently expecting No or Multiple matches, this function only works with elements that expect one match");
            }
            else
            {
                int cycles = (explicitWait * 1000) / milisecondsInterval / 2;
                int counter = 0;
                bool mainCheck = false;
                while (counter <= cycles)
                {
                    ThisElementShouldExistRegardlessVisibility(we);
                    List<IWebElement> result = we.allMatchingResults;
                    bool isInvisible = ValidateElementsAreInvisible(result);
                    {
                        if (isInvisible)
                        {
                            mainCheck = true;
                            break;
                        }
                    }
                    counter = counter + 1;
                }
                if (mainCheck)
                {
                    return we;
                }
                else
                {
                    throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \"" + we.selector + "\" was never set to Invisible State");
                }
            }
        }

        #endregion

        #region VisibilityCheck
        public ElementAbstract ThisElementShouldBeVisible(ElementAbstract we)
        {
            if (we.expectedMatches == ExpectedMatchingElements.NONE || we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \""
                + we.selector + "\" is currently expecting No or Multiple matches, this function only works with elements that expect one match");
            }
            else
            {
                int cycles = (explicitWait * 1000) / milisecondsInterval / 2;
                int counter = 0;
                bool mainCheck = false;
                while (counter <= cycles)
                {
                    ThisElementShouldExistRegardlessVisibility(we);
                    List<IWebElement> result = we.allMatchingResults;
                    bool isInvisible = ValidateElementsAreVisible(result);
                    {
                        if (isInvisible)
                        {
                            mainCheck = true;
                            break;
                        }
                    }
                    counter = counter + 1;
                }
                if (mainCheck)
                {
                    return we;
                }
                else
                {
                    throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \"" + we.selector + "\" was never set to visible State");
                }
            }
        }

        #endregion

        #region Attribute Check

        public ElementAbstract GetThisElementAttributeNamed(ElementAbstract we, string attName)
        {
            if (we.expectedMatches == ExpectedMatchingElements.NONE || we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \""
                + we.selector + "\" is currently expecting No or Multiple matches, this function only works with elements that expect one match");
            }
            else
            {
                int cycles = (explicitWait * 1000) / milisecondsInterval / 2;
                int counter = 0;
                bool mainCheck = false;
                while (counter <= cycles)
                {
                    ThisElementShouldExistRegardlessVisibility(we);
                    List<IWebElement> result = we.allMatchingResults;
                    bool hasAtt = ValidateAnElementHasAnAttribute(result, attName);
                    {
                        if (hasAtt)
                        {
                            mainCheck = true;
                            break;
                        }
                    }
                    counter = counter + 1;
                }
                if (mainCheck)
                {
                    return we;
                }
                else
                {
                    throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \"" + we.selector + "\" didnt have an attribute named \"" + attName + "\"");
                }
            }
        }

        public ElementAbstract TheFollowingAttributeShouldHaveThisValue(ElementAbstract we, string attName, string value)
        {
            if (we.expectedMatches == ExpectedMatchingElements.NONE || we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \""
                + we.selector + "\" is currently expecting No or Multiple matches, this function only works with elements that expect one match");
            }
            else
            {
                int cycles = (explicitWait * 1000) / milisecondsInterval / 2;
                int counter = 0;
                bool mainCheck = false;
                while (counter <= cycles)
                {
                    ThisElementShouldExistRegardlessVisibility(we);
                    List<IWebElement> result = we.allMatchingResults;
                    GetThisElementAttributeNamed(we, attName);
                    bool hasAtt = ValidateAnElementHasAnAttributeWithThisValue(result, attName, value);
                    {
                        if (hasAtt)
                        {
                            mainCheck = true;
                            break;
                        }
                    }
                    counter = counter + 1;
                }
                if (mainCheck)
                {
                    return we;
                }
                else
                {
                    throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \"" + we.selector + "\" didnt have an attribute named \"" + attName + "\" set to the value \"" + value + "\"");
                }
            }
        }

        #endregion


        #region Enabled Check
        public ElementAbstract ThisElementShouldBeEnabled(ElementAbstract we)
        {
            if (we.expectedMatches == ExpectedMatchingElements.NONE || we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \""
                + we.selector + "\" is currently expecting No or Multiple matches, this function only works with elements that expect one match");
            }
            else
            {
                int cycles = (explicitWait * 1000) / milisecondsInterval / 2;
                int counter = 0;
                bool mainCheck = false;
                while (counter <= cycles)
                {
                    ThisElementShouldExistRegardlessVisibility(we);
                    List<IWebElement> result = we.allMatchingResults;
                    bool isEnabled = ValidateElementsAreEnabled(result);
                    {
                        if (isEnabled)
                        {
                            mainCheck = true;
                            break;
                        }
                    }
                    counter = counter + 1;
                }
                if (mainCheck)
                {
                    return we;
                }
                else
                {
                    throw new InvalidOperationException("The Element with Selector Method: \"" + we.selectorMethod.ToString() + "\" and Selector Path: \"" + we.selector + "\" was never set to visible State");
                }
            }
        }

        #endregion

        #endregion





        #region SearchExecutors

        private ElementAbstract ThisElementShouldHaveOneMatch(ElementAbstract we)
        {
            we.ResetElement();
            if (we.expectedMatches == ExpectedMatchingElements.ONE)
            {
                if (we.isSlowElement)
                {
                    this.explicitWait = 30;
                }
                List<IWebElement> matchingResults = SearchLoop(ExpectedMatchingElements.ONE, we.selectorMethod, we.selector);
                ThisElementShouldBeVisible(we);
                int amountElements = matchingResults.Count;
                if (amountElements == 1)
                {
                    if (ValidateElementsAreVisible(matchingResults))
                    {
                        we.allMatchingResults = matchingResults;
                        we.CountMatchingElements();
                        we.hasBeenSearched = true;
                        if (HighLightElements)
                        {
                            HighLightAllTheElementsThatMatch(we);
                        }
                        this.explicitWait = defaultExplicit;
                        return we;
                    }
                    else
                    {
                        throw new InvalidOperationException("The Element with selector Method " + we.selectorMethod.ToString() + " and Search String \"" + we.selector + "\" had one element but was not Visible");
                    }
                }
                else
                {
                    throw new InvalidOperationException("The Element with selector Method " + we.selectorMethod.ToString() + " and Search String \"" + we.selector + "\" returned " + amountElements.ToString() + " elements. We expected only one");
                }
            }
            else
            {
                throw new InvalidOperationException("The Method only work with Elements that expect ONE matching result");
            }
        }

        private ElementAbstract ThisElementShouldExistRegardlessVisibility(ElementAbstract we)
        {
            we.ResetElement();
            if (we.expectedMatches == ExpectedMatchingElements.ONE)
            {
                if (we.isSlowElement)
                {
                    this.explicitWait = 30;
                }
                List<IWebElement> matchingResults = SearchLoop(ExpectedMatchingElements.ONE, we.selectorMethod, we.selector);
                int amountElements = matchingResults.Count;
                if (amountElements == 1)
                {
                    we.allMatchingResults = matchingResults;
                    we.CountMatchingElements();
                    we.hasBeenSearched = true;
                    this.explicitWait = defaultExplicit;
                    return we;
                }
                else
                {
                    throw new InvalidOperationException("The Element with selector Method " + we.selectorMethod.ToString() + " and Search String \"" + we.selector + "\" returned " + amountElements.ToString() + " elements. We expected only one");
                }
            }
            else
            {
                throw new InvalidOperationException("The Method only work with Elements that expect ONE matching result");
            }
        }

        private ElementAbstract ThisElementShouldHaveNoMatch(ElementAbstract we)
        {
            we.ResetElement();
            if (we.expectedMatches == ExpectedMatchingElements.NONE)
            {
                if (we.isSlowElement)
                {
                    this.explicitWait = 30;
                }
                List<IWebElement> matchingResults = SearchLoop(ExpectedMatchingElements.NONE, we.selectorMethod, we.selector);
                int amountElements = matchingResults.Count;
                if (amountElements == 0)
                {
                    we.hasBeenSearched = true;
                    this.explicitWait = defaultExplicit;
                    return we;
                }
                else
                {
                    throw new InvalidOperationException("The Element with selector Method " + we.selectorMethod.ToString() + " and Search String \"" + we.selector + "\" returned " + amountElements.ToString() + " elements. We expected NONE");
                }
            }
            else
            {
                throw new InvalidOperationException("The Method only work with Elements that expect NO matching result");
            }
        }

        private ElementAbstract ThisElementShouldHaveMultipleMatches(ElementAbstract we)
        {
            we.ResetElement();
            if (we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                if (we.isSlowElement)
                {
                    this.explicitWait = 30;
                }
                List<IWebElement> matchingResults = SearchLoop(ExpectedMatchingElements.MANY, we.selectorMethod, we.selector);
                int amountElements = matchingResults.Count;
                if (amountElements >= 1)
                {
                    we.allMatchingResults = matchingResults;
                    we.allMatchingResults = matchingResults;
                    we.amountElements = amountElements;
                    we.ExpectMultipleMatches();
                    we.hasBeenSearched = true;
                    if (HighLightElements)
                    {
                        HighLightAllTheElementsThatMatch(we);
                    }
                    this.explicitWait = defaultExplicit;
                    return we;
                }
                else
                {
                    throw new InvalidOperationException("The Element with selector Method " + we.selectorMethod.ToString() + " and Search String \"" + we.selector + "\" returned " + amountElements.ToString() + " elements. We expected Many");
                }
            }
            else
            {
                throw new InvalidOperationException("The Method only work with Elements that expect ONE matching result");
            }
        }

        private ElementAbstract ThisElementShouldHaveOneMatch(ElementAbstract we, IWebElement iwe)
        {
            we.ResetElement();
            if (we.expectedMatches == ExpectedMatchingElements.ONE)
            {
                if (we.isSlowElement)
                {
                    this.explicitWait = 30;
                }
                List<IWebElement> matchingResults = SearchLoop(ExpectedMatchingElements.ONE, we.selectorMethod, we.selector, iwe);
                int amountElements = matchingResults.Count;
                if (amountElements == 1)
                {
                    if (ValidateElementsAreVisible(matchingResults))
                    {
                        we.allMatchingResults = matchingResults;
                        we.CountMatchingElements();
                        we.hasBeenSearched = true;
                        if (HighLightElements)
                        {
                            HighLightAllTheElementsThatMatch(we);
                        }
                        this.explicitWait = defaultExplicit;
                        return we;
                    }
                    else
                    {
                        throw new InvalidOperationException("The Element with selector Method " + we.selectorMethod.ToString() + " and Search String \"" + we.selector + "\" had one element but was not Visible");
                    }
                }
                else
                {
                    throw new InvalidOperationException("The Element with selector Method " + we.selectorMethod.ToString() + " and Search String \"" + we.selector + "\" returned " + amountElements.ToString() + " elements. We expected only one");
                }
            }
            else
            {
                throw new InvalidOperationException("The Method only work with Elements that expect ONE matching result");
            }
        }

        private ElementAbstract ThisElementShouldExistRegardlessVisibility(ElementAbstract we, IWebElement iwe)
        {
            we.ResetElement();
            if (we.expectedMatches == ExpectedMatchingElements.ONE)
            {
                if (we.isSlowElement)
                {
                    this.explicitWait = 30;
                }
                List<IWebElement> matchingResults = SearchLoop(ExpectedMatchingElements.ONE, we.selectorMethod, we.selector, iwe);
                int amountElements = matchingResults.Count;
                if (amountElements == 1)
                {
                    we.allMatchingResults = matchingResults;
                    we.CountMatchingElements();
                    we.hasBeenSearched = true;
                    this.explicitWait = defaultExplicit;
                    return we;
                }
                else
                {
                    throw new InvalidOperationException("The Element with selector Method " + we.selectorMethod.ToString() + " and Search String \"" + we.selector + "\" returned " + amountElements.ToString() + " elements. We expected only one");
                }
            }
            else
            {
                throw new InvalidOperationException("The Method only work with Elements that expect ONE matching result");
            }
        }

        private ElementAbstract ThisElementShouldHaveNoMatch(ElementAbstract we, IWebElement iwe)
        {
            we.ResetElement();
            if (we.expectedMatches == ExpectedMatchingElements.NONE)
            {
                if (we.isSlowElement)
                {
                    this.explicitWait = 30;
                }
                List<IWebElement> matchingResults = SearchLoop(ExpectedMatchingElements.NONE, we.selectorMethod, we.selector, iwe);
                int amountElements = matchingResults.Count;
                if (amountElements == 0)
                {
                    we.hasBeenSearched = true;
                    this.explicitWait = defaultExplicit;
                    return we;
                }
                else
                {
                    throw new InvalidOperationException("The Element with selector Method " + we.selectorMethod.ToString() + " and Search String \"" + we.selector + "\" returned " + amountElements.ToString() + " elements. We expected NONE");
                }
            }
            else
            {
                throw new InvalidOperationException("The Method only work with Elements that expect NO matching result");
            }
        }

        private ElementAbstract ThisElementShouldHaveMultipleMatches(ElementAbstract we, IWebElement iwe)
        {
            we.ResetElement();
            if (we.expectedMatches == ExpectedMatchingElements.MANY)
            {
                if (we.isSlowElement)
                {
                    this.explicitWait = 30;
                }
                List<IWebElement> matchingResults = SearchLoop(ExpectedMatchingElements.MANY, we.selectorMethod, we.selector, iwe);
                int amountElements = matchingResults.Count;
                if (amountElements >= 1)
                {
                    we.allMatchingResults = matchingResults;
                    we.amountElements = amountElements;
                    we.ExpectMultipleMatches();
                    we.hasBeenSearched = true;
                    if (HighLightElements)
                    {
                        HighLightAllTheElementsThatMatch(we);
                    }
                    this.explicitWait = defaultExplicit;
                    return we;
                }
                else
                {
                    throw new InvalidOperationException("The Element with selector Method " + we.selectorMethod.ToString() + " and Search String \"" + we.selector + "\" returned " + amountElements.ToString() + " elements. We expected Many");
                }
            }
            else
            {
                throw new InvalidOperationException("The Method only work with Elements that expect ONE matching result");
            }
        }

        #endregion

        #region SearchLoops

        private List<IWebElement> SearchLoop(ExpectedMatchingElements expNumber, SearchMethod method, string sel)
        {
            List<IWebElement> matchingResults = new List<IWebElement>();
            int cycles = (explicitWait * 1000) / milisecondsInterval / 2;
            int counter = 0;
            while (counter <= cycles)
            {
                matchingResults.Clear();
                matchingResults = PerformSearchInPage(method, sel);
                if (matchingResults.Count == 0 && expNumber == ExpectedMatchingElements.NONE)
                {
                    break;
                }
                else if (matchingResults.Count >= 1 && expNumber == ExpectedMatchingElements.MANY)
                {
                    break;
                }
                else if (matchingResults.Count == 1 && expNumber == ExpectedMatchingElements.ONE)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(milisecondsInterval);
                    counter = counter + 1;
                }
            }
            return matchingResults;
        }



        private List<IWebElement> SearchLoop(ExpectedMatchingElements expNumber, SearchMethod method, string sel, IWebElement iwe)
        {
            List<IWebElement> matchingResults = new List<IWebElement>();
            int cycles = (explicitWait * 1000) / milisecondsInterval / 2;
            int counter = 0;
            while (counter <= cycles)
            {
                matchingResults.Clear();
                matchingResults = PerformSearchInElement(method, sel, iwe);
                if (matchingResults.Count == 0 && expNumber == ExpectedMatchingElements.NONE)
                {
                    break;
                }
                else if (matchingResults.Count >= 1 && expNumber == ExpectedMatchingElements.MANY)
                {
                    break;
                }
                else if (matchingResults.Count == 1 && expNumber == ExpectedMatchingElements.ONE)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(milisecondsInterval);
                    counter = counter + 1;
                }
            }
            return matchingResults;
        }

        #endregion

        #region Property Checks

        private bool ValidateElementsAreVisible(List<IWebElement> elements)
        {
            bool areVisible = true;
            foreach (IWebElement iwe in elements)
            {
                if (!iwe.Displayed)
                {
                    areVisible = false;
                    break;
                }
            }
            return areVisible;
        }

        private bool ValidateElementsAreInvisible(List<IWebElement> elements)
        {
            bool nonVisible = true;
            foreach (IWebElement iwe in elements)
            {
                if (iwe.Displayed)
                {
                    nonVisible = false;
                    break;
                }
            }
            return nonVisible;
        }

        private bool ValidateElementsAreEnabled(List<IWebElement> elements)
        {
            bool areEnabled = true;
            foreach (IWebElement iwe in elements)
            {
                if (!iwe.Enabled)
                {
                    areEnabled = false;
                    break;
                }
            }
            return areEnabled;
        }

        private bool ValidateAnElementHasThisText(List<IWebElement> elements, string text)
        {
            bool hasText = false;
            foreach (IWebElement iwe in elements)
            {
                if (iwe.Text == text)
                {
                    hasText = true;
                    break;
                }
            }
            return hasText;
        }

        private bool ValidateAnElementHasAnAttribute(List<IWebElement> elements, string attributeName)
        {
            //If an element has no attribute, GetAttribute returns null
            //If an element has an attribute but is not set, it is set to "", an empty string
            //If an element has an attribut that is set, the method returns a string with the value
            bool hasAttribute = false;
            foreach (IWebElement iwe in elements)
            {
                string value = iwe.GetAttribute(attributeName);
                if (value != null)
                {
                    hasAttribute = true;
                    break;
                }
            }
            return hasAttribute;
        }

        private bool ValidateAnElementHasAnAttributeWithThisValue(List<IWebElement> elements, string attributeName, string expValue)
        {
            //If an element has no attribute, GetAttribute returns null
            //If an element has an attribute but is not set, it is set to "", an empty string
            //If an element has an attribut that is set, the method returns a string with the value
            bool hasValue = false;
            foreach (IWebElement iwe in elements)
            {
                string value = iwe.GetAttribute(attributeName);
                if (value == expValue)
                {
                    hasValue = true;
                    break;
                }
            }
            return hasValue;
        }


        #endregion

        #region ExecuteActualSearch
        public List<IWebElement> PerformSearchInPage(SearchMethod method, string selector)
        {
            List<IWebElement> elements = new List<IWebElement>();
            if (method == SearchMethod.ID)
            {
                IReadOnlyList<IWebElement> elementsListID = testDriver.FindElements(By.Id(selector));
                foreach (IWebElement element in elementsListID)
                {
                    elements.Add(element);
                }
            }
            if (method == SearchMethod.CLASS)
            {
                IReadOnlyList<IWebElement> elementsListClass = testDriver.FindElements(By.ClassName(selector));
                foreach (IWebElement element in elementsListClass)
                {
                    elements.Add(element);
                }
            }
            if (method == SearchMethod.NAME)
            {
                IReadOnlyList<IWebElement> elementsListName = testDriver.FindElements(By.Name(selector));
                foreach (IWebElement element in elementsListName)
                {
                    elements.Add(element);
                }
            }

            if (method == SearchMethod.CSS)
            {
                IReadOnlyList<IWebElement> elementsListCss = testDriver.FindElements(By.CssSelector(selector));
                foreach (IWebElement element in elementsListCss)
                {
                    elements.Add(element);
                }
            }

            if (method == SearchMethod.XPATH)
            {
                IReadOnlyList<IWebElement> elementsListXpath = testDriver.FindElements(By.XPath(selector));
                foreach (IWebElement element in elementsListXpath)
                {
                    elements.Add(element);
                }
            }

            if (method == SearchMethod.LINK)
            {
                IReadOnlyList<IWebElement> elementsListLinkText = testDriver.FindElements(By.LinkText(selector));
                foreach (IWebElement element in elementsListLinkText)
                {
                    elements.Add(element);
                }
            }
            return elements;
        }


        public List<IWebElement> PerformSearchInElement(SearchMethod method, string selector, IWebElement iwe)
        {
            List<IWebElement> elements = new List<IWebElement>();
            if (method == SearchMethod.ID)
            {
                IReadOnlyList<IWebElement> elementsListID = iwe.FindElements(By.Id(selector));
                foreach (IWebElement element in elementsListID)
                {
                    elements.Add(element);
                }
            }
            if (method == SearchMethod.CLASS)
            {
                IReadOnlyList<IWebElement> elementsListClass = iwe.FindElements(By.ClassName(selector));
                foreach (IWebElement element in elementsListClass)
                {
                    elements.Add(element);
                }
            }
            if (method == SearchMethod.NAME)
            {
                IReadOnlyList<IWebElement> elementsListName = iwe.FindElements(By.Name(selector));
                foreach (IWebElement element in elementsListName)
                {
                    elements.Add(element);
                }
            }

            if (method == SearchMethod.CSS)
            {
                IReadOnlyList<IWebElement> elementsListCss = iwe.FindElements(By.CssSelector(selector));
                foreach (IWebElement element in elementsListCss)
                {
                    elements.Add(element);
                }
            }

            if (method == SearchMethod.XPATH)
            {
                IReadOnlyList<IWebElement> elementsListXpath = iwe.FindElements(By.XPath(selector));
                foreach (IWebElement element in elementsListXpath)
                {
                    elements.Add(element);
                }
            }

            if (method == SearchMethod.LINK)
            {
                IReadOnlyList<IWebElement> elementsListLinkText = iwe.FindElements(By.LinkText(selector));
                foreach (IWebElement element in elementsListLinkText)
                {
                    elements.Add(element);
                }
            }
            return elements;
        }
        #endregion


    }
}
