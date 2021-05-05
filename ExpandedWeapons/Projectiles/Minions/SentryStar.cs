using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;
using ExpandedWeapons.Projectiles.Minions;
 
namespace ExpandedWeapons.Projectiles.Minions
{
	internal class SentryStar : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sentry Star"); //The english name of the projectile
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}
		public override void SetDefaults()
		{
			projectile.width = 64;
			projectile.height = 64;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.minion = true;
			projectile.sentry = true; //Sets the weapon as a sentry for sentry accessories to properly work.
			projectile.timeLeft = Projectile.SentryLifeTime;
			projectile.ignoreWater = true; //If this is set to false, the projectile will be slowed in water.
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}

		public override void AI()
		{
			//This AI will function as a static sentry, and will not move. If you would like to know how to do more advanced minion AI, check out PurityWisp.cs.
			for (int k = 0; k < 1; k++) {
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 111, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
				Main.dust[dust].noGravity = true; //Disable the dust gravity.
				Main.dust[dust].velocity *= 0.8f; //Dust velocity.
			}
			projectile.rotation += 0.025f;
			int SentryRange = 65; //The sentry's range
			int Speed = 16; //Fire rate
			float FireVelocity = 3.5f; //The velocity the sentry's shot projectile will travel. Slows down the closer the NPC is.


			Main.player[projectile.owner].UpdateMaxTurrets(); //This makes the sentry be able to spawn more if your sentry cap is greater than one.
			for (int t = 0; t < Main.maxNPCs; t++) {
				NPC npc = Main.npc[t];

				float distance = projectile.Distance(npc.Center); //Set the distance from the NPC and the sentry projectile.

				//Convert distance to tile position, and continue if the following NPC parameters are met.
				if (distance / 16 < SentryRange && Main.npc[t].active && !Main.npc[t].dontTakeDamage && !Main.npc[t].friendly && Main.npc[t].lifeMax > 5 && Main.npc[t].type != NPCID.TargetDummy) {
					projectile.ai[1] = npc.whoAmI;
				}
			}

			NPC target = Main.npc[(int)projectile.ai[1]] ?? new NPC();

			projectile.ai[0]++;
			if (target.active && projectile.Distance(target.Center) / 16 < SentryRange && projectile.ai[0] % Speed == 5) {

				Vector2 direction = target.Center - projectile.Center; //The direction the projectile will fire.

				direction.Normalize(); //Normalizes the direction vector.
				direction.X *= FireVelocity; //Multiply direction by fireVelocity so the sentry can fire the projectile faster the farther the NPC is away.
				direction.Y *= FireVelocity; //Same as above, but with Y velocity.

				Main.PlaySound(SoundID.Item, projectile.Center, 9); //Play a sound.

				int damage = projectile.damage; //How much damage the projectile shot from the sentry will do.
				int type =  mod.ProjectileType("StarBeam"); //The type of projectile the sentry will shoot. Use ModContent.ProjectileType<>() to fire a modded projectile.
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, direction.X, direction.Y, type, damage, 6f, projectile.owner);
			}
		}
	}
} 
 
        
