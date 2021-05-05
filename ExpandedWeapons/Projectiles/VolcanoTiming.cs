using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.Projectiles
{
	public class VolcanoTiming : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Volcano Timing");
		}

		public override void SetDefaults()
		{
			projectile.width = 1;
			projectile.alpha = 255;
			projectile.height = 1;
			projectile.aiStyle = 0;
			projectile.friendly = false;
			projectile.melee = true;
			projectile.timeLeft = 20;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
		}
		public override void Kill(int timeLeft) 
		{
			Main.PlaySound(SoundID.Item14.WithVolume(.5f), (int)projectile.Center.X, (int)projectile.Center.Y);
			Player owner = Main.player[projectile.owner];
            int damage = projectile.damage; 
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("VolcanoExplosion"), damage, 10f, Main.myPlayer);
			Player player = Main.player[projectile.owner];
		}
	}
}