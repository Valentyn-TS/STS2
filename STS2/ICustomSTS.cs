using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace STS2
{
	[ServiceContract(Name = "SecurityTokenService", Namespace = "http://tempuri.org")]
	public interface ICustomSTS
	{
		[OperationContract(Action = Constants.Trust.Actions.Issue,
						   ReplyAction = Constants.Trust.Actions.IssueReply)]
		Message ProcessRequestSecurityToken(Message message);
	}
}

