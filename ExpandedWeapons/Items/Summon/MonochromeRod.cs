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
    public class MonochromeRod : ModItem
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Summons a monochrome ball over your head
'Only one monochrome ball can be summoned at a time'");
		}
        public override void SetDefaults()
        { 
            item.mana = 13; //how much mana it uses.
			item.damage = 65; //the damage of the weapon. 
            item.width = 40; //in pixels.   
            item.height = 40; //in pixels.    
            item.useTime = 25;   
            item.useAnimation = 25;    
            item.useStyle = 1; //swings over your head.
            item.noMelee = true; //its swinging does not damage enemies.
            item.knockBack = 3f;
            item.rare = ItemRarityID.LightRed;  
            item.UseSound = SoundID.Item44; //44 is the summon minion sound.
            item.autoReuse = false; //does not have autoswing.  
            item.shoot = mod.ProjectileType("MonochromeBall");  
            item.summon = true;    
            item.value = Item.sellPrice(silver: 500);
            item.buffType = ModContent.BuffType<Buffs.MonochromeBall>();
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
			recipe.AddIngredient(528, 1);
            recipe.AddIngredient(527, 1);
            recipe.AddIngredient(22, 20);
            recipe.anyIronBar = true;
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}