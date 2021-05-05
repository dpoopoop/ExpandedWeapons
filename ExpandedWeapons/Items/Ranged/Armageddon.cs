using ExpandedWeapons.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace ExpandedWeapons.Items.Ranged
{
	public class Armageddon : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Uses rockets as ammo
Shoots a burst of 4 rockets");
		}

		public override void SetDefaults() {
			item.damage = 70; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 40; // hitbox width of the item
			item.height = 28; // hitbox height of the item
			item.useAnimation = 40;
			item.useTime = 10;
			item.reuseDelay = 30;
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 6; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 1000);
			item.rare = ItemRarityID.Yellow; // the color that the item's name will be in-game
			//item.UseSound = SoundID.Item11; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 134;
			item.shootSpeed = 14f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Rocket; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
		}
		public override void HoldItem(Player player)
        {
			DoubleBarrelShotgun.HoldItemSFX(player, item, 2, 11);
            foreach(Projectile projectile in Main.projectile)
            {
                Vector2 position = projectile.position + new Vector2(2, -4);
                if (projectile.active && projectile.owner == player.whoAmI && projectile.type == ModContent.ProjectileType<Betterstar>())
                {
                    Gore gore = Main.gore[Gore.NewGore(position, new Vector2(projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.05f), Main.rand.Next(16, 18), 0.1f)];
                    gore.velocity.Y += 2;
                    for (int i = 0; i < 2; i++)
                    {
                        Dust dust = Main.dust[Dust.NewDust(position, projectile.width, projectile.height, 57 + Main.rand.Next(2), projectile.velocity.X * 0.3f, projectile.velocity.Y * 0.3f, 150, default(Color), 0.3f)];
                        dust.velocity *= Main.rand.NextFloatDirection() * 0.5f;
                    }
                }
            }
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-40, 0);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SignalPistol>(), 1);
			recipe.AddIngredient(758, 1);
			recipe.AddIngredient(547, 20);
			recipe.AddIngredient(324, 1);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
