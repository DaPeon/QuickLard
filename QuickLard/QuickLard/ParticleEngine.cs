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
    public enum ParticleType
    {
        air,
        dot,
        circle
    }

    public static class ParticlesTextures
    {
        private static Texture2D air;
        private static Texture2D dot;
        private static Texture2D circle;

        public static void LoadTextures(ContentManager cm)
        {
            air = cm.Load<Texture2D>("Particles/air");
            dot = cm.Load<Texture2D>("Particles/dot");
            circle = cm.Load<Texture2D>("Particles/circle");
        }

        public static Texture2D GetTexture(ParticleType type)
        {
            switch (type)
            {
                case ParticleType.air: return air;
                    break;
                case ParticleType.dot: return dot;
                    break;
                case ParticleType.circle: return circle;
                    break;
                default: return air;
                    break;
            }
        }
    }

    public class Particle
    {
        protected Texture2D texture;
        protected ParticleType type;
        protected Vector2 position;
        protected Vector2 speed;
        protected float scale;
        protected float angle;
        protected float angularSpeed;
        protected Color color;
        protected float size;
        protected int TTL;

        protected bool alive;

        public Particle(ParticleType type, Vector2 position, Vector2 speed, float scale, float angle, float angularSpeed, Color color, float size, int ttl, bool alive)
        {
            this.type = type;
            this.position = position;
            this.speed = speed;
            this.scale = scale;
            this.angle = angle;
            this.angularSpeed = angularSpeed;
            this.color = color;
            this.size = size;
            this.TTL = ttl;
            this.alive = alive;
        }

        public void Update()
        {
            if (TTL < 0)

            TTL--;
            position += speed;
            angle += angularSpeed;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(ParticlesTextures.GetTexture(type), position, null, color, angle, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}
