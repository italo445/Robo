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
    public class AbrirPagina : IPipe
    {
        public object Run(dynamic input)
        {
            ChromeDriver driver = input.driver;
            driver.Navigate().GoToUrl("http://websigom.otimoonline.com.br/WebSigom/sltwebsigom");
            bool elementLogin = false;
            int contador = 0;
            PaginaExpirada pag = new PaginaExpirada();
            Rename re = new Rename();
            input.cont = 1;
            //VALIDAÇAO
            do
            {
                elementLogin = Util.Wait.WaitElement(@"//*[@id='LOGIN']", driver);
                contador++;
                Thread.Sleep(500);
            } while (!elementLogin && contador <= 10);

            if (!elementLogin)
            {
                Console.WriteLine("ERRO");
                throw new Exception("Elemento login nao disponivel");
            }

            //LOGIN

            driver.FindElement(By.Id(@"LOGIN")).SendKeys("");
            driver.FindElement(By.Id(@"SENHA")).SendKeys("");
            driver.FindElement(By.XPath("//img[@alt='Conectar na Aplicação']")).Click();


            //SCRIPT ABRIR OPÇÕES
            var webElement = driver.FindElement(By.XPath(@"//*[@id='menu05']"));
            string javaScript = "var evObj = document.createEvent('MouseEvents');" +
                                "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                                "arguments[0].dispatchEvent(evObj);";
            IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
            executor.ExecuteScript(javaScript, webElement);


            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//td[@onclick='clicar(8)']")).Click();
            driver.FindElement(By.XPath("//input[@value='Exportar Planilha']")).Click();

            
            
            Thread.Sleep(7000);
            re.Run(input);

            driver.Navigate().Refresh();
            Thread.Sleep(5000);


            
            //verifica existencia elemento na tela
            bool status = driver.FindElement(By.Name("EXPIROU")).Displayed;


            if (status == true)
            {
                 pag.Run(input);

                Thread.Sleep(5000);
                 re.Run(input);
            }

            else
            {
                executor.ExecuteScript(javaScript, webElement);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//td[@onclick='clicar(10)']")).Click();
                driver.FindElement(By.XPath("//input[@value='Exportar Planilha']")).Click();

            }
          
            
           

            return input;
        }
    }
}
