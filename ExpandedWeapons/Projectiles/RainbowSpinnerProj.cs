using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles     //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class RainbowSpinnerProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rainbow Spinner");
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {
           
            projectile.width = 160;     
            projectile.height = 160;      
            projectile.friendly = true;    
            projectile.penetrate = -1;    
            projectile.tileCollide = false; 
            projectile.ignoreWater = true;       
            projectile.melee = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(target.position, target.width, target.height, 114);
                dust.scale = 2f;
                dust.noGravity = true;
                Main.PlaySound(SoundID.Item, (int)target.Center.X, (int)target.Center.Y, 89);
            }

        }
        public override void AI()
        {

            
            //-------------------------------------------------------------Sound-------------------------------------------------------
            projectile.soundDelay--;
            if (projectile.soundDelay <= 0)
            {
                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 7);    
                projectile.soundDelay = 25;    
            }
            //-----------------------------------------------How the projectile works---------------------------------------------------------------------
            Player player = Main.player[projectile.owner];
            if (Main.myPlayer == projectile.owner)
            {
                if (!player.channel || player.noItems || player.CCed)
                {
                    projectile.Kill();
                }
            }
            Lighting.AddLight(projectile.Center, 1f, 0.5f, 0f);     //this is the projectile light color R, G, B (Red, Green, Blue)
            projectile.Center = player.MountedCenter;
            projectile.position.X += player.width / 2 * player.direction;
            
            projectile.spriteDirection = player.direction;
            
            projectile.rotation += 0.2f * player.direction; //this is the projectile rotation/spinning speed
           
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = projectile.rotation;

            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 114);  //this is the dust that this projectile will spawn
            Main.dust[dust].velocity /= 1f;
            Main.dust[dust].scale = 2f;
            Main.dust[dust].noGravity = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 8; //hit speed (how fast it attacks)
        }
    
         public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
         {
             Texture2D texture = Main.projectileTexture[projectile.type];
             spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
             Player player = Main.player[projectile.owner];

             return false;
         }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {          
        }
        public override Color? GetAlpha(Color lightColor)
        {
                Color color = Color.White;
                color.A = 75;
                return color;
        }
    }
}