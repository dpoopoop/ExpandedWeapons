using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Magic
{
	public class ArrowPad : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Shoots a dance pad that shoots arrows at nearby enemies
'This weapon will make the enemies go ballistic'");
		}

		public override void SetDefaults() {
			item.damage = 36;
			item.mana = 10;
			item.width = 32;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3;
			item.magic = true;
			item.value = Item.sellPrice(silver: 300);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item85;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<ArrowPadProj>();
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
            recipe.AddIngredient(502, 20);
			recipe.AddIngredient(22, 30);
			recipe.anyIronBar = true;
			recipe.AddIngredient(179, 5);
			recipe.AddIngredient(178, 5);
			recipe.AddIngredient(177, 5);
			recipe.AddIngredient(181, 5);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}