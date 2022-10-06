using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCartaoOtimo.Pipes.Navegador
{
    public class Launch : IPipe
    {
        public IWebDriver Driver { get; set; }
        public object Run(dynamic input)
        {
            
            string version = null;
            var path = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            try
            {
                version = FileVersionInfo.GetVersionInfo(path).FileVersion.Split('.').FirstOrDefault();
            }
            catch (Exception)
            {
                path = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                version = FileVersionInfo.GetVersionInfo(path).FileVersion.Split('.').FirstOrDefault();
            }
            

            ChromeOptions opt = new ChromeOptions();
            opt.AcceptInsecureCertificates = true;
            opt.AddArgument("--start-maximized");
            opt.AddArgument("--aways-authorize-plugins");
            opt.AddArgument("--disable-notifications");
            opt.AddArgument("--no-sandbox");
            opt.AddArgument("--ignore-certificate-errors");
            opt.AddArgument("--ignore-ssl-errors");
           
           
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService($@"{AppDomain.CurrentDomain.BaseDirectory}drivers\{version}");
            chromeDriverService.HideCommandPromptWindow = true;

            Driver = new ChromeDriver(chromeDriverService, opt);

            

            input.driver = Driver;
            return input;

        }
    }
}
