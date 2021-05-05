using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Magic
{
	public class MartianRemote : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Shoots a UFO that shoots beams at nearby enemies
'There is 2 martians among us'");
		}

		public override void SetDefaults() {
			item.damage = 75;
			item.mana = 16;
			item.width = 32;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 6;
			item.magic = true;
			item.value = Item.sellPrice(silver: 1600);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item90;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<UfoProj>();
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
            recipe.AddIngredient(2769, 1);
			recipe.AddIngredient(2771, 1);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}