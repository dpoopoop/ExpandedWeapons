using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Magic
{
	public class FighterJetRemote : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Shoots a fighter jet that shoots a lot of bullets at nearby enemies
'Magic bullets?'");
		}

		public override void SetDefaults() {
			item.damage = 52;
			item.mana = 14;
			item.width = 32;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.magic = true;
			item.value = Item.sellPrice(silver: 1000);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item15;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<FighterJetProj>();
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
            recipe.AddIngredient(1552, 10);
			recipe.AddIngredient(575, 20);
			recipe.AddIngredient(236, 1);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}