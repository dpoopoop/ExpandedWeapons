using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles.Minions;
using ExpandedWeapons.Buffs;

namespace ExpandedWeapons.Items.Others
{
	public class CloudStar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cloud Star");
			Tooltip.SetDefault("Summons a cloud to defend you");
		}
	

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = mod.ProjectileType("CloudDefender");
			item.buffType = mod.BuffType("CloudPet");
			item.value = Item.sellPrice(silver: 500);
			item.rare = ItemRarityID.Pink;
			item.expert = true;
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}