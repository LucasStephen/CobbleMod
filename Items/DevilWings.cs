using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Items
{
	[AutoloadEquip(EquipType.Wings)]
	
    public class DevilWings : ModItem
    {
		public override void SetStaticDefaults(){
			Tooltip.SetDefault("Demonic Flyboys");	
		}

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 10;
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 250;  //wings Height
        }

        public override void VerticalWingSpeeds(Player player,ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
        }

        public override void HorizontalWingSpeeds(Player player,ref float speed, ref float acceleration)
        {
            speed = 9f;
            acceleration *= 2.5f;
        }

    }
}