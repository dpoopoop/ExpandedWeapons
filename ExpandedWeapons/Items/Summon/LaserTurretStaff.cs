using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles.Minions;
 
 
namespace ExpandedWeapons.Items.Summon
{
    public class LaserTurretStaff : ModItem
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Summons a laser sentry that shoots piercing lasers.
'Pew pew pew!'");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}
        public override void SetDefaults()
        { 
            item.mana = 10;
			item.damage = 40;     
            item.width = 40;    
            item.height = 40;     
            item.useTime = 30;   
            item.useAnimation = 30;    
            item.useStyle = 1;  
            item.noMelee = true; 
            item.knockBack = 3f;  
            item.rare = ItemRarityID.Pink;  
            item.UseSound = SoundID.Item43;
            item.autoReuse = false;   
            item.shoot = mod.ProjectileType("SentryLaser");    
            item.sentry = true; 
            item.value = Item.sellPrice(silver: 500);
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
            recipe.AddIngredient(549, 10);
			recipe.AddIngredient(1344, 10);
            recipe.AddIngredient(1225, 15);
            recipe.AddIngredient(502, 10);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}