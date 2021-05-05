using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class RainSpike : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rain Spike");
		}

		public override void SetDefaults() {
			projectile.width = 30; 
            projectile.height = 30;
			projectile.aiStyle = 5; 
			aiType = 503;
			projectile.penetrate = 1;
			projectile.minion = true;
			projectile.timeLeft = 300;
			projectile.friendly  = true;
		}
			public override void AI()
        {
			projectile.alpha = 0;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			target.AddBuff(ModContent.BuffType<Buffs.Pointy>(), 5 * 60);
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
		}
	}
}