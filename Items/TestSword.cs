using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Items
{
	public class TestSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("TestSword");
			Tooltip.SetDefault("This is a modded sword.");
		}
		public override void SetDefaults()
		{
			item.damage = 500;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("HomingBall"); ;
            item.shootSpeed = 60f;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

       
	}
}
