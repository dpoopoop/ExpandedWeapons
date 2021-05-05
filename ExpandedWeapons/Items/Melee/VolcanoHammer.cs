using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.Items.Melee
{
	public class VolcanoHammer : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Smash the ground!'");
		}
		public override void SetDefaults() {
			item.damage = 300;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 10f;
			item.value = Item.sellPrice(silver: 3000);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item116;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<VolcanoTiming>();
			item.shootSpeed = 0f;
		}

	}
}