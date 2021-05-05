using Microsoft.Xna.Framework;
using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class AmazingSword : ModItem
	{
		public int eamCycle;
		bool OnlyShootOnSwing = true;

		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Its a cool sword'");
		}

		public override void SetDefaults() {
			item.damage = 350;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 19;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 3000);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item60;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<PurpleBolt>();
			item.shootSpeed = 10f;
			item.crit = 6;
		}
			public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		    {
		    eamCycle += 1;
			if (eamCycle >= 1)
			{
				item.shoot = ModContent.ProjectileType<BlueBolt>();
			}
			if (eamCycle >= 2)
			{
				item.shoot = ModContent.ProjectileType<PurpleBolt>();
			}
			if (eamCycle >= 3)
			{
				item.shoot = ModContent.ProjectileType<PinkBolt>();
				eamCycle = 0;
			}
			return true;
		}
		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<TwoFacedAgony>(), 1);
			recipe.AddIngredient(1570, 1);
			recipe.AddIngredient(3457, 10);
			recipe.AddIngredient(3459, 10);
			recipe.AddIngredient(3111, 30);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}