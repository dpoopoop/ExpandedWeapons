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
	public class JavelinNPC : GlobalNPC
    {
    public override bool InstancePerEntity => true;
	public bool javelinJungle;
	public bool javelinHell;
	public bool javelinPointy;
	public bool javelinHallowed;
	public bool javelinStar;
	public bool javelinSpore;
	public bool javelinBomber;
	public bool javelinLaser;
	public bool javelinSolar;

	public override void ResetEffects(NPC npc) {
		javelinJungle = false;
		javelinHell = false;
		javelinPointy = false;
		javelinHallowed = false;
		javelinStar = false;
		javelinSpore = false;
		javelinBomber = false;
		javelinLaser = false;
		javelinSolar = false;
		}
		public override void UpdateLifeRegen(NPC npc, ref int damage) 
		{
			if (javelinJungle) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int junglejavelinCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<JungleJavelinProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						junglejavelinCount++;
					}
				}
				npc.lifeRegen -= junglejavelinCount * 2 * 6;
				if (damage < junglejavelinCount * 3) 
				{
					damage = junglejavelinCount * 3;
				}
			}
			if (javelinHell) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int helljavelinCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<HellJavelinProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						helljavelinCount++;
					}
				}
				npc.lifeRegen -= helljavelinCount * 2 * 8;
				if (damage < helljavelinCount * 4) 
				{
					damage = helljavelinCount * 4;
				}
			}
			if (javelinPointy) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int pointyjavelinCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<PointyPaperPlaneProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						pointyjavelinCount++;
					}
				}
				npc.lifeRegen -= pointyjavelinCount * 2 * 10;
				if (damage < pointyjavelinCount * 5) 
				{
					damage = pointyjavelinCount * 5;
				}
			}
			if (javelinHallowed) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int hallowedjavelinCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<HallowedJavelinProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						hallowedjavelinCount++;
					}
				}
				npc.lifeRegen -= hallowedjavelinCount * 2 * 14;
				if (damage < hallowedjavelinCount * 7) 
				{
					damage = hallowedjavelinCount * 7;
				}
			}
			if (javelinStar) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int starjavelinCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<ThrowingStarProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						starjavelinCount++;
					}
				}
				npc.lifeRegen -= starjavelinCount * 2 * 16;
				if (damage < starjavelinCount * 8) 
				{
					damage = starjavelinCount * 8;
				}
			}
			if (javelinSpore) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int sporejavelinCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<SporeThrowerProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						sporejavelinCount++;
					}
				}
				npc.lifeRegen -= sporejavelinCount * 2 * 20;
				if (damage < sporejavelinCount * 10) 
				{
					damage = sporejavelinCount * 10;
				}
			}
			if (javelinBomber) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int bomberjavelinCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<BomberPlaneProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						bomberjavelinCount++;
					}
				}
				npc.lifeRegen -= bomberjavelinCount * 2 * 30;
				if (damage < bomberjavelinCount * 15) 
				{
					damage = bomberjavelinCount * 15;
				}
			}
			if (javelinLaser) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int laserjavelinCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<LaserJavelinProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						laserjavelinCount++;
					}
				}
				npc.lifeRegen -= laserjavelinCount * 2 * 40;
				if (damage < laserjavelinCount * 20) 
				{
					damage = laserjavelinCount * 20;
				}
			}
			if (javelinSolar) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int solarjavelinCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<SolarFlarestormProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						solarjavelinCount++;
					}
				}
				npc.lifeRegen -= solarjavelinCount * 2 * 50;
				if (damage < solarjavelinCount * 25) 
				{
					damage = solarjavelinCount * 25;
				}
			}
		}
	}
}