using Exiled.API.Features.Doors;
using Exiled.Events.EventArgs.Player;
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
			if ( ev.Door.RequiredPermissions.RequiredPermissions != KeycardPermissions.None && !ev.Player.IsScp )
			{
				foreach ( KeyValuePair<string, string[]> kv in plugin.Config.AllowList )
				{
					foreach ( string d in kv.Value )
					{
						Door door = Door.Get( d );
						ItemType keycard = ( ItemType ) Enum.Parse( typeof( ItemType ), kv.Key );
						if ( door == ev.Door && keycard == ev.Player.CurrentItem.Type )
						{
							ev.IsAllowed = true;
							break;
						}
					}
				}
			}
		}
	}
}
