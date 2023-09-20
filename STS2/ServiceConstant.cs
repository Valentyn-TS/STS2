using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace STS2
{
    class ServiceConstants
    {
        // Issuer name placed into issued tokens
        internal const string StsName = "Home Realm STS";

        // Statics for location of certs
        internal static StoreName CertStoreName = StoreName.TrustedPeople;
        internal static StoreLocation CertStoreLocation = StoreLocation.LocalMachine;

        // Statics initialized from app.config
        internal static string CertDistinguishedName = "77c42e0cda56fc84c5b878786ea35880a1486155";
        internal static string TargetDistinguishedName = "5833a93f965f7473";

        #region Helper functions to load app settings from config
        /// <summary>
        /// Helper function to load Application Settings from config
        /// </summary>
        public static void LoadAppSettings()
        {
            CheckIfLoaded(CertDistinguishedName);
            CheckIfLoaded(TargetDistinguishedName);
        }

        /// <summary>
        /// Helper function to check if a required Application Setting has been specified in config.
        /// Throw if some Application Setting has not been specified.
        /// </summary>
        private static void CheckIfLoaded(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                throw new ConfigurationErrorsException("Required Configuration Element(s) missing at HomeRealmSTS. Please check the STS configuration file.");
            }
        }

        #endregion
    }
}