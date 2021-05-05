using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;
using ExpandedWeapons.Projectiles.Minions;
using ExpandedWeapons.Buffs;
 
namespace ExpandedWeapons.Items.Summon
{
    public class BeehiveStaff : ModItem
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Summons a beehive over your head
'Only one beehive can be summoned at a time'");
		}
        public override void SetDefaults()
        { 
            item.mana = 11; //how much mana it uses.
			item.damage = 15; //the damage of the weapon. 
            item.width = 40; //in pixels.   
            item.height = 40; //in pixels.    
            item.useTime = 25;   
            item.useAnimation = 25;    
            item.useStyle = 1; //swings over your head.
            item.noMelee = true; //its swinging does not damage enemies.
            item.knockBack = 3f;
            item.rare = ItemRarityID.Green;  
            item.UseSound = SoundID.Item44; //44 is the summon minion sound.
            item.autoReuse = false; //does not have autoswing.  
            item.shoot = mod.ProjectileType("Beehive");  
            item.summon = true;    
            item.value = Item.sellPrice(silver: 200);
            item.buffType = ModContent.BuffType<Buffs.Beehive>();
        }
        public override bool CanUseItem(Player player)
        {
            return !player.GetModPlayer<ExpandedPlayer>().overheadMinion;
        }
 
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 2); //adds the minion buff.
            Vector2 SPos = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);  //only 1 ice crystal can be summoned at a time.
            position = SPos;
            for (int l = 0; l < Main.projectile.Length; l++)
            {                                                                  
                Projectile proj = Main.projectile[l];
                if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
            }
            return true;
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod); //adds a recipe
			recipe.AddIngredient(2431, 10);
            recipe.AddIngredient(1130, 5);
            recipe.AddIngredient(209, 5);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}