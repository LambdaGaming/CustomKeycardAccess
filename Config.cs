using System.ComponentModel;
using Exiled.API.Interfaces;

namespace CustomKeycardAccess
{
	public sealed class Config : IConfig
	{
		[Description( "Whether the plugin is enabled or not." )]
		public bool IsEnabled { get; set; } = true;
	}
}
