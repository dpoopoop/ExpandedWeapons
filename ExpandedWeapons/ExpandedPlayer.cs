using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Localization;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons
{
	// This is the ModPlayer class. Make note of the classname, which is whipplayer, since we will be using this in the accessory item below.
	public class ExpandedPlayer : ModPlayer
	{
		public int summonTagDamage;
        public int summonTagCrit;
		// Here we declare the overheadminion variable which will represent whether this player has the effect or not.
		public bool overheadMinion;
		public bool cloudPet = false;
        public bool magicPet = false;
        public bool summonPet = false;
        public bool coritePet = false;
		public bool SpikeRain = false;
        public bool FrostBurnMelee;
        public bool VenomMelee;
        public bool StardustMelee;
        public bool attackPointy;
        public bool attackDay;
		private const int saveVersion = 0;

		// ResetEffects is used to reset effects back to their default value. Terraria resets all effects every frame back to defaults so we will follow this design. (You might think to set a variable when an item is equipped and unassign the value when the item in unequipped, but Terraria is not designed that way.)
		public override void ResetEffects() {
			overheadMinion = false;
			cloudPet = false;
            magicPet = false;
            summonPet = false;
            coritePet = false;
			SpikeRain = false;
            FrostBurnMelee = false;
            VenomMelee = false;
            StardustMelee = false;
            attackPointy = false;
            attackDay = false;
		}
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) {
			// frostBurnSummon, as its name suggests, applies frostBurn to enemy NPC but only for Summon projectiles.
			// In this if statement we check several conditions. We first check to make sure the projectile that hit the NPC is either a minion projectile or a projectile that minions shoot.
			// We then check that frostBurnSummon is set to true. The last check for not noEnchantments is because some projectiles don't allow enchantments and we want to honor that restriction.
			if ((proj.melee) && FrostBurnMelee) {
				// If all those checks pass, we apply FrostBurn for some random duration.
				target.AddBuff(BuffID.Frostburn, 60 * 5);
			}
            if ((proj.melee) && VenomMelee) {
				// If all those checks pass, we apply FrostBurn for some random duration.
				target.AddBuff(70, 60 * 5);
			}
            if ((proj.melee) && StardustMelee) {
				// If all those checks pass, we apply FrostBurn for some random duration.
				target.AddBuff(BuffID.Frostburn, 60 * 5);
                target.AddBuff(204, 60 * 5);
			}
            if (attackPointy) {
				// If all those checks pass, we apply FrostBurn for some random duration.
				target.AddBuff(ModContent.BuffType<Buffs.Pointy>(), 5 * 60);
			}
            if ((proj.melee) && attackDay) {
				// If all those checks pass, we apply FrostBurn for some random duration.
				target.AddBuff(189, 15 * 60);
			}
		}
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (SpikeRain == true)
            {
                float spread = 75f * 0.0174f;
                double deltaAngle = spread / 8f;
                double offsetAngle;
                int i;
                for (i = 0; i < 4; i++)
                {
                    offsetAngle = (deltaAngle * (i + i * i) / 2f) + 32f * i;
                    Terraria.Projectile.NewProjectile(player.position.X,player.position.Y - Main.rand.Next(400, 500), (float)Main.rand.Next(-10, 10), (float)(Math.Cos(offsetAngle) + 20),mod.ProjectileType("RainSpike"), 100, 1, player.whoAmI, 0);
                    Terraria.Projectile.NewProjectile(player.position.X, player.position.Y - Main.rand.Next(400, 500), (float)Main.rand.Next(-10, 10), (float)(-Math.Cos(offsetAngle) + 20), mod.ProjectileType("RainSpike"), 100, 1, player.whoAmI, 0);
                }
            }
        }
		public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (player.HasBuff(ModContent.BuffType<Buffs.Tag>()))
            {
            if ((proj.minion || ProjectileID.Sets.MinionShot[proj.type]) && target.whoAmI == player.MinionAttackTargetNPC) 
            { 
                damage += summonTagDamage; 
            }
            }
            if (player.HasBuff(ModContent.BuffType<Buffs.Crit>()))
            {
            if (summonTagCrit > 0) 
            { 
            if (Main.rand.Next(1, 101) < summonTagCrit) 
            { 
                crit = true; 
            } 
            } 
            }
        }
	}
}