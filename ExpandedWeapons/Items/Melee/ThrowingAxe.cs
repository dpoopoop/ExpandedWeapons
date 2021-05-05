using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class ThrowingAxe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'You can't chop tree with this'");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 12f;
			item.damage = 13;
			item.knockBack = 5f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 20;
			item.useTime = 20;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Blue;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 50);
			item.shoot = ModContent.ProjectileType<ThrowingAxeProj>();
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
            recipe.AddIngredient(9, 30);
            recipe.AddIngredient(22, 15);
			recipe.anyIronBar = true;
            recipe.anyWood = true;
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}