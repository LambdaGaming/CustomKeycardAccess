using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Interactables.Interobjects.DoorUtils;
using System;
using System.Collections.Generic;

namespace CustomKeycardAccess
{
	public class EventHandlers
	{
		private Plugin plugin;

		public EventHandlers( Plugin plugin ) => this.plugin = plugin;

		public void OnDoorInteract( InteractingDoorEventArgs ev )
		{
			if ( ev.Door.RequiredPermissions.RequiredPermissions != KeycardPermissions.None )
			{
				foreach ( KeyValuePair<string, string> kv in plugin.Config.AllowList )
				{
					Door door = Door.Get( kv.Value );
					ItemType keycard = ( ItemType ) Enum.Parse( typeof( ItemType ), kv.Key );
					if ( door == ev.Door && keycard == ev.Player.CurrentItem.Type )
					{
						ev.IsAllowed = true;
						break;
					}
				}
			}
#if DEBUG
			foreach ( KeyValuePair<string, DoorNametagExtension> kv in DoorNametagExtension.NamedDoors )
			{
				Log.Info( kv.Key );
			}
#endif
		}
	}
}
