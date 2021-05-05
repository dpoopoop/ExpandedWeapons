using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Threading;
using System.Collections.Generic;
using Terraria.ModLoader.IO;
using System.IO;
using Terraria.DataStructures;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ExpandedWeapons.NPCs;
using ExpandedWeapons.Items.Melee;

namespace ExpandedWeapons.NPCs
{
	public class ExpandedNPCWorld : ModWorld
    {
		public static bool DownedCloudBoss = false;

		public override void Initialize()
		{
			DownedCloudBoss = false;
		}
		public override TagCompound Save()
		{
			var Downed = new List<string>();
			if (DownedCloudBoss) 
			{
			Downed.Add("cloudBoss");
			}

			return new TagCompound
			{
				["Version"] = 0,
				["Downed"] = Downed
						
			};
		}
		public override void Load(TagCompound tag)
		{
			var Downed = tag.GetList<string>("Downed");
			DownedCloudBoss = Downed.Contains("cloudBoss");
		}
		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if(loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				DownedCloudBoss = flags[0];
			}
		}
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags [0] = DownedCloudBoss;

			writer.Write(flags);
		}
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			DownedCloudBoss = flags[0];
		}
		public override void PostWorldGen() 
		{
			int[] itemsToPlaceInSkyChests = { ModContent.ItemType<StarryThrow>(), ModContent.ItemType<WindySpinner>()};
			int itemsToPlaceInSkyChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++) {
				Chest chest = Main.chest[chestIndex];
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 13 * 36) {
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) {
						if (chest.item[inventoryIndex].type == ItemID.None) {
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInSkyChests[itemsToPlaceInSkyChestsChoice]);
							itemsToPlaceInSkyChestsChoice = (itemsToPlaceInSkyChestsChoice + 1) % itemsToPlaceInSkyChests.Length;
							// Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInSkyChests));
							break;
						}
					}
				}
			}
		}
	}
}