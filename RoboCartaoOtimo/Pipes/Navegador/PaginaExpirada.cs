using Docker.DotNet.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace RoboCartaoOtimo.Pipes.Navegador
{
    class PaginaExpirada : IPipe
    {

        public object Run(dynamic input){
            ChromeDriver driver = input.driver;

            driver.FindElement(By.Name("EXPIROU")).Click();
            driver.FindElement(By.Id(@"LOGIN")).SendKeys("");
            driver.FindElement(By.Id(@"SENHA")).SendKeys("");
            driver.FindElement(By.XPath("//img[@alt='Conectar na Aplicação']")).Click();




            var webElement = driver.FindElement(By.XPath(@"//*[@id='menu05']"));
            string javaScript = "var evObj = document.createEvent('MouseEvents');" +
                                "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                                "arguments[0].dispatchEvent(evObj);";
            IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
            executor.ExecuteScript(javaScript, webElement);




            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//td[@onclick='clicar(10)']")).Click();
            driver.FindElement(By.XPath("//input[@value='Exportar Planilha']")).Click();

            
            return input;
        }


    }
}
