using System;
using Microsoft.AspNetCore.Authorization;

namespace Fish
{
	public class BasicAuthorizeAttribute : AuthorizeAttribute
	{
		public BasicAuthorizeAttribute()
		{
			Policy = "BasicAuthentication";
		}
	}
}

