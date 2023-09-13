using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel;
using System.Web;

namespace STS2
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class HomeRealmSTS : CustomSTS
    {
        public HomeRealmSTS() :
            base(ServiceConstants.StsName,
                 FederationUtilities.GetX509TokenFromCert(ServiceConstants.CertStoreName, ServiceConstants.CertStoreLocation, ServiceConstants.CertDistinguishedName),
                 FederationUtilities.GetX509TokenFromCert(ServiceConstants.CertStoreName, ServiceConstants.CertStoreLocation, ServiceConstants.TargetDistinguishedName))
        {
        }

        /// <summary>
        /// Overrides the GetIssuedClaims from the SecurityTokenService Base Class
        /// to return a valid user claim and purchase limit claim with the appropriate purchase limit 
        /// for the user
        /// </summary>
        protected override Collection<SamlAttribute> GetIssuedClaims(RequestSecurityToken requestSecurityToken)
        {
            string caller = ServiceSecurityContext.Current.PrimaryIdentity.Name;

            // Create Name and PurchaseLimit claims
            Collection<SamlAttribute> samlAttributes = new Collection<SamlAttribute>();
            samlAttributes.Add(new SamlAttribute(System.IdentityModel.Claims.Claim.CreateNameClaim(caller)));
            return samlAttributes;
        }

        /// <summary>
        /// This method adds the audience uri restriction condition to the SAML assetion.
        /// </summary>
        /// <param name="samlConditions">The saml condition collection where the audience uri restriction condition will be added.</param>
        public override void AddAudienceRestrictionCondition(SamlConditions samlConditions)
        {
            samlConditions.Conditions.Add(new SamlAudienceRestrictionCondition(new Uri[] { new Uri(Constants.ServiceAudienceUri) }));
        }
    }
}