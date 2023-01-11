using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace CustomKeycardAccess
{
	public sealed class Config : IConfig
	{
		[Description( "Whether the plugin is enabled or not." )]
		public bool IsEnabled { get; set; } = true;

		[Description( "Whether or not debug messages should be shown in the console." )]
		public bool Debug { get; set; } = false;

		[Description( "List of keycards and the doors that they should open. Needs to be in the following format: KEYCARDNAME: DOORNAME" )]
		public Dictionary<string, string> AllowList { get; set; } = new Dictionary<string, string>() {
			{ "KeycardGuard", "INTERCOM" }
		};
	}
}
