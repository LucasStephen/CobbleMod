using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Items
{
	public class DaddyNlsBrimstone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Daddy NL's Brimstone");
			Tooltip.SetDefault("TOMO WHOS MY SPECIAL BOY?");
		}
		public override void SetDefaults()
		{
			item.noMelee = true;
			item.noUseGraphic = false;
			item.magic = true;
			item.channel = true;
			item.mana = 0;
			item.rare = 5;
			item.width = 28;
			item.height = 30;
			//item.usetime = 7;
			item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 4f;
			item.useAnimation = 7;
			item.shoot = mod.ProjectileType("DaddyNlsBrimstoneProjectile");
			item.value = Item.sellPrice(0,3,0,0);
		
		}
	}
}