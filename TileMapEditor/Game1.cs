using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TileMapEditor.GUI;
using TileMapEditor.Helpers;
using TileMapEditor.MapThings;

namespace TileMapEditor
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Button newMap;
        Button saveMap;
        Button loadMap;
        Button newTile;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
            Globals.ClientBounds = new Vector2(Window.ClientBounds.Width, Window.ClientBounds.Height);
            Globals.DrawOffset = Vector2.Zero;
            base.Initialize();
        }
        
        //public void CreateNewMapWindow()
        //{
        //    var newMapWindow = new NewMapWindow();
        //    newMapWindow.Show();
        //}
        //
        //public void LoadMapWindow()
        //{
        //    var loadMapWindow = new LoadMapWindow();
        //    loadMapWindow.Show();
        //}
        //
        //public void SaveMapWindow()
        //{
        //    var saveMapWindow = new SaveMapWindow();
        //    saveMapWindow.Show();
        //}

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D newMapButton = Content.Load<Texture2D>("new");
            Texture2D saveMapButton = Content.Load<Texture2D>("save");
            Texture2D loadMapButton = Content.Load<Texture2D>("load");

            newMap = new Button(newMapButton, new Vector2(20, Globals.ClientBounds.Y - newMapButton.Height));
            loadMap = new Button(loadMapButton, new Vector2(130, Globals.ClientBounds.Y - loadMapButton.Height));
            saveMap = new Button(saveMapButton, new Vector2(240, Globals.ClientBounds.Y - saveMapButton.Height));
            //newMap.Click += CreateNewMapWindow;
            //loadMap.Click += LoadMapWindow;
            //saveMap.Click += SaveMapWindow;
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            newMap.Update();
            loadMap.Update();
            saveMap.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.FloralWhite);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.LinearWrap, DepthStencilState.None, RasterizerState.CullNone);
            newMap.Draw(spriteBatch);
            loadMap.Draw(spriteBatch);
            saveMap.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
