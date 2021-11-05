using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AwsCoreEcar.Dashboard.Pages.PagoNiubiz
{
    public class IndexModel : PageModel
    {

        public string Transactiontoken { get; set; }

        public async Task OnGetAsync()
        {
            Console.WriteLine("------------ GET ----------");
            Transactiontoken = "";
        }

        public async Task OnPostAsync()
        {

            Console.WriteLine("------------ POST ----------");

            var reqMessage = Request.Query["message"];
            var reqMerchantid = Request.Query["merchantid"];
            var reqPurchasenumber = Request.Query["purchasenumber"];
            var reqToken = Request.Query["token"];


            var reqTransactionToken = Request.Form["transactionToken"];
            var reqCustomerEmail = Request.Form["customerEmail"];
            var reqChannel = Request.Form["channel"];

            

            Console.WriteLine("transactionToken => " + reqTransactionToken);
            Console.WriteLine("customerEmail => " + reqCustomerEmail);
            Console.WriteLine("reqChannel => " + reqChannel);

            //Create my object
            var transactionJson = new
            {
                merchantid = reqMerchantid.ToString(),
                purchasenumber = reqPurchasenumber.ToString(),
                token = reqToken.ToString(),
                transactionToken = reqTransactionToken.ToString(),
                customerEmail = reqCustomerEmail.ToString(),
                channel = reqChannel.ToString()
            };

            string jsonData = JsonConvert.SerializeObject(transactionJson);
            Transactiontoken = jsonData;
        }

    }
}