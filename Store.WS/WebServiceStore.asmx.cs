using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Store.WS
{
    /// <summary>
    /// Summary description for WebServiceStore
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceStore : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(MessageName ="List Of Files", Description = "Return if processed or not")]
        public bool SendFiles(string[] linhas)
        {
            bool processado = false;

            ProcessarLinhas(linhas);

            return processado;
        }

        private bool ProcessarLinhas(string[] linhas)
        {
            bool processado = false;

            foreach (string linha in linhas)
            {
                //aqui você trata o arquivo do jeito que vc preferir
            }
            
            return processado;
        }
    }
}
