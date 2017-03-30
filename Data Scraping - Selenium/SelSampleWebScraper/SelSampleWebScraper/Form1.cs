using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SelSampleWebScraper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String url = "http://www.rozee.pk/job/jsearch/q/all";

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            //Selector to access textbox on the page
            String selector = "input[name=job_title]";
            var element = driver.FindElement(By.CssSelector(selector));
            //Type text in that box
            element.SendKeys("software engineer");


            //Selector to access Search button
            selector = "button.btn.search";
            element = driver.FindElement(By.CssSelector(selector));
            //Click the button
            element.Click();

            //jobs divs
            selector = ".jlist div.job";
            var divs = driver.FindElements(By.CssSelector(selector));

            foreach (var jobdiv in divs)
            {
                //For each job div
                String jtitle = jobdiv.FindElement(By.CssSelector("div.jobt h3 bdi")).Text;
                String cname = jobdiv.FindElement(By.CssSelector("div.jobt .cname bdi")).Text;
            }

        }
    }
}
