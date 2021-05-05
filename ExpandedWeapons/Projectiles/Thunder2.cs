using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class Thunder2 : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Thunder 2");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(239);
			aiType = 239;
			projectile.width = 32;
			projectile.height = 128;
			projectile.light = 1f;
			projectile.timeLeft = 10;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}
		public override void AI()
		{
			projectile.alpha = 0;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
		}	
		public override bool PreKill(int timeLeft) {
			projectile.type = 239;
			return true;
		}
	}
}