using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ExpandedWeapons.Items.Others
{
	// This file shows a very simple example of a GlobalItem class. GlobalItem hooks are called on all items in the game and are suitable for sweeping changes like 
	// adding additional data to all items in the game. Here we simply adjust the use time of the ore swords, as it is simple to understand. 
	// See other GlobalItem classes in ExampleMod to see other ways that GlobalItem can be used.
	public class OreSwordsBuff : GlobalItem
	{
		        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.BoneGlove)
            {
                //remove the tooltip
             //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                //actually, the hood's old statics is increased damage and crit chance by 10%.
             
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if (line != null)
                {
                    line.text = "Does more damage with more projectile bounces";
                }
             
            }
        }
		public override void SetDefaults(Item item) {
			if (item.type == ItemID.CobaltSword) { 
				item.useTime = 16;  
				item.useAnimation = 16;    
			}
			if (item.type == ItemID.PalladiumSword) { 
				item.useTime = 17;  
				item.useAnimation = 17;    
			}
			if (item.type == ItemID.OrichalcumSword) { 
				item.useTime = 16;  
				item.useAnimation = 16;    
			}
			if (item.type == ItemID.MythrilSword) { 
				item.useTime = 16;  
				item.useAnimation = 16;    
			}
			if (item.type == ItemID.TitaniumSword) { 
				item.useTime = 15;  
				item.useAnimation = 15;    
			}
			if (item.type == ItemID.AdamantiteSword) { 
				item.useTime = 15;  
				item.useAnimation = 15;    
			}
			if (item.type == ItemID.Excalibur) { 
				item.useTime = 48;  
				item.useAnimation = 24;
				item.shoot = ModContent.ProjectileType<ExcaliburBeam>();  
				item.shootSpeed = 10;
			}
			if (item.type == ItemID.ChlorophyteSaber) { 
				item.useAnimation = 8;    
			}
			if (item.type == ItemID.ChlorophyteClaymore) { 
				item.useTime = 20;
				item.shootSpeed = 12;  
				item.autoReuse = true;  
			}
			if (item.type == ItemID.BluePhasesaber) { 
				item.knockBack = 12;    
				item.useAnimation = 20;
			}
			if (item.type == ItemID.RedPhasesaber) { 
				item.knockBack = 12;    
				item.useAnimation = 20;
			}
			if (item.type == ItemID.GreenPhasesaber) { 
				item.knockBack = 12;    
				item.useAnimation = 20;
			}
			if (item.type == ItemID.PurplePhasesaber) { 
				item.knockBack = 12;    
				item.useAnimation = 20;
			}
			if (item.type == ItemID.WhitePhasesaber) { 
				item.knockBack = 12;    
				item.useAnimation = 20;
			}
			if (item.type == ItemID.YellowPhasesaber) { 
				item.knockBack = 12;    
				item.useAnimation = 20;
			}
			if (item.type == ItemID.CobaltNaginata) { 
				item.knockBack = 5;    
				item.shootSpeed = 5;
				item.damage = 32;
			}
			if (item.type == ItemID.PalladiumPike) { 
				item.knockBack = 5.5f;    
				item.shootSpeed = 5;
				item.damage = 35;
			}
			if (item.type == ItemID.OrichalcumHalberd) { 
				item.knockBack = 6.2f;    
				item.shootSpeed = 6.5f;
				item.damage = 39;
			}
			if (item.type == ItemID.MythrilHalberd) { 
				item.knockBack = 6;    
				item.shootSpeed = 6.5f;
				item.damage = 39;
			}
			if (item.type == ItemID.TitaniumTrident) { 
				item.knockBack = 7;    
				item.shootSpeed = 7;
				item.damage = 44;
			}
			if (item.type == ItemID.AdamantiteGlaive) { 
				item.knockBack = 7;    
				item.shootSpeed = 7;
				item.damage = 42;
			}
			if (item.type == ItemID.Gungnir) { 
				item.knockBack = 8;    
				item.shootSpeed = 8;
				item.damage = 55;
			}
			if (item.type == ItemID.ChlorophytePartisan) { 
				item.knockBack = 9;    
				item.shootSpeed = 7.5f;
				item.damage = 56;
			}
			if (item.type == ItemID.BoneGlove) { 
				item.knockBack = 3f;
				item.thrown = false;
				item.ranged = true;
				item.useAmmo = AmmoID.None;
				item.shoot = ModContent.ProjectileType<BetterBone>();
				item.shootSpeed = 10;
				item.damage = 25;
				item.autoReuse = true;
		}
		if (item.type == ItemID.ChargedBlasterCannon) { 
				item.CloneDefaults(ItemID.LastPrism);
			item.mana = 5;
			item.damage = 35;
			item.rare = ItemRarityID.Yellow;
			item.shoot = ModContent.ProjectileType<BlasterHoldout>();
			item.shootSpeed = 30f;
			item.value = Item.sellPrice(gold: 10);
			}
			if (item.type == ItemID.Keybrand) { 
				item.knockBack = 8;    
				item.useAnimation = 16;
				item.useTime = 16;
			}
			if (item.type == ItemID.LunarFlareBook) { 
				item.damage = 135;
				item.crit = 16;
				item.mana = 9;
				item.useTime = 8;  
				item.useAnimation = 16;
			}
			if (item.type == ItemID.StarWrath) { 
				item.damage = 125;
				item.rare = ItemRarityID.Red;
			}
			if (item.type == ItemID.Meowmere) { 
				item.damage = 220;
			}
			if (item.type == ItemID.LeafBlower) { 
				item.damage = 45;
				item.useAnimation = 5;
				item.useTime = 5;
			}
			if (item.type == ItemID.NettleBurst) {
				item.damage = 50;
			}
		}
			public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)	
			{
				if (item.type == ItemID.Keybrand) { 
				Projectile.NewProjectile(target.position.X, target.position.Y, 0, -3, mod.ProjectileType("GoldenSpike"), damage / 2, 0f, Main.myPlayer);
				Projectile.NewProjectile(target.position.X, target.position.Y, 2, -2, mod.ProjectileType("GoldenSpike"), damage / 2, 0f, Main.myPlayer);
				Projectile.NewProjectile(target.position.X, target.position.Y, -2, -2, mod.ProjectileType("GoldenSpike"), damage / 2, 0f, Main.myPlayer);
				Projectile.NewProjectile(target.position.X, target.position.Y, 2, 2, mod.ProjectileType("GoldenSpike"), damage / 2, 0f, Main.myPlayer);
				Projectile.NewProjectile(target.position.X, target.position.Y, -2, 2, mod.ProjectileType("GoldenSpike"), damage / 2, 0f, Main.myPlayer);
				Projectile.NewProjectile(target.position.X, target.position.Y, 3, 0, mod.ProjectileType("GoldenSpike"), damage / 2, 0f, Main.myPlayer);
				Projectile.NewProjectile(target.position.X, target.position.Y, -3, 0, mod.ProjectileType("GoldenSpike"), damage / 2, 0f, Main.myPlayer);
				Projectile.NewProjectile(target.position.X, target.position.Y, 0, 3, mod.ProjectileType("GoldenSpike"), damage / 2, 0f, Main.myPlayer);
				}
			}
	}
}
