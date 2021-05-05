using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles.Minions;
 
 
namespace ExpandedWeapons.Items.Summon
{
    public class LavaCrystalStaff : ModItem
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Summons a lava crystal that shoots fireballs.
'The monsters tried to swim in your lava'");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}
        public override void SetDefaults()
        { 
            item.mana = 10;
			item.damage = 28;     
            item.width = 40;    
            item.height = 40;     
            item.useTime = 30;   
            item.useAnimation = 30;    
            item.useStyle = 1;  
            item.noMelee = true; 
            item.knockBack = 5f;  
            item.rare = ItemRarityID.Orange;  
            item.UseSound = SoundID.Item43;
            item.autoReuse = false;   
            item.shoot = mod.ProjectileType("SentryLava");    
            item.sentry = true; 
            item.value = Item.sellPrice(silver: 100);
            item.summon = true;
        }
 
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 SPos = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);  
            position = SPos;
            return true;
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod); //adds a recipe
			recipe.AddIngredient(207, 1);
            recipe.AddIngredient(175, 20);
            recipe.AddIngredient(22, 10);
            recipe.anyIronBar = true;
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}