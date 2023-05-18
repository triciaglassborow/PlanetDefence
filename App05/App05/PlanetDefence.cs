using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace App05
{
    public class PlanetDefence : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D background;

        private Texture2D blueEnemy;
        private Texture2D greenEnemy;
        private Texture2D redEnemy;
        private Texture2D projectile;
        private Texture2D rightWall;
        private Texture2D leftWall;

        private Texture2D player;
        private Texture2D playerbullet;

        private PlayerSprite playerCharacter;
        private BlueEnemy blueShip;
        private RedEnemy redShip;
        private GreenEnemy greenShip;
        private Walls rightBorder;
        private Walls leftBorder;
        

        //public Rectangle RBorder = new((int)0, (int)-100, (int)1, (int)864);
        //public Rectangle LBorder = new((int)552, (int)-100, (int)1, (int)864);

        
        public PlanetDefence()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 552;
            _graphics.PreferredBackBufferHeight = 764;

            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player = Content.Load<Texture2D>("player");
            playerbullet = Content.Load<Texture2D>("playerbullet");

            redEnemy = Content.Load<Texture2D>("Enemy/redEnemy");
            blueEnemy = Content.Load<Texture2D>("Enemy/blueEnemy");
            greenEnemy = Content.Load<Texture2D>("Enemy/greenEnemy");
            projectile = Content.Load<Texture2D>("Enemy/projectile");

            rightWall = Content.Load<Texture2D>("rboundry");
            leftWall = Content.Load<Texture2D>("lBoundry");

            background = Content.Load<Texture2D>("background");

            SetupSprites();
        }

        //gives playersprite its image
        private void SetupSprites()
        {
            playerCharacter = new PlayerSprite(225, 450)
            {
                Image = player
            };

            blueShip = new BlueEnemy(1,0)
            {
                Image = blueEnemy
            };

            redShip = new RedEnemy(100,0)
            {
                Image = redEnemy
            };

            greenShip = new GreenEnemy(200,0)
            {
                Image = greenEnemy
            };

            rightBorder = new RightWall(-179, -100)
            {
                Image = rightWall
            };

            leftBorder = new LeftWall(400, -100)
            {
                Image = leftWall
            };
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            playerCharacter.Update(gameTime);
            blueShip.Update(gameTime);
            redShip.Update(gameTime);
            greenShip.Update(gameTime);
            rightBorder.Update(gameTime);
            base.Update(gameTime);

            //player collising wth enemy ship ends the game, brings up death screen
            if (playerCharacter.HasCollided(blueShip))
            {
                //death screen
            }
            if (playerCharacter.HasCollided(redShip))
            {
                //redShip.IsAlive = false;
                //death screen
            }
            if (playerCharacter.HasCollided(greenShip))
            {
                //death screen
            }

            //enemys hitting right border

            if (rightBorder.HasCollided(blueShip))
            {
                Exit();
            }
            if (rightBorder.HasCollided(redShip))
            {
                Exit();
            }
            if (rightBorder.HasCollided(greenShip))
            {
                Exit();
            }

            //enemys hitting left border
            if (leftBorder.HasCollided(blueShip))
            {
                Exit();
            }
            if (leftBorder.HasCollided(redShip))
            {
                Exit();
            }
            if (leftBorder.HasCollided(greenShip))
            {
                Exit();
            }


            //enemy collng with right, down movemtn and then trave left

            //enemy ship colliding with left, down movemtn the travel right

        }

        //bounding boxes
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            //background
            Vector2 position = new Vector2(0, 0);
            _spriteBatch.Draw(background, position, Color.White);
            //player
            _spriteBatch.Draw(playerCharacter.Image, playerCharacter.Position, Color.White);
            //enemy ships
            _spriteBatch.Draw(blueShip.Image, blueShip.Position,Color.White);
            _spriteBatch.Draw(redShip.Image, redShip.Position, Color.White);
            _spriteBatch.Draw(greenShip.Image, greenShip.Position, Color.White);

            _spriteBatch.Draw(rightBorder.Image, rightBorder.Position, Color.White);    
            _spriteBatch.Draw(leftBorder.Image, leftBorder.Position, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}