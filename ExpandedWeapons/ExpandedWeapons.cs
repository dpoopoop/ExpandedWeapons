using Terraria.ModLoader;
using ExpandedWeapons.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;
using ExpandedWeapons.Items;

namespace ExpandedWeapons
{
	public class ExpandedWeapons : Mod
	{
		public override void AddRecipeGroups()
{
	RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Titanium Bar", new int[]
	{
		ItemID.TitaniumBar,
		ItemID.AdamantiteBar
	});
	RecipeGroup.RegisterGroup("ExpandedWeapons:TitaniumBars", group);
	RecipeGroup group2 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Fire", new int[]
	{
		ItemID.CursedFlame,
		ItemID.Ichor
	});
	RecipeGroup.RegisterGroup("ExpandedWeapons:EvilFire", group2);
}
		public override void PostSetupContent() {
			// Showcases mod support with Boss Checklist without referencing the mod
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null) 
			{
				bossChecklist.Call(
					"AddBoss",
					6.5f,
					ModContent.NPCType<CloudBoss>(),
					this,
					"Cloud Boss",
					(Func<bool>)(() => ExpandedNPCWorld.DownedCloudBoss),
					ModContent.ItemType<Items.Others.StrangeCloud>(),
					new List<int> { ModContent.ItemType<Items.Others.CloudBossTrophy>()},
					new List<int> { ModContent.ItemType<Items.Others.CloudHandle>(), ModContent.ItemType<Items.Others.SoulOfCloud>(), ModContent.ItemType<Items.Magic.Mordred>(), ModContent.ItemType<Items.Melee.TwoFacedAgony>(), ModContent.ItemType<Items.Summon.GeometricalWhipinator>(), ModContent.ItemType<Items.Ranged.BoltSniper>(), ItemID.NimbusRod, ItemID.DaedalusStormbow, ItemID.SkyFracture, ItemID.FairyWings, ItemID.RainCloud, ItemID.Cloud, ModContent.ItemType<Items.Others.CloudStar>(), ModContent.ItemType<Items.Others.ThreeSpikes>()},
					$"Use a [i:{ModContent.ItemType<Items.Others.StrangeCloud>()}]"
				);
			}
	}
	public override void AddRecipes()
{
Mod summonWhips = ModLoader.GetMod("SummonWhips");
Mod calameme = ModLoader.GetMod("CalamityMod");
ModRecipe recipe = new ModRecipe(this);
if (summonWhips != null) {
	recipe.AddIngredient(summonWhips.ItemType("OreoBar"), 18);
	recipe.AddIngredient(ItemID.LunarBar, 8);
}
recipe.AddTile(412);
recipe.SetResult(this.ItemType("OreoWhip"));
recipe.AddRecipe();	

ModRecipe recip = new ModRecipe(this);
if (summonWhips != null) {
	recip.AddIngredient(this.ItemType("ThreeSpikes"));
	recip.AddIngredient(ItemID.LunarBar, 20);
	recip.AddIngredient(ItemID.RangerEmblem);
	recip.AddIngredient(ItemID.WarriorEmblem);
	recip.AddIngredient(ItemID.SorcererEmblem);
	recip.AddIngredient(ItemID.SummonerEmblem);
	recip.AddIngredient(ItemID.AvengerEmblem);
	recip.AddIngredient(ItemID.DestroyerEmblem);
	if (calameme != null) {
	recip.AddIngredient(calameme.ItemType("RogueEmblem"));
}
	recip.AddIngredient(summonWhips.ItemType("CharmOfAssist"));
	recip.AddIngredient(summonWhips.ItemType("MeteorEmblem"));
}
	recip.AddTile(412);
recip.SetResult(this.ItemType("MichigunEmblem"));
recip.AddRecipe();

ModRecipe recpe = new ModRecipe(this);
if (summonWhips != null) {
	recpe.AddIngredient(summonWhips.ItemType("SuspiciousWhip"));
	recpe.AddIngredient(ItemID.PsychoKnife);
	recpe.AddTile(134);
}
else {
	recpe.AddIngredient(2800);
	recpe.AddIngredient(2860, 100);
	recpe.AddIngredient(ItemID.PsychoKnife);
	recpe.AddTile(134);
}
recpe.SetResult(this.ItemType("ImpostorStrike"));
recpe.AddRecipe();

ModRecipe recie = new ModRecipe(this);
if (summonWhips != null) {
	recie.AddIngredient(this.ItemType("ThreeSpikes"));
	recie.AddIngredient(ItemID.LunarBar, 20);
	recie.AddIngredient(summonWhips.ItemType("OreoObliterator"));
	recie.AddIngredient(ItemID.LastPrism);
	recie.AddIngredient(this.ItemType("Mordred"));
	recie.AddIngredient(ItemID.LaserMachinegun);
	recie.AddIngredient(ItemID.SpectreStaff);
	recie.AddIngredient(ItemID.CrystalSerpent);
	recie.AddIngredient(ItemID.AquaScepter);
	if (calameme != null) {
	recie.AddIngredient(calameme.ItemType("Effervescence"));
	recie.AddIngredient(calameme.ItemType("TerraRay"));
	recie.AddIngredient(calameme.ItemType("Starfall"));
}
}
recie.AddTile(412);
recie.SetResult(this.ItemType("OreoObliteratorMk2"));
recie.AddRecipe();	

ModRecipe reipe = new ModRecipe(this);
if (summonWhips != null) {
			reipe.AddIngredient(this.ItemType("ThreeSpikes"));
			reipe.AddIngredient(3467, 20);
			reipe.AddIngredient(1553, 1);
			reipe.AddIngredient(3475, 1);
			reipe.AddIngredient(this.ItemType("BoltSniper"));
			reipe.AddIngredient(ItemID.Xenopopper);
	        reipe.AddIngredient(ItemID.TacticalShotgun);
	        reipe.AddIngredient(ItemID.OnyxBlaster);
	        reipe.AddIngredient(ItemID.StarCannon);
			if (calameme != null) {
	reipe.AddIngredient(calameme.ItemType("Shredder"));
	reipe.AddIngredient(calameme.ItemType("GaussRifle"));
	reipe.AddIngredient(calameme.ItemType("StarSputter"));
}
}
			reipe.AddTile(412);
			reipe.SetResult(this.ItemType("MichiGun"));
			reipe.AddRecipe();

ModRecipe reci = new ModRecipe(this);
if (summonWhips != null) {
	reci.AddIngredient(this.ItemType("ThreeSpikes"));
	reci.AddIngredient(ItemID.LunarBar, 20);
	reci.AddIngredient(ItemID.StarWrath);
	reci.AddIngredient(ItemID.Meowmere);
	reci.AddIngredient(this.ItemType("TwoFacedAgony"));
	reci.AddIngredient(ItemID.InfluxWaver);
	reci.AddIngredient(ItemID.Keybrand);
	reci.AddIngredient(ItemID.BeamSword);
	reci.AddIngredient(ItemID.BreakerBlade);
	if (calameme != null) {
	reci.AddIngredient(calameme.ItemType("Devastation"));
	reci.AddIngredient(calameme.ItemType("Terratomere"));
	reci.AddIngredient(calameme.ItemType("TheMicrowave"));
}
}
reci.AddTile(412);
reci.SetResult(this.ItemType("DiamondBlade"));
reci.AddRecipe();	

ModRecipe rcipe = new ModRecipe(this);
			rcipe.AddIngredient(ItemID.Sickle);
			rcipe.AddIngredient(ItemID.Hay, 100);
			rcipe.AddIngredient(ItemID.Pumpkin, 30);
			rcipe.AddRecipeGroup("ExpandedWeapons:TitaniumBars", 15);
			rcipe.AddTile(134);
			rcipe.SetResult(this.ItemType("ZardyPickaxe"));
			rcipe.AddRecipe();
			ModRecipe rec = new ModRecipe(this);
if (summonWhips != null) {
	rec.AddIngredient(this.ItemType("ThreeSpikes"));
	rec.AddIngredient(ItemID.LunarBar, 20);
	rec.AddIngredient(summonWhips.ItemType("MeteorWhip"));
	rec.AddIngredient(summonWhips.ItemType("StardustWhip"));
	rec.AddIngredient(this.ItemType("GeometricalWhipinator"));
	rec.AddIngredient(summonWhips.ItemType("SuspiciousWhip"));
	rec.AddIngredient(summonWhips.ItemType("Keychain"));
	rec.AddIngredient(summonWhips.ItemType("CrystalWhip"));
	rec.AddIngredient(summonWhips.ItemType("Frostbite"));
	if (calameme != null) {
	rec.AddIngredient(calameme.ItemType("ClamCrusher"));
	rec.AddIngredient(calameme.ItemType("Tumbleweed"));
	rec.AddIngredient(calameme.ItemType("Nebulash"));
}
}
rec.AddTile(412);
rec.SetResult(this.ItemType("WhipOfMichi"));
rec.AddRecipe();	
ModRecipe ec = new ModRecipe(this);
if (summonWhips != null) {
	ec.AddIngredient(this.ItemType("ThreeSpikes"));
	ec.AddIngredient(ItemID.LunarBar, 20);
	ec.AddIngredient(2765);
	ec.AddIngredient(2759);
	ec.AddIngredient(2762);
	ec.AddIngredient(3383);
	if (calameme != null) {
	ec.AddIngredient(calameme.ItemType("RuinousSoul"), 2);
	ec.AddIngredient(calameme.ItemType("XerocCuisses"));
	ec.AddIngredient(calameme.ItemType("TarragonLeggings"));
}
}
ec.AddTile(412);
ec.SetResult(this.ItemType("MichigunLeggings"));
ec.AddRecipe();	

ModRecipe e = new ModRecipe(this);
if (summonWhips != null) {
	e.AddIngredient(this.ItemType("ThreeSpikes"));
	e.AddIngredient(ItemID.LunarBar, 20);
	e.AddIngredient(2764);
	e.AddIngredient(2758);
	e.AddIngredient(2761);
	e.AddIngredient(3382);
	if (calameme != null) {
	e.AddIngredient(calameme.ItemType("RuinousSoul"), 3);
	e.AddIngredient(calameme.ItemType("XerocPlateMail"));
	e.AddIngredient(calameme.ItemType("TarragonBreastplate"));
}
}
e.AddTile(412);
e.SetResult(this.ItemType("MichigunSuit"));
e.AddRecipe();	

ModRecipe c = new ModRecipe(this);
if (summonWhips != null) {
	c.AddIngredient(this.ItemType("ThreeSpikes"));
	c.AddIngredient(ItemID.LunarBar, 20);
	c.AddIngredient(2763);
	c.AddIngredient(2199);
	c.AddIngredient(1316);
	c.AddIngredient(559);
	if (calameme != null) {
	c.AddIngredient(calameme.ItemType("RuinousSoul"), 2);
	c.AddIngredient(calameme.ItemType("TarragonHelm"));
}
}
c.AddTile(412);
c.SetResult(this.ItemType("MichigunMask"));
c.AddRecipe();	

ModRecipe i = new ModRecipe(this);
if (summonWhips != null) {
	i.AddIngredient(this.ItemType("ThreeSpikes"));
	i.AddIngredient(ItemID.LunarBar, 20);
	i.AddIngredient(2757);
	i.AddIngredient(1546);
	i.AddIngredient(1002);
	i.AddIngredient(553);
	if (calameme != null) {
	i.AddIngredient(calameme.ItemType("RuinousSoul"), 2);
	i.AddIngredient(calameme.ItemType("TarragonVisage"));
}
}
i.AddTile(412);
i.SetResult(this.ItemType("MichigunHelmet"));
i.AddRecipe();	

ModRecipe p = new ModRecipe(this);
if (summonWhips != null) {
	p.AddIngredient(this.ItemType("ThreeSpikes"));
	p.AddIngredient(ItemID.LunarBar, 20);
	p.AddIngredient(2760);
	p.AddIngredient(2189);
	p.AddIngredient(1003);
	p.AddIngredient(558);
	if (calameme != null) {
	p.AddIngredient(calameme.ItemType("RuinousSoul"), 2);
	p.AddIngredient(calameme.ItemType("TarragonMask"));
}
}
p.AddTile(412);
p.SetResult(this.ItemType("MichigunHood"));
p.AddRecipe();	

ModRecipe r = new ModRecipe(this);
if (summonWhips != null) {
	r.AddIngredient(this.ItemType("ThreeSpikes"));
	r.AddIngredient(ItemID.LunarBar, 20);
	r.AddIngredient(3381);
	r.AddIngredient(1832);
	r.AddIngredient(1159);
	r.AddIngredient(summonWhips.ItemType("LightningHeadpiece"));
	if (calameme != null) {
	r.AddIngredient(calameme.ItemType("RuinousSoul"), 2);
	r.AddIngredient(calameme.ItemType("TarragonHornedHelm"));
}
}
r.AddTile(412);
r.SetResult(this.ItemType("MichigunHeadgear"));
r.AddRecipe();	

ModRecipe per = new ModRecipe(this);
if (summonWhips != null) {
    per.AddIngredient(summonWhips.ItemType("MeteorCore"));
	per.AddIngredient(3458, 10);
	per.AddIngredient(520, 10);
	per.AddIngredient(899);
}
per.AddTile(412);
per.SetResult(3337);
per.AddRecipe();	

ModRecipe eper = new ModRecipe(this);
if (summonWhips != null) {
    eper.AddIngredient(summonWhips.ItemType("CoriteStaff"));
	eper.AddIngredient(summonWhips.ItemType("MeteorInferno"));
	eper.AddIngredient(summonWhips.ItemType("ArcrisMeteor"));
	if (calameme != null) {
	eper.AddIngredient(calameme.ItemType("DivineGeode"), 10);
}
}
eper.AddTile(412);
eper.SetResult(this.ItemType("CoriteKnightStaff"));
eper.AddRecipe();	
}
}
}