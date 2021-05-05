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
	public class ExpandedGlobalNPC : GlobalNPC
    {
    public override bool InstancePerEntity => true;
	public bool michiGun;

	public override void ResetEffects(NPC npc) {
		michiGun = false;
		}
		public override void UpdateLifeRegen(NPC npc, ref int damage) 
		{
			if (michiGun) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 160;
				if (damage < 20) {
					damage = 20;
				}
			}
		}
	public override void NPCLoot(NPC npc)
	{
		if(Main.rand.Next(100) < 2)
		{
			if(npc.type == 415)
			Item.NewItem(npc.getRect(), mod.ItemType("VolcanoHammer"), 1);
		}
		if(Main.rand.Next(100) < 15)
		{
			if(npc.type == 245)
			Item.NewItem(npc.getRect(), 3546, 1);
		}
		#region Developer Items
		if (Main.hardMode)
		{
		if (Main.rand.Next(100) < 5 && Main.expertMode)
		{
			if (npc.boss)
			{
				if (npc.type == 4 || npc.type == 13 || npc.type == 35 || npc.type == 50 || npc.type == 113 || npc.type == 222 || npc.type == 266)
			{
			}
			else
			{
				int dchoice = Main.rand.Next(4);
			if (dchoice == 0) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Melee.Oreorang>());
			}
			else if (dchoice == 1) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Melee.SquarePlane>());
				}
			else if (dchoice == 2) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Melee.OreyoLite>());
			}
			else if (dchoice == 3) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Melee.SubYo>());
			}
			}
			}
		}
		}
		#endregion
	}
	public override void SetupShop(int type, Chest shop, ref int nextSlot) 
	{
			if (type == NPCID.ArmsDealer && NPC.downedBoss1)
			 {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<DoubleBarrelShotgun>());
				nextSlot++;
			 }
			if (type == NPCID.Dryad && ExpandedNPCWorld.DownedCloudBoss)
			 {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Others.StrangeCloud>());
				nextSlot++;
			 }
			 if (type == NPCID.Stylist)
			 {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Ranged.HomemadeFlamethrower>());
				nextSlot++;
			 }
			 if (type == NPCID.PartyGirl && Main.hardMode)
			 {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Melee.PointyPaperPlane>());
				nextSlot++;
			 }
	}
	}
}