using ExpandedWeapons.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace ExpandedWeapons.Items.Ranged
{
	public class ConstellationCannon : ModItem
	{
		public int superstarCooldown;
		public int starCycle;
		
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"65% chance to not consume ammo.
'Spectacular!'");
		}

		public override void SetDefaults() {
			item.damage = 125; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 78; // hitbox width of the item
			item.height = 26; // hitbox height of the item
			item.useTime = 7; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 7; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 4000);
			item.rare = ItemRarityID.Purple; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item36; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ModContent.ProjectileType<Betterstar>();
			item.shootSpeed = 20f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.FallenStar; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
		    starCycle += 1;
			if (starCycle >= 1)
			{
				item.shoot = ModContent.ProjectileType<RedStar>(); //exploding star
			}
			if (starCycle >= 2)
			{
				item.shoot = ModContent.ProjectileType<OrangeStar>(); //Xcut star
			}
			if (starCycle >= 3)
			{
				item.shoot = ModContent.ProjectileType<Betterstar>(); //regular
			}
			if (starCycle >= 4)
			{
				item.shoot = ModContent.ProjectileType<GreenStar>(); //homing star
			}
			if (starCycle >= 5)
			{
				item.shoot = ModContent.ProjectileType<BlueStar>(); //pipershot star
				starCycle = 0;
			}
			superstarCooldown += 10;
			if (superstarCooldown >= 100)
			{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Constar>(), damage + 50, knockBack, player.whoAmI);
			superstarCooldown = 0;
			Main.PlaySound(SoundID.Item14);
			}
			return true;
		
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
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .65f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<StardustShooter>(), 1);
			recipe.AddIngredient(75, 30); //fallen star
			recipe.AddIngredient(324, 1);
			recipe.AddIngredient(3467, 15);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
