using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.Projectiles
{	
	public class DashTrail : ModProjectile 
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dash Trail"); 
		}

		public override void SetDefaults()
		{
			projectile.width = 38; 
			projectile.height = 38; 
			projectile.timeLeft = 300; 
			projectile.penetrate = -1; 
			projectile.friendly = false; 
			projectile.hostile = true; 
			projectile.tileCollide = false; 
			projectile.ignoreWater = true; 
			projectile.aiStyle = 0; 
			projectile.alpha = 128;
		}
		public override void AI()
        {
            projectile.rotation += (float)projectile.direction * 0.05f;
		}
    
	}
}