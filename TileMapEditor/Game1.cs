using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TileMapEditor.GUI;
using TileMapEditor.MapThings;

namespace TileMapEditor
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //RenderTarget2D mapTarget;
        //RenderTarget2D tileSetTarget;

        //Map map;
        //
        //public static int initial_screen_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 15;
        //public static int initial_screen_height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 80;

        Button newMap;
        Button saveMap;
        Button loadMap;
        Button newTile;

       

        public Game1()
        {
            // Set a display mode that is windowed but is the same as the desktop's current resolution (don't show a border)...
            // This is done instead of using true fullscreen mode since some firewalls will crash the computer in true fullscreen mode

            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 700;
            graphics.ApplyChanges();
            base.Initialize();
        }
        
        public void CreateNewMapWindow()
        {
            var newMapWindow = new NewMapWindow();
            newMapWindow.Show();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D newMapButton = Content.Load<Texture2D>("new");
            Texture2D saveMapButton = Content.Load<Texture2D>("save");
            Texture2D loadMapButton = Content.Load<Texture2D>("load");

            //newMap = new Button(newMapButton, new Vector2(initial_screen_width / 8, initial_screen_height / 8 * 5));
            //newMap.Click += CreateNewMapWindow;
            //loadMap = new Button(loadMapButton, new Vector2(initial_screen_width / 8, initial_screen_height / 8 * 5));
            //saveMap = new Button(saveMapButton, new Vector2(initial_screen_width / 8, initial_screen_height / 8 * 5));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //newMap.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.FloralWhite);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.LinearWrap, DepthStencilState.None, RasterizerState.CullNone);
            //newMap.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
