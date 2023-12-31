﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STS2
{
    public class Constants
    {
        public const string Namespace = "http://tempuri.org/";
        //public const string Namespace = "http://docs.oasis-open.org/ws-sx/ws-trust/200512";
        public const string SamlTokenTypeUri = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1";

        public const string ServiceAudienceUri = "https://localhost:8080/services/echo/soap12";

        // Various constants for WS-Trust
        public class Trust
        {
            //public const string NamespaceUri = "http://schemas.xmlsoap.org/ws/2005/02/trust";
            public const string NamespaceUri = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
            
            //public const string NamespaceUri = "http://docs.oasis-open.org/ws-sx/ws-trust/200512";
            
            public class Actions
            {
                public const string Issue = "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue";
                public const string IssueReply = "http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Issue";
                //public const string Issue = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
                //public const string IssueReply = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
            }


            public class Attributes
            {
                public const string Context = "Context";
            }

            public class Elements
            {
                public const string KeySize = "KeySize";
                public const string Entropy = "Entropy";
                public const string BinarySecret = "BinarySecret";
                public const string RequestSecurityToken = "RequestSecurityToken";
                public const string RequestSecurityTokenResponse = "RequestSecurityTokenResponse";
                public const string TokenType = "TokenType";
                public const string RequestedSecurityToken = "RequestedSecurityToken";
                public const string RequestedAttachedReference = "RequestedAttachedReference";
                public const string RequestedUnattachedReference = "RequestedUnattachedReference";
                public const string RequestedProofToken = "RequestedProofToken";
                public const string ComputedKey = "ComputedKey";
            }

            public class ComputedKeyAlgorithms
            {
                public const string PSHA1 = "http://schemas.xmlsoap.org/ws/2005/02/trust/CK/PSHA1";
            }
        }

        // Various constants for WS-Policy
        public class Policy
        {
            public const string NamespaceUri = "http://schemas.xmlsoap.org/ws/2004/09/policy";

            //public const string NamespaceUri = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0";

            public class Elements
            {
                public const string AppliesTo = "AppliesTo";
            }
        }

        // Various constants for WS-Addressing
        public class Addressing
        {
            public const string NamespaceUri = "http://www.w3.org/2005/08/addressing";


            public class Elements
            {
                public const string EndpointReference = "EndpointReference";
            }
        }
    }
}