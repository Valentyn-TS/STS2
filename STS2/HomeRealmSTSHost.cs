using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;

namespace STS2
{
	public class HomeRealmSTSHostFactory : ServiceHostFactoryBase
	{
		public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
		{
			return new HomeRealmSTSHost(baseAddresses);
		}
	}

	class HomeRealmSTSHost : ServiceHost
	{
		public HomeRealmSTSHost(params Uri[] addresses) : base(typeof(HomeRealmSTS), addresses)
		{
			ServiceConstants.LoadAppSettings();
		}
	}
}