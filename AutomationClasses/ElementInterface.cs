using AutomationClasses;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using static AutomationClasses.AutomationOptions;

namespace PageObjects
{
    public class ElementInterface
    {
        public string selector;
        public SearchMethod selectorMethod;
        public List<IWebElement> allMatchingResults = new List<IWebElement>();
        public int amountElements  = 0;
        public ExpectedMatchingElements expectedMatches  { get; private set; }
        public ExpectedMatchingElements actualMatches { get; private set; }
        public bool doValidation = true;
        public bool hasBeenSearched = false;
        public bool needsScrolling = false;
        public bool isSlowElement = false;

        public ElementInterface()
        {
            expectedMatches = AutomationOptions.ExpectedMatchingElements.NONE;
            ExpectNoMatches();
        }


        //The Default Constructor Sets 
        public ElementInterface(string sel, SearchMethod method)
        {
            selector = sel;
            selectorMethod = method;
            expectedMatches = AutomationOptions.ExpectedMatchingElements.ONE;
        }


        //This contructor takes any value lower than 1 as if we were not expecting any Element
        //Any value higher than 1 means it expects more than 1 Elements
        //A Value of one means we expect exactly 1 Element
        public ElementInterface(string sel, SearchMethod method, ExpectedMatchingElements expected)
        {
            selector = sel;
            selectorMethod = method;
            expectedMatches = expected;
        }


        public void ResetElement()
        {
            allMatchingResults.Clear();
            amountElements = 0;
            hasBeenSearched = false;
        }

        public void ExpectOneMatch()
        {
            expectedMatches = AutomationOptions.ExpectedMatchingElements.ONE;
        }

        public void ExpectMultipleMatches()
        {
            expectedMatches = AutomationOptions.ExpectedMatchingElements.MANY;
        }

        public void ExpectNoMatches()
        {
            expectedMatches = AutomationOptions.ExpectedMatchingElements.NONE;
        }


        public void ValidateMatches()
        {
            if (expectedMatches != actualMatches)
            {
                throw new InvalidOperationException("The Element with Selector Method: \"" + selectorMethod + "\" and Selector Path: \"" + selector + "\" has " + amountElements + " matching results.");

            }
        }


        public void CountMatchingElements()
        {
            amountElements = allMatchingResults.Count;
            if (amountElements > 1)
            {
                actualMatches = AutomationOptions.ExpectedMatchingElements.MANY;
            }
            else if (amountElements == 0)
            {
                actualMatches = AutomationOptions.ExpectedMatchingElements.NONE;
            }
            else
            {
                actualMatches = AutomationOptions.ExpectedMatchingElements.ONE;
            }
        }


        public IWebElement ReturnTheIWebElementInPosition(int i)
        {
            IWebElement TestWE = null;
            if (!(i <= 0 || i > amountElements))
            {
                TestWE = allMatchingResults.ElementAt(i - 1);
            }
            return TestWE;
        }


        public int ReturnPositionOfElementThatHasThisText(string text)
        {
            int index = 1;
            bool isPresent = false;
            foreach (IWebElement iw in allMatchingResults)
            {
                if (iw.Text == text)
                {
                    isPresent = true;
                    break;
                }
                index = index + 1;
            }
            if (isPresent)
            {
                return index;
            }
            else
            {
                return 0;
            }
        }

        public string GetTextFromElementInThisPosition(int position)
        {
            string text = null;
            if (amountElements >= position && amountElements > 0 && position >= 1)
            {
                IWebElement result = ReturnTheIWebElementInPosition(position);
                text = result.Text;
            }
            return text;
        }

        public List<string> GetTextFromAllMatchingElements()
        {
            List<string> text = new List<string>();
            foreach (IWebElement iwe in allMatchingResults)
            {
                text.Add(iwe.Text);
            }
            return text;
        }

    }
}
