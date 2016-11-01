﻿using OpenQA.Selenium;

namespace SeleniumExtension.Elements
{
    /// <summary>
    /// Contaains the basic functionality that an HTML Element needs
    /// </summary>
    public class BaseElement
    {
        public IWebElement WrappedElement { get; set; }
    }
}