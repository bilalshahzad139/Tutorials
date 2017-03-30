using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//This is required to call 'Extension' methods like 'QuerySelectorAll'
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System.Net;


namespace DataScrapingSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var URL = "http://www.rozee.pk/job/jsearch/q/software+engineer";
            var _wReq = (HttpWebRequest)WebRequest.Create(URL);
            _wReq.Method = "GET";
            String reponseHtml = "";

            HttpWebResponse _wResp = (HttpWebResponse)_wReq.GetResponse();
            using (System.IO.StreamReader _sr = new System.IO.StreamReader(_wResp.GetResponseStream()))
            {
                reponseHtml = _sr.ReadToEnd();
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(reponseHtml);

            var divs = doc.DocumentNode.QuerySelectorAll(".jlist div.job").ToList();

            foreach (var jobdiv in divs)
            {
                var doc1 = new HtmlAgilityPack.HtmlDocument();
                doc1.LoadHtml(jobdiv.InnerHtml);
                String jtitle = doc1.DocumentNode.QuerySelector("div.jobt h3 bdi").InnerText;
                
            }

        }
    }
}
