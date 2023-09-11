using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace STS2

{
    class Program
    {
        static void Main(string[] args)
        {
            Uri httpUri = new Uri("http://localhost:9394/CustomSTS.svc/CustomSTS");

            ServiceHost myHost = new ServiceHost(typeof(CustomSTS), httpUri);

            WSHttpBinding b = new WSHttpBinding();
            b.Security.Mode = SecurityMode.None;
            

            myHost.AddServiceEndpoint(typeof(ICustomSTS), b, "");

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost.Description.Behaviors.Add(smb);
            myHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            myHost.Open();

            Console.WriteLine("Host was started...");
            Console.ReadLine();

            myHost.Close();
        }

    }
}
