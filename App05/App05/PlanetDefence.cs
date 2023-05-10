using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        private Texture2D player;
        private Texture2D playerbullet;

        private PlayerSprite playerCharacter;
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

            background = Content.Load<Texture2D>("background");

            SetupSprites();

            // TODO: use this.Content to load your game content here
        }

        //gives playersprite its image
        private void SetupSprites()
        {
            playerCharacter = new PlayerSprite(200, 300);
            playerCharacter.Image = player;
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            playerCharacter.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            //background
            Vector2 position = new Vector2(0, 0);
            _spriteBatch.Draw (background, position, Color.White);
            _spriteBatch.Draw(playerCharacter.Image, playerCharacter.Position, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}