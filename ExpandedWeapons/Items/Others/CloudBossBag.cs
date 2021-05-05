using ExpandedWeapons.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Items;
using ExpandedWeapons.Items.Others;

namespace ExpandedWeapons.Items.Others
{
	public class CloudBossBag : ModItem
	{
		public override int BossBagNPC => mod.NPCType("CloudBoss");

		//public override int BossBagNPC
		//{
			//get
			//{
				//return mod.NPCType("MeteorBoss");
			//}
		//}

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cloud Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 40;
			item.height = 40;
			item.rare = -12;
			item.expert = true;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) 
		{
			player.QuickSpawnItem(ItemID.GoldCoin, 15);
			player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 10));
			player.QuickSpawnItem(ItemID.GreaterManaPotion, Main.rand.Next(5, 10));
			player.TryGettingDevArmor();
			player.TryGettingDevArmor();
			int choice = Main.rand.Next(4);
			if (choice == 0) {
				player.QuickSpawnItem(ItemID.DaedalusStormbow);
			}
			else if (choice == 1) {
				player.QuickSpawnItem(ItemID.SkyFracture); 
				}
			else if (choice == 2) {
				player.QuickSpawnItem(ItemID.NimbusRod); 
			}
			else if (choice == 3) {
				player.QuickSpawnItem(ItemID.FairyWings);
			}

			player.QuickSpawnItem(ModContent.ItemType<CloudHandle>()); //material
			player.QuickSpawnItem(ModContent.ItemType<CloudStar>());//expert item

			if (NPC.downedGolemBoss)
            {
				player.QuickSpawnItem(ModContent.ItemType<SoulOfCloud>());
				int gchoice = Main.rand.Next(4);
            if (gchoice == 0) {
				player.QuickSpawnItem(ModContent.ItemType<Items.Magic.Mordred>());
			}
			if (gchoice == 1) {
				player.QuickSpawnItem(ModContent.ItemType<Items.Summon.GeometricalWhipinator>()); 
			}
			if (gchoice == 2) {
				player.QuickSpawnItem(ModContent.ItemType<Items.Melee.TwoFacedAgony>());
			}
			if (gchoice == 3) {
				player.QuickSpawnItem(ModContent.ItemType<Items.Ranged.BoltSniper>()); 
			}
            }
			if(Main.rand.Next(100) < 10)
			{
				player.QuickSpawnItem(ModContent.ItemType<Items.Others.ThreeSpikes>());
			}
			if(Main.rand.Next(2) < 1)
			{
				player.QuickSpawnItem(ItemID.Cloud, Main.rand.Next(10, 30));
			}
			if(Main.rand.Next(2) < 1)
			{
				player.QuickSpawnItem(ItemID.RainCloud, Main.rand.Next(5, 15));
			}
			if(Main.rand.Next(100) < 10)
			{
				player.QuickSpawnItem(ModContent.ItemType<CloudBossTrophy>());
			}
		}

	}
}