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
    public class GameManager
    {
        public Vehicle car;

        public void InitGraphics(GraphicsDeviceManager graphics)
        {
            graphics.PreferMultiSampling = true;
            graphics.PreferredBackBufferWidth = 720;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
        }

        public GameManager()
        {
            car = new Vehicle(new Vector2(50,50), new Color(0.33f, 0.33f, 0.33f));
            car.Setkeys(Keys.S, Keys.D, Keys.NumPad7, Keys.NumPad8);
        }

        public void Load(ContentManager cm)
        {
            
            car.Load(cm);
        }

        public void Update(GameTime gt)
        {
            car.Update(gt);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            car.Draw(sb);
            sb.End();
        }
    }
}
