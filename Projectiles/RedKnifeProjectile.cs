using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Projectiles
{
	public class RedKnifeProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 20;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.tileCollide=true;
			projectile.penetrate = 5;
			projectile.timeLeft = 200;
			projectile.light = 0.75f;
			projectile.extraUpdates = 1;
			projectile.ignoreWater = true;
		}
		
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
		}
		
		public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height); //makes dust based on tile
            Main.PlaySound(SoundID.Item10, projectile.position); //plays impact sound
        }
		
		 public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player p = Main.player[projectile.owner];
            int healingAmount = damage/30; 
            p.statLife +=healingAmount;
            p.HealEffect(healingAmount, true);
            if (target.life <= 0)
            {
                Random r = new Random();
                for (int i = 0; i < 3; i++)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, r.Next(-3, 3), r.Next(-3, 3), mod.ProjectileType("KillingIntent"), damage * 2, 0, Main.myPlayer, 0f, 0f); //Spawning a projectile
                }
            }
        } 
	}
}
	