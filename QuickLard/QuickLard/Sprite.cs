using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Text;

namespace QuickLard
{
    public class Sprite
    {
        protected Texture2D texture;

        protected Vector2 pos;

        protected int spriteWidth;
        protected int spriteHeight;

        protected Vector2 mid
        { get { return pos + (new Vector2(spriteWidth, spriteHeight) / 2); } }

        protected Vector2 center
        { get { return (new Vector2(spriteWidth, spriteHeight) / 2); } }

        protected Color color;

        protected int phases;
        protected int currentPhase;
        protected double phaseLength;
        protected double lastTime;


        protected float size;
        protected double rotation;

        protected Rectangle sourceRectangle { get { return new Rectangle(currentPhase * spriteWidth, 0, spriteWidth, spriteHeight); } }

        public Sprite(Vector2 pos, Color color, int spriteWidth, int spriteHeight, double phaseLength)
        {
            this.color = color;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;

            this.phaseLength = phaseLength;

            this.pos = pos;

            rotation = MathHelper.Pi;

            size = 0.62f;
        }

        public void GetPhases()
        {
            phases = texture.Width / spriteWidth - 1;
            currentPhase = 0;

            phaseLength = 80;

            lastTime = 0;
        }

        public void Load(ContentManager cm)
        {
            texture = cm.Load<Texture2D>("Cars/defaultCar");

            GetPhases();
        }

        public void NextPhase()
        {
            if (currentPhase < phases) currentPhase++;
            else currentPhase = 0;
        }

        public void Update(GameTime gt)
        {
            if (gt.TotalGameTime.TotalMilliseconds - lastTime > phaseLength)
            {
                lastTime = gt.TotalGameTime.TotalMilliseconds;
                NextPhase();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, pos, sourceRectangle, color, (float)rotation, center, size, SpriteEffects.None, 0);
        }
    }
}
