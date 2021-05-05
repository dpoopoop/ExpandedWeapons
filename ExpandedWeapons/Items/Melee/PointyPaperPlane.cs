using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class PointyPaperPlane : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("5 duration damage");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 13f;
			item.damage = 80;
			item.knockBack = 4.5f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 24;
			item.useTime = 24;
			item.width = 33;
			item.height = 33;
			item.rare = ItemRarityID.LightRed;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 500);
			item.shoot = ModContent.ProjectileType<PointyPaperPlaneProj>();
		}
	}
}