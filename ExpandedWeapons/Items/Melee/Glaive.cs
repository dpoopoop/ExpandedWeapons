using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class Glaive : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Great for slicing through balloons'");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 12f;
			item.damage = 32;
			item.knockBack = 6f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.useTime = 15;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Green;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 100);
			item.shoot = ModContent.ProjectileType<GlaiveProj>();
		}
		public override bool CanUseItem(Player player)       //this make that you can shoot only 1 boomerang at once
        {
            for (int i = 0; i < 1000; ++i) //number of boomerangs at once minus 1
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(154, 50);
            recipe.AddIngredient(22, 20);
			recipe.anyIronBar = true;
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}