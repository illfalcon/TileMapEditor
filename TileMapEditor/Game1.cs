using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TileMapEditor
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        RenderTarget2D mapTarget;
        RenderTarget2D tileSetTarget;



        public Game1()
        {
            // Set a display mode that is windowed but is the same as the desktop's current resolution (don't show a border)...
            // This is done instead of using true fullscreen mode since some firewalls will crash the computer in true fullscreen mode
            int initial_screen_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 15;
            int initial_screen_height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 80;
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = initial_screen_width,
                PreferredBackBufferHeight = initial_screen_height,
                IsFullScreen = false,
                PreferredDepthStencilFormat = DepthFormat.Depth16
            };

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            double mapFieldWidth = (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 15) * 0.5;
            double mapFieldHeight = (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 80) * 0.5;
            mapTarget = new RenderTarget2D(GraphicsDevice, (int)mapFieldWidth, (int)mapFieldHeight);
            double tileSetFieldWidth = (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 15) * 0.25;
            double tileSetFieldHeight = (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 80) * 0.5;
            tileSetTarget = new RenderTarget2D(GraphicsDevice, (int)tileSetFieldWidth, (int)tileSetFieldHeight);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
