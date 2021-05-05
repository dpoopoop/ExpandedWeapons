using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Magic
{
	public class FriendlyProbe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Shoots a probe that shoots lasers at nearby enemies
'It wants to be your friend'");
		}

		public override void SetDefaults() {
			item.damage = 40;
			item.mana = 11;
			item.width = 32;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.magic = true;
			item.value = Item.sellPrice(silver: 500);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item33;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<FriendlyProbeProj>();
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
            recipe.AddIngredient(1225, 15);
			recipe.AddIngredient(22, 15);
			recipe.AddIngredient(548, 20);
			recipe.anyIronBar = true;
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}