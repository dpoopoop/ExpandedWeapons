using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ExpandedWeapons.Items;
using ExpandedWeapons.Items.Ranged;
using ExpandedWeapons.NPCs;
using ExpandedWeapons.Buffs;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.NPCs
{
	public class SummonGunNPC : GlobalNPC
    {
    public override bool InstancePerEntity => true;
	public bool gunStinger;
	public bool gunMeteor;
	public bool gunSoul;
	public bool gunBlood;
	public bool gunMech;
	public bool gunPlantera;
	public bool gunLeech;
	public bool gunThief;

	public override void ResetEffects(NPC npc) {
		gunStinger = false;
		gunMeteor = false;
		gunSoul = false;
		gunBlood = false;
		gunMech = false;
		gunPlantera = false;
		gunLeech = false;
		gunThief = false;
		}
		public override void UpdateLifeRegen(NPC npc, ref int damage) 
		{
			if (gunStinger) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int stingerCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<StingerGunProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						stingerCount++;
					}
				}
				npc.lifeRegen -= stingerCount * 2 * 8;
				if (damage < stingerCount * 4) 
				{
					damage = stingerCount * 4;
				}
			}
			if (gunMeteor) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int meteorCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<MeteorLauncherProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						meteorCount++;
					}
				}
				npc.lifeRegen -= meteorCount * 2 * 10;
				if (damage < meteorCount * 5) 
				{
					damage = meteorCount * 5;
				}
			}
			if (gunSoul) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int soulCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<SoulEaterGunProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						soulCount++;
					}
				}
				npc.lifeRegen -= soulCount * 2 * 20;
				if (damage < soulCount * 10) 
				{
					damage = soulCount * 10;
				}
			}
			if (gunBlood) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int bloodCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<CrimeraGunProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						bloodCount++;
					}
				}
				npc.lifeRegen -= bloodCount * 2 * 20;
				if (damage < bloodCount * 10) 
				{
					damage = bloodCount * 10;
				}
			}
			if (gunMech) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int mechCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<MechwormShooterProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						mechCount++;
					}
				}
				npc.lifeRegen -= mechCount * 2 * 32;
				if (damage < mechCount * 16) 
				{
					damage = mechCount * 16;
				}
			}
			if (gunPlantera) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int planteraCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<MiniPlanteraProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						planteraCount++;
					}
				}
				npc.lifeRegen -= planteraCount * 2 * 48;
				if (damage < planteraCount * 24) 
				{
					damage = planteraCount * 24;
				}
			}
			if (gunLeech) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int leechCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<LeechShooterProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						leechCount++;
					}
				}
				npc.lifeRegen -= leechCount * 2 * 72;
				if (damage < leechCount * 36) 
				{
					damage = leechCount * 36;
				}
			}
			if (gunThief) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int thiefCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<SoulThiefProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						thiefCount++;
					}
				}
				npc.lifeRegen -= thiefCount * 2 * 100;
				if (damage < thiefCount * 50) 
				{
					damage = thiefCount * 50;
				}
			}
		}
	}
}