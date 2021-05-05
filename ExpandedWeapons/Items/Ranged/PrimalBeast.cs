using ExpandedWeapons.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace ExpandedWeapons.Items.Ranged
{
	public class PrimalBeast : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Uses rockets as ammo"
			+
			"\nShoots a massive spread of fireballs"
			+
			"\nDirect hits do more damage");
		}

		public override void SetDefaults() {
			item.damage = 90; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 40; // hitbox width of the item
			item.height = 28; // hitbox height of the item
			item.useAnimation = 35;
			item.useTime = 35;
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 6; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 1500);
			item.rare = ItemRarityID.Red; // the color that the item's name will be in-game
			item.UseSound = SoundID.DD2_FlameburstTowerShot; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 134;
			item.shootSpeed = 18f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Rocket; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
			item.crit = 11;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == 134 || type == 137 || type == 137 || type == 140 || type == 143) // or ProjectileID.WoodenArrowFriendly
			{
				type = ModContent.ProjectileType<PrimalBall>();
			}
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			int numberProjectiles = 5; // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 shotgunSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				shotgunSpeed = shotgunSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, shotgunSpeed.X, shotgunSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return true to allow tmodloader to call Projectile.NewProjectile as normal
		}
		public override void HoldItem(Player player)
        {
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
			return new Vector2(-5, 0);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DoubleDragon>(), 1);
			recipe.AddIngredient(ModContent.ItemType<BurstingFlames>(), 1);
			recipe.AddIngredient(3458, 15);
			recipe.AddIngredient(154, 50);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
