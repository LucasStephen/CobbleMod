using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace CobbleMod.Projectiles
{
	public class BlackHole : ModProjectile
	{
        int timer = 0;

		public override void SetDefaults()
		{
            Player p = Main.player[projectile.owner];
            projectile.width = 40;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 100;
			projectile.timeLeft = 750;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.aiStyle = 0; 
            projectile.ai[1] = 1;
            projectile.scale = (float)0.1;
            projectile.light = 0.75f;
        }

        public override void AI()
        {
            if (timer % 3 > 0)
            {
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    NPC target = Main.npc[i];
                    var distance = Math.Sqrt(((projectile.position.X - target.position.X) * (projectile.position.X - target.position.X)) + ((projectile.position.Y - target.position.Y) * (projectile.position.Y - target.position.Y)));
                    target.velocity.X += (float)(Math.Sign((projectile.position.X - target.position.X)) * 375 * projectile.scale / distance);
                    target.velocity.Y += (float)(Math.Sign((projectile.position.Y - target.position.Y)) * 375 * projectile.scale / distance);
                }
                for (int i = 0; i < Main.projectile.Length; i++)
                { 
                    var proj = Main.projectile[i];
                    if (proj != projectile && proj.timeLeft > 0)
                    {
                        var distance = Math.Sqrt(((projectile.position.X - proj.position.X) * (projectile.position.X - proj.position.X)) + ((projectile.position.Y - proj.position.Y) * (projectile.position.Y - proj.position.Y)));
                        proj.velocity.X += (float)(Math.Sign((projectile.position.X - proj.position.X)) * 350 * projectile.scale / distance);
                        proj.velocity.Y += (float)(Math.Sign((projectile.position.Y - proj.position.Y)) * 350 * projectile.scale / distance);
                        if (distance < (200 * projectile.scale))
                        {
                            proj.Kill();
                            if (proj.type != mod.ProjectileType("BlackHole"))
                            {
                                projectile.scale += (float)0.025;
                            }
                            else
                            {
                                projectile.scale += (float)0.015;
                                projectile.ai[1] += (float)0.025;
                            }
                            projectile.width = (int)(projectile.width * projectile.scale);
                            projectile.height = (int)(projectile.height * projectile.scale);
                        }
                    }
                }
            }
            if(timer++ > 20)
            {
                projectile.velocity.X = 0;
                projectile.velocity.Y = 0;
            }
        }

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			Main.PlaySound(SoundID.Item25, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            Player p = Main.player[projectile.owner];
            if (target.life <= 0)
            {
                projectile.scale += (float)0.025;
                projectile.ai[1] += (float)0.025;
                projectile.width = (int)(projectile.width * projectile.scale);
                projectile.height = (int)(projectile.height * projectile.scale);
            }
            damage = (int)(damage * projectile.ai[1]);
            projectile.width = (int)(projectile.width * projectile.scale);
            projectile.height = (int)(projectile.height * projectile.scale);
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            var pX = ((projHitbox.TopLeft().X + projHitbox.TopRight().X) / 2);
            var x = ((targetHitbox.TopLeft().X + targetHitbox.TopRight().X) / 2);
            var pY = ((projHitbox.TopLeft().Y + projHitbox.BottomRight().Y) / 2);
            var y = ((targetHitbox.TopLeft().Y + targetHitbox.BottomRight().Y) / 2);

            var distance = Math.Sqrt(((pX - x) * (pX - x)) + ((pY - y) * (pY - y)));
            return distance <= 200 * projectile.scale;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {

            Texture2D texture = Main.projectileTexture[projectile.type];
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
    }
}