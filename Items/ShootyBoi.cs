using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Items
{
	public class ShootyBoi : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ShootyBoi");
			Tooltip.SetDefault("Some say he is the shootiest boi that ever lived");
		}
		public override void SetDefaults()
		{
			item.damage = 100;
			item.ranged = true; 	// for ranged weapon
			item.noMelee = true;	// makes sure that bows/tomes dont do melee damage
			item.width = 13;
			item.height = 32;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;		// bow use style
			item.shoot = 1;
			item.useAmmo = AmmoID.Arrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 12;
			item.UseSound = SoundID.Item4;
			item.autoReuse = true;
			item.shootSpeed = 8f;
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
