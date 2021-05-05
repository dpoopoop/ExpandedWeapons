using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class SolarFlarestorm : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault(@"25 duration damage.
'This melee weapon magically summons ranged projectiles'");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 16f;
			item.damage = 150;
			item.knockBack = 7f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 20;
			item.useTime = 20;
			item.width = 33;
			item.height = 33;
			item.rare = ItemRarityID.Red;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 3000);
			item.shoot = ModContent.ProjectileType<SolarFlarestormProj>();
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3542);
            recipe.AddIngredient(3543);
            recipe.AddIngredient(899);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}