using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Items
{
	public class BigBoi : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BigBoi");
			Tooltip.SetDefault("Some say he is the biggest boi that ever lived");
		}
		public override void SetDefaults()
		{
			item.damage = 100;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 12;
			item.UseSound = SoundID.Item37;
			item.autoReuse = true;
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
