using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class Constar : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Con Star");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(12);
			aiType = 12;
			projectile.width = 44;
			projectile.height = 44;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.timeLeft = 120;
		}
		public override void AI()
		{
			if(projectile.timeLeft % 5 == 0)
            {
			int damage = projectile.damage;
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("Fallstar"), damage, 1f, Main.myPlayer);
			}
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