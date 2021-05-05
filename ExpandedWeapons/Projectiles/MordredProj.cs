using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace ExpandedWeapons.Projectiles
{
	internal class MordredProj : ModProjectile
	{

		public override void SetDefaults() {
			projectile.width = 16;               //The width of projectile hitbox
			projectile.height = 16;              //The height of projectile hitbox
			projectile.aiStyle = 0;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.magic = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = -1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 180;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			projectile.light = 0.5f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = false;          //Can the projectile collide with tiles?
			projectile.extraUpdates = 2;     
		}
		public override void AI()
        {
            Vector2 center10 = projectile.Center;
            projectile.scale = 1f - projectile.localAI[0];
            projectile.width = (int)(20f * projectile.scale);
            projectile.height = projectile.width;
            projectile.position.X = center10.X - (float)(projectile.width / 2);
            projectile.position.Y = center10.Y - (float)(projectile.height / 2);
            if ((double)projectile.localAI[0] < 0.1)
            {
            projectile.localAI[0] += 0.01f;
            }
            else
            {
            projectile.localAI[0] += 0.025f;
            }
            if (projectile.localAI[0] >= 0.95f)
            {
            projectile.Kill();
            }
           
            projectile.velocity.X = projectile.velocity.X + projectile.ai[0] * 1.5f;
            projectile.velocity.Y = projectile.velocity.Y + Main.rand.Next(-1, 2) + projectile.ai[1] * 1.5f;
            if (projectile.velocity.Length() > 16f)
                {
                projectile.velocity.Normalize();
                projectile.velocity *= 16f;
                }
            projectile.ai[0] *= 1.05f;
            projectile.ai[1] *= 1.05f;
            if (projectile.scale < 1f)
            {
                int num892 = 0;
                while ((float)num892 < projectile.scale * 10f)
                {
                    int num893 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 169, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f);
                    Main.dust[num893].position = (Main.dust[num893].position + projectile.Center) / 2f;
                    Main.dust[num893].noGravity = true;
                    Dust dust = Main.dust[num893];
                    dust.velocity *= 0.1f;
                    dust = Main.dust[num893];
                    dust.velocity -=projectile.velocity * (1.1f - projectile.scale);
                    Main.dust[num893].fadeIn = (float)(100 + projectile.owner);
                    dust = Main.dust[num893];
                    dust.scale += projectile.scale * 0.75f;
                    int num3 = num892;
                    num892 = num3 + 1;
                }
                return;
            }
        }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(24, 10 * 60);
            target.AddBuff(69, 10 * 60);
			target.immune[projectile.owner] = 5;
		}
	}
}