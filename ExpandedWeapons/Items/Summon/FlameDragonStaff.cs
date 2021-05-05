using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles.Minions;
 
 
namespace ExpandedWeapons.Items.Summon
{
    public class FlameDragonStaff : ModItem
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Summons a dragon that breaths fire.
'*inhale* Pwshhhhhhh'");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}
        public override void SetDefaults()
        { 
            item.mana = 10;
			item.damage = 38;     
            item.width = 40;    
            item.height = 40;     
            item.useTime = 30;   
            item.useAnimation = 30;    
            item.useStyle = 1;  
            item.noMelee = true; 
            item.knockBack = 1f;  
            item.rare = ItemRarityID.Cyan;  
            item.UseSound = SoundID.Item43;
            item.autoReuse = false;   
            item.shoot = mod.ProjectileType("SentryDragon");    
            item.sentry = true; 
            item.value = Item.sellPrice(silver: 1200);
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
            recipe.AddIngredient(1572, 1);
            recipe.AddIngredient(506, 1);
            recipe.AddIngredient(1248, 1);
			recipe.AddIngredient(2766, 15);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}