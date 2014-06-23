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
    public class Vehicle : Sprite
    {
        protected Vector2 mov;        
        
        protected float speed;
        protected float speedMax;
        protected float speedMin;

        protected float speedUnit;
        protected float brakeSpeedUnit;
        protected float rotationUnit;
        protected float slowFactor;

        protected Keys left;
        protected Keys right;
        protected Keys acceleration;
        protected Keys brake;

        public Vehicle(Vector2 pos, Color color) : base(pos, color, 128, 128, 80)
        {
            speed = 1f;

            SetValues();

            rotationUnit = MathHelper.Pi / 32f;
        }
        
        public void SetValues() { SetValues(1f, 1f, 0.5f); }
        public void SetValues(float unitFactor, float maxFactor, float slowFactor)
        {
            speedUnit = 0.1f * unitFactor;
            brakeSpeedUnit = 0.1f * unitFactor;

            speedMax = 7 * maxFactor;
            speedMin = -4 * maxFactor;

            this.slowFactor = slowFactor;
        }

        public void Setkeys(Keys left, Keys right, Keys acceleration, Keys brake)
        {
            this.left = left;
            this.right = right;
            this.acceleration = acceleration;
            this.brake = brake;
        }

        public void Mouv()
        {
            mov = Vector2.Zero;

            mov = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));

            if (Keyboard.GetState().IsKeyDown(left)) rotation -= rotationUnit;
            if (Keyboard.GetState().IsKeyDown(right)) rotation += rotationUnit;
            
            if (Keyboard.GetState().IsKeyDown(acceleration)) { if (speed + speedUnit < speedMax) speed += speedUnit; else if (speed < speedMax && speed + speedUnit > speedMax) speed = speedMax; }
            else if (Keyboard.GetState().IsKeyDown(brake)) { if (speed - speedUnit > speedMin) speed -= brakeSpeedUnit; else if (speed > speedMin && speed - brakeSpeedUnit < speedMin) speed = speedMin; }
            else if (speed - speedUnit * slowFactor > 0) { speed -= speedUnit * slowFactor; } else if (speed > 0 && speed - speedUnit * slowFactor < 0) speed = 0;
            else if (speed + brakeSpeedUnit * slowFactor < 0) { speed += brakeSpeedUnit * slowFactor; } else if (speed < 0 && speed + brakeSpeedUnit * slowFactor > 0) speed = 0;

            Console.WriteLine(speed);
        }

        public void Update(GameTime gt)
        {
            Mouv();
            
            pos += mov * speed;

            if (speed != 0 && gt.TotalGameTime.TotalMilliseconds - lastTime > phaseLength)
            {
                lastTime = gt.TotalGameTime.TotalMilliseconds;
                NextPhase();
            }
        }
    }
}
