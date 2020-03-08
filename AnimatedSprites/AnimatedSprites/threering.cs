using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AnimatedSprites
{
    public class Threering
    {
        public static Texture2D Tex;
        public Rectangle Position; //Where we are drawing it
        public Rectangle SrcRect = new Rectangle(0, 0, 75, 75); //Its size

        //For animation
        float CurrentFrame = 0;
        float AnimSpeed = .5f;//Velocity

        int SpeedX = 4;//Velocity to reverse horizontal OR movement speed
        int SpeedY = 4;//Velocity to reverse vertical

        public Threering(Rectangle Position)
        {
            this.Position = Position;
        }

        public void Update(GameTime gametime)
        {
            Position.X += SpeedX; //At an angle
            Position.Y += SpeedY;

            //Keep on screen
            if (Position.X <0)
            {
                SpeedX = Math.Abs(SpeedX);
               // SpeedY = Math.Abs(SpeedY);
            }
            if (Position.Y < 0)
            {
                //SpeedX = Math.Abs(SpeedX);
                SpeedY = Math.Abs(SpeedY);
            }
            if (Position.X > 725)
            {
                SpeedX = -Math.Abs(SpeedX);
                // SpeedY = Math.Abs(SpeedY);
            }
            if (Position.Y > 405)
            {
                //SpeedX = Math.Abs(SpeedX);
                SpeedY = -Math.Abs(SpeedY);
            }
            //Animation
            CurrentFrame += AnimSpeed;
            CurrentFrame %= 48;

            SrcRect.X = (int)CurrentFrame % 6 * 75;
            SrcRect.Y = (int)CurrentFrame / 6 * 75;

        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Tex, Position, SrcRect, Color.White);
        }

    }
}
