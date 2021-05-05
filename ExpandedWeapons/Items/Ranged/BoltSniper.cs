using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ModLoader;
using System;

namespace ExpandedWeapons.Items.Ranged
{
	public class BoltSniper : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Claudia Gun");
			Tooltip.SetDefault(@"A sniper that shoots really fast.
'I would like to, chug jug with you'");
		}

		public override void SetDefaults() {
			item.damage = 170; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.width = 76; // hitbox width of the item
			item.height = 32; // hitbox height of the item
			item.useTime = 14; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 14; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 1800); // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Cyan; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item38; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 10; 
			item.shootSpeed = 25f; // the speed of the projectile (measured in pixels per frame)
			item.ranged = true;
			item.crit = 26;
			item.useAmmo = AmmoID.Bullet;
		}
		 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.BulletHighVelocity;
			}
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 60f; //This gets the direction of the flame projectile, makes its length to 1 by normalizing it. It then multiplies it by 54 (the item width) to get the position of the tip of the flamethrower.
			if (Collision.CanHit(position, 6, 6, position + muzzleOffset, 6, 6))
			{
				position += muzzleOffset;
			}
			return true;
        }
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
	}
}