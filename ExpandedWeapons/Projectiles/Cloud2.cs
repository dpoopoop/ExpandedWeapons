using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.Projectiles
{	
	public class Cloud2 : ModProjectile 
	{
		public bool diagonalBeam = false;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cloud 2"); 
			Main.projFrames[projectile.type] = 5;
		}

		public override void SetDefaults()
		{
			projectile.width = 24; 
			projectile.height = 24; 
			projectile.timeLeft = 300; 
			projectile.penetrate = -1; 
			projectile.friendly = false; 
			projectile.hostile = true; 
			projectile.tileCollide = false; 
			projectile.ignoreWater = true; 
			projectile.aiStyle = 0; 
		}
		
		public override void AI()
        {
			if (++projectile.frameCounter >= 6) 
            {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 5) 
                {
					projectile.frame = 0;
				}
			}
            projectile.rotation += (float)projectile.direction * 0.2f;
			int damage = projectile.damage;
			int type = 128;
			if(projectile.timeLeft % 45 == 0)
            {
				if (diagonalBeam)
				{
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -5, -5, type, damage * 3, 0f, Main.myPlayer);
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 5, -5, type, damage * 3, 0f, Main.myPlayer);
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -5, 5, type, damage * 3, 0f, Main.myPlayer);
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 5, 5, type, damage * 3, 0f, Main.myPlayer);
				diagonalBeam = false;
				}
				else
				{
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 5, 0, type, damage * 3, 0f, Main.myPlayer);
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -5, 0, type, damage * 3, 0f, Main.myPlayer);
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 5, type, damage * 3, 0f, Main.myPlayer);
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, -5, type, damage * 3, 0f, Main.myPlayer);
					diagonalBeam = true;	
				}
            }
        }
    
	}
}