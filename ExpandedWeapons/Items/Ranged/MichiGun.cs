using ExpandedWeapons.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace ExpandedWeapons.Items.Ranged
{
	public class MichiGun : ModItem
	{
		public int spikeCooldown;

		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"30% chance to not consume ammo.
△△△");
		}

		public override void SetDefaults() {
			item.damage = 30; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 70; // hitbox width of the item
			item.height = 32; // hitbox height of the item
			item.useTime = 8; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 8; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(platinum: 1);
			item.rare = ItemRarityID.Purple; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item40; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ModContent.ProjectileType<MichiBolt>();; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 10f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
			item.crit = 9;
		}
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .3f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			spikeCooldown += 1;
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			if (spikeCooldown == 1)
			{
				Main.PlaySound(SoundID.Item92);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<WaveMichi>(), damage, knockBack, player.whoAmI);
			}
			if (spikeCooldown == 2)
			{
				Main.PlaySound(SoundID.Item92);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<WaveMichi>(), damage, knockBack, player.whoAmI);
			}
			if (spikeCooldown == 3)
			{
				Main.PlaySound(SoundID.Item92);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<WaveMichi>(), damage, knockBack, player.whoAmI);
			}
			float numberProjectiles = 3; // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			if (spikeCooldown == 4)
			{
				Main.PlaySound(SoundID.Item73);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<SmallSpike>(), damage * 12, knockBack, player.whoAmI);
			}
			}
			if (spikeCooldown == 5)
			{
				Main.PlaySound(SoundID.Item73);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<SmallSpike>(), damage * 12, knockBack, player.whoAmI);
			}
			}
			if (spikeCooldown == 6)
			{
				Main.PlaySound(SoundID.Item73);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<SmallSpike>(), damage * 12, knockBack, player.whoAmI);
			}
			}
			if (type == ProjectileID.Bullet)
			{
				type = ModContent.ProjectileType<MichiBolt>();
			}
			int projectileCount = 1;
            float startRadius = 35f; 
            float spread = (float)Math.PI / 18f; 
            Vector2 direction = Vector2.Normalize(new Vector2(speedX, speedY));
            direction *= startRadius;
			if (spikeCooldown == 7)
			{
            for (int i = 0; i < projectileCount; i++)
            {
				Main.PlaySound(SoundID.Item72);
                float angleStep = (float)(i - (projectileCount - 1)) / 2f;
                Vector2 firePosition = direction.RotatedBy(angleStep * spread - 40);
                Projectile.NewProjectile(position.X + firePosition.X, position.Y + firePosition.Y, speedX, speedY, ModContent.ProjectileType<Spike>(), damage * 8, knockBack, player.whoAmI);

			}
            for (int i = 0; i < projectileCount; i++)
            {
                float angleStep = (float)(i - (projectileCount - 1)) / 2f;
                Vector2 firePosition = direction.RotatedBy(angleStep * spread + 40);
                Projectile.NewProjectile(position.X + firePosition.X, position.Y + firePosition.Y, speedX, speedY, ModContent.ProjectileType<Spike>(), damage * 8, knockBack, player.whoAmI);

            }
			for (int i = 0; i < projectileCount; i++)
            {
                float angleStep = (float)(i - (projectileCount - 1)) / 2f;
                Vector2 firePosition = direction.RotatedBy(angleStep * spread);
                Projectile.NewProjectile(position.X + firePosition.X, position.Y + firePosition.Y, speedX, speedY, ModContent.ProjectileType<Spike>(), damage * 8, knockBack, player.whoAmI);

            }
			}
			if (spikeCooldown == 8)
			{
				Main.PlaySound(SoundID.Item72);
            for (int i = 0; i < projectileCount; i++)
            {
                float angleStep = (float)(i - (projectileCount - 1)) / 2f;
                Vector2 firePosition = direction.RotatedBy(angleStep * spread - 40);
                Projectile.NewProjectile(position.X + firePosition.X, position.Y + firePosition.Y, speedX, speedY, ModContent.ProjectileType<Spike>(), damage * 8, knockBack, player.whoAmI);

			}
            for (int i = 0; i < projectileCount; i++)
            {
                float angleStep = (float)(i - (projectileCount - 1)) / 2f;
                Vector2 firePosition = direction.RotatedBy(angleStep * spread + 40);
                Projectile.NewProjectile(position.X + firePosition.X, position.Y + firePosition.Y, speedX, speedY, ModContent.ProjectileType<Spike>(), damage * 8, knockBack, player.whoAmI);

            }
			for (int i = 0; i < projectileCount; i++)
            {
                float angleStep = (float)(i - (projectileCount - 1)) / 2f;
                Vector2 firePosition = direction.RotatedBy(angleStep * spread);
                Projectile.NewProjectile(position.X + firePosition.X, position.Y + firePosition.Y, speedX, speedY, ModContent.ProjectileType<Spike>(), damage * 8, knockBack, player.whoAmI);
            }
			}
			if (spikeCooldown == 9)
			{
				Main.PlaySound(SoundID.Item72);
            for (int i = 0; i < projectileCount; i++)
            {
                float angleStep = (float)(i - (projectileCount - 1)) / 2f;
                Vector2 firePosition = direction.RotatedBy(angleStep * spread - 40);
                Projectile.NewProjectile(position.X + firePosition.X, position.Y + firePosition.Y, speedX, speedY, ModContent.ProjectileType<Spike>(), damage * 8, knockBack, player.whoAmI);
			}
            for (int i = 0; i < projectileCount; i++)
            {
                float angleStep = (float)(i - (projectileCount - 1)) / 2f;
                Vector2 firePosition = direction.RotatedBy(angleStep * spread + 40);
                Projectile.NewProjectile(position.X + firePosition.X, position.Y + firePosition.Y, speedX, speedY, ModContent.ProjectileType<Spike>(), damage * 8, knockBack, player.whoAmI);
            }
			for (int i = 0; i < projectileCount; i++)
            {
                float angleStep = (float)(i - (projectileCount - 1)) / 2f;
                Vector2 firePosition = direction.RotatedBy(angleStep * spread);
                Projectile.NewProjectile(position.X + firePosition.X, position.Y + firePosition.Y, speedX, speedY, ModContent.ProjectileType<Spike>(), damage * 8, knockBack, player.whoAmI);
            }
			spikeCooldown = 0;
			}
			return true;
		}
	}
}