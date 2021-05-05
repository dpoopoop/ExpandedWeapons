using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class Fallstar : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Fall Star");
		}

		public override void SetDefaults() {
			projectile.width = 22; 
			projectile.height = 22;
			projectile.friendly = true;
			projectile.aiStyle = 1;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.timeLeft = 300;
			projectile.light = 1f;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
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
			projectile.type = 12;
			return true;
		}
	}
}