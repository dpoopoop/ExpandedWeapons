using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.Projectiles
{
	public class Snowfall : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Snowfall");     //The English name of the projectile
		}

		public override void SetDefaults() 
		{
			projectile.width = 9;               //The width of projectile hitbox
			projectile.height = 9;              //The height of projectile hitbox
			projectile.aiStyle = 45;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.magic = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 180;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			projectile.light = 1f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;          //Can the projectile collide with tiles?
			projectile.extraUpdates = 0;            //Set to above 0 if you want the projectile to update multiple time in a frame
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)       
        {
            target.AddBuff(44, 5 * 60);
		}
	}
}