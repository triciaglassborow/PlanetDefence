using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangle = System.Drawing.Rectangle;

namespace App05
{
    public class Sprite
    {
        //structures
        public Rectangle Boundary { get; set; }
        public Vector2 StartPosition { get; set; }
        public Vector2 Position { get; set; }

        //properties
        public int EnemySpeed { get; set; }
        public int PlayerSpeed { get; set; }
        public int BulletSpeed { get; set; }
        public Texture2D Image { get; set; }
        public bool IsVisible { get; set; }
        public bool IsAlive { get; set; }
        public bool MoveRight { get; set; }
        public bool MoveLeft { get; set; }
        public float Scale { get; set; }
        public Vector2 Origin { get; set; }
        public int Wave { get; set; }
        public bool RunWave1 { get; set; }

        public int Width
        {
            get { return Image.Width; }
        }
        public int Height
        {
            get { return Image.Height; }
        }


        //Hitbox? (bounding box)
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle
                (
                    (int)Position.X,
                    (int)Position.Y,
                    (int)(Width), (int)(Height)
                );
            }
        }

       
        //variables
        protected float deltaTime; //1/60th second
        

        //constructor- starting postion and speed
        public Sprite(int x, int y)
        {
            Position = new Vector2(x, y);
            StartPosition = Position;

            EnemySpeed = 0;
            PlayerSpeed = 5;
            BulletSpeed = 8;
            
            IsAlive = true;
            IsVisible = true;

            MoveRight = true;
            MoveLeft = false;


         
        }

        public Vector2 GetCentrePosition()
        {
            return new Vector2(Position.X - Image.Width / 2, Position.Y - Image.Height / 2);
        }

        public void ResetPosition()
        {
            Position = StartPosition;
        }

        public bool HasCollided(Sprite otherSprite)
        {
            if (BoundingBox.IntersectsWith(otherSprite.BoundingBox))
            {
                int margin = 1;
                Rectangle overlap = Rectangle.Intersect(BoundingBox, otherSprite.BoundingBox);
                if (overlap.Width > margin)
                    return true;
            }

            return false;
        }

        public virtual void Update(GameTime gameTime)
        {
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (!IsAlive)
            {
                Position = new Vector2(-100, -100);
                MoveLeft = false;
                MoveRight = false;
            }

        }

    }
}
