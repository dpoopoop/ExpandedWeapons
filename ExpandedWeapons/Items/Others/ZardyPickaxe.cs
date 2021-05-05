using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Items.Others;

namespace ExpandedWeapons.Items.Others
{
	public class ZardyPickaxe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Its a microphone pickaxe'");
		}

		public override void SetDefaults() {
			item.damage = 25;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 1;
			item.useAnimation = 20;
			item.pick = 100;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4;
			item.value = Item.sellPrice(silver: 200);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.tileBoost += 5;
			item.useTurn = true;
		}
	}
}