using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Magic
{
	public class SunflowerSeedler : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Shoots a sunflower that shoots sunflower seeds at nearby enemies
'Pop one out and keep shooting your main weapon!'");
		}

		public override void SetDefaults() {
			item.damage = 10;
			item.mana = 8;
			item.width = 32;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.magic = true;
			item.value = Item.sellPrice(silver: 100);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item17;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<SunflowerSeedlerProj>();
			item.shootSpeed = 1.25f;
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int l = 0; l < Main.projectile.Length; l++)
            {                                                                  
                Projectile proj = Main.projectile[l];
                if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
            }
            return true;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(63, 5);
			recipe.AddIngredient(1727, 50);
			recipe.AddIngredient(307, 8);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}