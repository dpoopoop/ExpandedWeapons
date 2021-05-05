using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Items.Magic;

namespace ExpandedWeapons.Projectiles
{
    class CursedRainMoving : ModProjectile
    {
        public Vector2 CursorPosition { get; set; } = new Vector2(0, 0);

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Rain Moving");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 24; //hitbox width in pixels.
            projectile.height = 24; //hitbox height in pixels.
            projectile.aiStyle = 0; //not affected by gravity.
            projectile.friendly = false;
            projectile.magic = true; //does summon damage.
            projectile.penetrate = -1; //the amount of enemies it can hit.
            projectile.timeLeft = 3600; //lasts for 300 ticks (5 seconds)
            projectile.light = 0.5f; //emits light.
            projectile.alpha = 0; //the projectile is invisible.
            projectile.tileCollide = true; //dies when it hits a tile.
            projectile.extraUpdates = 0; //the higher the number, the faster your projectile will move.
        }

        public override void AI()
        {
            #region Select Frame
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
            #endregion
            #region Velocity To Cursor
            if (Main.myPlayer == projectile.owner)
            {
                float maxDistance = 18f;
                Vector2 vectorToCursor = CursorPosition - projectile.Center;
                float distanceToCursor = vectorToCursor.Length();

                if (distanceToCursor > maxDistance)
                {
                    distanceToCursor = maxDistance / distanceToCursor;
                    vectorToCursor *= distanceToCursor;
                }

                projectile.velocity = vectorToCursor;
            }
            #endregion
            if (projectile.velocity == Vector2.Zero)
			{
				projectile.Kill();
			}
        }

        public override void Kill(int timeLeft)
        {
            int damage = projectile.damage;
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("CursedRainCloud"), damage, 0f, Main.myPlayer, 0f, 0f);
            base.Kill(timeLeft);
        }
    }
}