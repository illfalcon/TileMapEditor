using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileMapEditor.Helpers;

namespace TileMapEditor.MapThings
{
    public class Map
    {
        private int _width;
        private int _height;
        private int _tileWidth;
        private int _tileHeight;
        private Texture2D _tileSheet;
        private Tile[,] _tiles;
        private Tile _emptyTile;
        private List<Rectangle> _tileSet;
        private TileManager _tileManager;

        public int Width { get { return _width; } } //in tiles
        public int Height { get { return _height; } } // in tiles
        public int TileWidth { get { return _tileWidth; } }
        public int TileHeight { get { return _tileHeight; } }
        public Tile[,] Tiles { get { return _tiles; } }
        public Texture2D TileSheet { get { return _tileSheet; } }
        public List<Rectangle> TileSet { get { return _tileSet; } }
        public TileManager TileManager { get { return _tileManager; } }

        public void Initialize(int width, int height, int tileWidth, int tileHeight, Texture2D tileSet)
        {
            _width = width;
            _height = height;
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
            _tileSheet = tileSet;
            _tiles = new Tile[Width, Height];
            _tileManager = new TileManager();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    _tiles[i, j] = _tileManager.Tiles[0];
                }
            }
        }

        public void SetTile(Tile tile)
        {
            Vector2 mouse;
            int mapMouseX;
            int mapMouseY;

            MouseState curMouseState = Mouse.GetState();

            if (curMouseState.LeftButton == ButtonState.Pressed)
            {
                mouse = new Vector2(curMouseState.X, curMouseState.Y) + Camera.Position;
                mapMouseX = (int)GetTileFromCoordinates(mouse.X, mouse.Y).X;
                mapMouseY = (int)GetTileFromCoordinates(mouse.X, mouse.Y).Y;
                if (mapMouseX < Width && mapMouseY < Height && mapMouseX >= 0 && mapMouseY >= 0)
                {
                    Tiles[mapMouseX, mapMouseY] = tile;
                }
            }

            if (curMouseState.RightButton == ButtonState.Pressed)
            {
                mouse = new Vector2(curMouseState.X, curMouseState.Y) + Camera.Position;
                mapMouseX = (int)GetTileFromCoordinates(mouse.X, mouse.Y).X;
                mapMouseY = (int)GetTileFromCoordinates(mouse.X, mouse.Y).Y;
                if (mapMouseX < Width && mapMouseY < Height && mapMouseX >= 0 && mapMouseY >= 0)
                {
                    Tiles[mapMouseX, mapMouseY] = _tileManager.Tiles[0];
                }
            }
        }

        //TODO: implement Save() and Load()

        public void UpdateCamera()
        {
            KeyboardState keys = Keyboard.GetState();
            if (keys.IsKeyDown(Keys.W))
                Camera.Position = new Vector2(Camera.Position.X, Camera.Position.Y - 1);
            if (keys.IsKeyDown(Keys.S))
                Camera.Position = new Vector2(Camera.Position.X, Camera.Position.Y + 1);
            if (keys.IsKeyDown(Keys.A))
                Camera.Position = new Vector2(Camera.Position.X - 1, Camera.Position.Y);
            if (keys.IsKeyDown(Keys.D))
                Camera.Position = new Vector2(Camera.Position.X + 1, Camera.Position.Y);
            //if (Camera.Position.X < Camera.MinX)
            //{
            //    Camera.Position.X = Camera.MinX;
            //}
            //if (Camera.Position.X > Camera.MaxX)
            //{
            //    Camera.Position.X = Camera.MaxX;
            //}
            //if (Camera.Position.Y < Camera.MinY)
            //{
            //    Camera.Position.Y = Camera.MinY;
            //}
            //if (Camera.Position.Y > Camera.MaxY)
            //{
            //    Camera.Position.Y = Camera.MaxY;
            //}
        }

        public Vector2 GetTileFromCoordinates(float wX, float wY)
        {
            int mX = (int)(wX / _tileWidth);
            int mY = (int)(wY / _tileHeight);
            return new Vector2(mX, mY);
        }
        
        public Vector2 GetCoordinatesFromTile(int mX, int mY)
        {
            float wX = mX * _tileWidth;
            float wY = mY * _tileHeight;
            return new Vector2(wX, wY);
        }

        public void LoadTileSet(Texture2D tileSheet)
        {
            int tilesWide = tileSheet.Width / _tileWidth;
            int tilesHigh = tileSheet.Height / _tileHeight;

            Rectangle bounds;

            _tileSet = new List<Rectangle>();

            for (int i = 0; i < tilesWide; i++)
            {
                for (int j = 0; j < tilesHigh; j++)
                {
                    bounds = new Rectangle(i * _tileWidth, j * _tileHeight, _tileWidth, _tileHeight);
                    _tileSet.Add(bounds);
                }
            }
        }
        
        //public Tile GetTile(int x, int y)
        //{
        //    return Tiles[x, y];
        //}
        //
        //public Tile GetTile(Vector2 coords)
        //{
        //    return Tiles[(int)coords.X, (int)coords.Y];
        //}
        
        public void Draw(SpriteBatch spriteBatch)
        {
            //int startCol = (int)GetTileFromCoordinates(Camera.Position.X, Camera.Position.Y).X;
            //int startRow = (int)GetTileFromCoordinates(Camera.Position.X, Camera.Position.Y).Y;
            //int endCol = (int)GetTileFromCoordinates(Camera.Position.X + Camera.Width, Camera.Position.Y).X;
            //int endRow = (int)GetTileFromCoordinates(Camera.Position.X, Camera.Position.Y + Camera.Height).Y;
            //
            //if (endCol != _width)
            //    endCol += 1;
            //if (endRow != _height)
            //    endRow += 1;
        
            Vector2 offset = new Vector2( - Camera.Position.X, - Camera.Position.Y);
        
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    spriteBatch.Draw(_tileSheet, new Rectangle((int)_tileWidth * i + (int)offset.X, (int)_tileHeight * j + (int)offset.Y, _tileWidth, _tileHeight), _tiles[i, j].SourceRectangle, Color.White);
                }
            }
        }
    }
}
