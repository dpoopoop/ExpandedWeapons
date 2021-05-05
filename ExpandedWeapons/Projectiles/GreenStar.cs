using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class GreenStar : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Green Star");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(12);
			projectile.aiStyle = 71;
			aiType = 409;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.timeLeft = 180;
		}
		public override void AI()
		{
			projectile.alpha = 0;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			target.AddBuff(39, 5 * 60);
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
		}	
		public override bool PreKill(int timeLeft) {
			projectile.type = 12;
			return true;
		}
	}
}