using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class Oreorang : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Have a cookie!'");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 14f;
			item.damage = 140;
			item.knockBack = 6f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.useTime = 15;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Cyan;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 1000);
			item.shoot = ModContent.ProjectileType<OreorangProj>();
		}
	}
}