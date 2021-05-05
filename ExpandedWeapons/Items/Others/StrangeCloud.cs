using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using ExpandedWeapons.Items.Others;

namespace ExpandedWeapons.Items.Others
{
	public class StrangeCloud : ModItem
	{
       public override void SetStaticDefaults()
	   {
		   DisplayName.SetDefault("Strange Cloud");
		   Tooltip.SetDefault(@"'It feels fluffy with a bit of strange energy inside'");
	   }
	   public override void SetDefaults()
	   {
		   item.width = 26;
		   item.height = 26;
		   item.rare = 4;
		   item.maxStack = 999;
		   item.useAnimation = 45;
		   item.useTime = 45;
		   item.useStyle = 4;
		   item.value = 300000;
		   item.consumable = true;
	   }
	   public override bool CanUseItem(Player player)
	   {
		   return !NPC.AnyNPCs(mod.NPCType("CloudBoss"));
	   }
	   public override bool UseItem(Player player)
	   {
		   Main.PlaySound(15, -1, -1, 0, 1f, +0.6f);
		   if(Main.netMode !=1)
		   {
			   NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("CloudBoss"));
		   }
		   return true;
	   }
	public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cloud, 10);
			recipe.AddIngredient(ItemID.RainCloud, 3);
			recipe.AddIngredient(520, 3);
			recipe.AddIngredient(575);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}