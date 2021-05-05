using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class Sniperstar : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sniper Star");
		}
		public override void SetDefaults() {
			projectile.CloneDefaults(12);
			aiType = 12;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.timeLeft = 300;
		}
		public override void AI()
		{
			projectile.alpha = 0;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {		
				Projectile.NewProjectile(target.position.X + 36, target.position.Y - 38, -8, 12, ModContent.ProjectileType<SniperBolt>(), damage, 1f, projectile.owner, 0f, 1f);
				Projectile.NewProjectile(target.position.X - 36, target.position.Y - 38, 8, 12, ModContent.ProjectileType<SniperBolt>(), damage, 1f, projectile.owner, 0f, 1f);
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