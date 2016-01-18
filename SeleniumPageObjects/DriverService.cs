﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using System;

namespace SeleniumPageObjects
{
    class DriverService 
    {
        //public IWebDriver Driver { get; }
        public IWebDriver GetBrowserForDriver(string browser)
        {
            switch (browser) { 
                case "Firefox":
                    return new FirefoxDriver();

                case "Chrome":
                return new ChromeDriver();

                case "PhantomJS":
                return new PhantomJSDriver();

                default:
                throw new ArgumentException("Not supported browser");
            }
        }
    }
}