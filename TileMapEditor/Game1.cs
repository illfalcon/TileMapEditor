using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Windows;
using TileMapEditor.GUI;
using TileMapEditor.Helpers;
using TileMapEditor.MapThings;

namespace TileMapEditor
{
    public enum GameState { Active, Frozen }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState state;
        Map map;
        TileSet tileSet;
        Texture2D solid;
        Texture2D empty;

        public static int selectedTileNo = 0;

        Texture2D tileSheet;
        Texture2D selectedImage;

        MouseState mouse;
        KeyboardState prevState;

        MyButton newMap;
        MyButton saveMap;
        MyButton loadTileSet;

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
            state = GameState.Active;
            map = new Map();
            Globals.LeftView = new Viewport(0, 0, 500, 600);
            Globals.RightView = new Viewport(500, 0, 300, 600);
            base.Initialize();
        }

        public void OnNewMapClicked()
        {
            NewMapForm newMapForm = new NewMapForm();
            state = GameState.Frozen;
            newMapForm.ShowDialog();
            if (newMapForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                map.Initialize(newMapForm.width, newMapForm.height, newMapForm.mapTileWidth, newMapForm.mapTileHeight, solid, empty);
                selectedTileNo = 0;
                Camera.Position = Vector2.Zero;
                if (tileSheet != null)
                {
                    tileSet.Initialize(tileSheet, newMapForm.mapTileWidth, newMapForm.mapTileHeight, selectedImage);
                    map.LoadTileSet(tileSheet);
                }
            }
            state = GameState.Active;
        }

        public void LoadTileSet()
        {
            LoadTileSetForm loadTileSet = new LoadTileSetForm();
            state = GameState.Frozen;
            loadTileSet.ShowDialog();
            if (loadTileSet.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                FileStream setStream = File.Open(loadTileSet.fileName, FileMode.Open);
                tileSheet = Texture2D.FromStream(graphics.GraphicsDevice, setStream);
                setStream.Dispose();
                map.LoadTileSet(tileSheet);
                tileSet = new TileSet();
                tileSet.Initialize(tileSheet, map.TileWidth, map.TileHeight, selectedImage);
                tileSet.TileClicked += AddTile;
            }
            state = GameState.Active;
        }

        public void AddTile()
        {
            AddTile addTileForm = new AddTile();
            state = GameState.Frozen;
            addTileForm.ShowDialog();
            if (addTileForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Rectangle colRect = new Rectangle(addTileForm.topLeftCornerX,
                    addTileForm.topLeftCornerY,
                    addTileForm.bottomRightCornerX - addTileForm.topLeftCornerX,
                    addTileForm.bottomRightCornerY - addTileForm.topLeftCornerY);
                int id = map.TileManager.Tiles.Count;
                Tile newTile = new Tile(addTileForm.isGround, addTileForm.isSolid, addTileForm.isEmpty, addTileForm.isOneWay, tileSet.Selected, colRect, id);
                map.TileManager.AddTile(newTile);
            }
            state = GameState.Active;
        }

        public void SaveMap()
        {
            var json = new JSONSerializer();
            json.SaveList<Tile>("Data/tiles.json", map.TileManager.Tiles);
            json.SaveMap("Data/map.json", map.TileIds);
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
            Texture2D loadTileSetButton = Content.Load<Texture2D>("load");
            solid = Content.Load<Texture2D>("load");
            empty = Content.Load<Texture2D>("save");
            selectedImage = Content.Load<Texture2D>("load");

            if (tileSheet != null)
                tileSet.Initialize(tileSheet, 16, 16, selectedImage);

            newMap = new MyButton(newMapButton, new Vector2(20, Globals.ClientBounds.Y - newMapButton.Height));
            loadTileSet = new MyButton(loadTileSetButton, new Vector2(130, Globals.ClientBounds.Y - loadTileSetButton.Height));
            saveMap = new MyButton(saveMapButton, new Vector2(240, Globals.ClientBounds.Y - saveMapButton.Height));
            newMap.Click += OnNewMapClicked;
            loadTileSet.Click += LoadTileSet;
            saveMap.Click += SaveMap;
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (state == GameState.Active)
            {

                if (tileSet != null)
                {
                    tileSet.Update();
                }

                KeyboardState keyState = Keyboard.GetState();

                if (map.TileManager != null && selectedTileNo < map.TileManager.Tiles.Count - 1)
                {
                    if (keyState.IsKeyDown(Keys.Up) && !prevState.IsKeyDown(Keys.Up))
                        selectedTileNo++;
                }
                if (map.TileManager != null && selectedTileNo > 1)
                {
                    if (keyState.IsKeyDown(Keys.Down) && !prevState.IsKeyDown(Keys.Down))
                        selectedTileNo--;
                }

                prevState = keyState;

                if (state == GameState.Active && map.TileSheet != null)
                {
                    map.SetTile(map.TileManager.Tiles[selectedTileNo]);
                }

                map.UpdateCamera();

                newMap.Update();
                loadTileSet.Update();
                saveMap.Update();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Viewport original = graphics.GraphicsDevice.Viewport;

            graphics.GraphicsDevice.Viewport = Globals.LeftView;
            GraphicsDevice.Clear(Color.FloralWhite);
            spriteBatch.Begin();
            map.Draw(spriteBatch);
            if (tileSheet != null)
            {
                spriteBatch.Draw(tileSheet, new Rectangle(Mouse.GetState().X - map.TileWidth / 2, Mouse.GetState().Y - map.TileHeight / 2, map.TileWidth, map.TileHeight), map.TileManager.Tiles[selectedTileNo].SourceRectangle, Color.White);
            }
            newMap.Draw(spriteBatch);
            loadTileSet.Draw(spriteBatch);
            saveMap.Draw(spriteBatch);
            spriteBatch.End();

            graphics.GraphicsDevice.Viewport = Globals.RightView;
            spriteBatch.Begin();
            if (tileSet != null)
            {
                tileSet.Draw(spriteBatch);
            }
            spriteBatch.End();

            graphics.GraphicsDevice.Viewport = original;

            base.Draw(gameTime);
        }
    }
}
