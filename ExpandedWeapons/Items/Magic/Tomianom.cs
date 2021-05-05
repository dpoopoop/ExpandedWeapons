using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace ExpandedWeapons.Items.Magic
{
	public class Tomianom : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Shoots an overpowered ball that zaps nearby enemies
'ITS HUGE!'");
		}

		public override void SetDefaults() {
			item.damage = 100;
			item.mana = 18;
			item.width = 79;
			item.height = 39;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 7;
			item.magic = true;
			item.value = Item.sellPrice(silver: 2000);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item94;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<OpBallProj>();
			item.shootSpeed = 1.25f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-30, 0);
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 55f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
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
            recipe.AddIngredient(2796, 1);
			recipe.AddIngredient(1266, 1);
			recipe.AddIngredient(3456, 10);
			recipe.AddIngredient(3457, 10);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}