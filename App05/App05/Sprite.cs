using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05
{
    internal class Sprite
    {
        //structures
        public Rectangle Boundary { get; set; }
        public Vector2 StartPosition { get; set; }
        public Vector2 Position { get; set; }

        //properties
        public int MaxSpeed { get; set; }
        public int MinSpeed { get; set; }
        public int Speed { get; set; }
        public Texture2D Image { get; set; }
        public bool IsVisible { get; set; }
        public bool IsALive { get; set; }
        public int Width
        {
            get { return Image.Width; }
        }
        public int Height
        {
            get { return Image.Height; }
        }
        //Hitbox? (bounding box)
        public Rectangle HitBox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X, (int)Position.Y, Width, Height);
            }
        }

        //variables
        protected float deltaTime; //1/60th second

        //constructor- starting postion and speed
        public Sprite(int x, int y)
        {
            Position = new Vector2(x, y);
            StartPosition = Position;

            MaxSpeed = 60;
            MinSpeed = 10;
            Speed = MinSpeed;

            IsVisible = true;
            IsALive = true; 
        }

        public Vector2 GetCentrePosition()
        {
            return new Vector2(Position.X - Image.Width / 2, Position.Y - Image.Height / 2);
        }

        public void ResetPosition()
        {
            Position = StartPosition;
        }

        public virtual void Update(GameTime gameTime)
        {
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
