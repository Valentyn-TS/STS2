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
            Uri httpUri = new Uri("http://localhost:9394/STS.svc/CustomSTS");
            Uri httpsUri = new Uri("https://localhost:44368/STS.svc/CustomSTS");
            Uri mex = new Uri("http://localhost:9394/STS.svc/mex");

            ServiceHost myHost = new ServiceHost(typeof(CustomSTS), httpsUri);

            WSHttpBinding b = new WSHttpBinding();
            b.Security.Mode = SecurityMode.TransportWithMessageCredential;
            b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
                       

            myHost.AddServiceEndpoint(typeof(ICustomSTS), b, "");
                
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.HttpsGetEnabled = true;
            myHost.Description.Behaviors.Add(smb);
            myHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), mex);


            Console.WriteLine("Host was started...");
            Console.ReadLine();

            myHost.Close();
        }

    }
}
