using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int Width { get { return _width; } } //in tiles
        public int Height { get { return _height; } } // in tiles
        public int TileWidth { get { return _tileWidth; } }
        public int TileHeight { get { return _tileHeight; } }
        public Tile[,] Tiles { get { return _tiles; } }
        public Texture2D TileSheet { get { return _tileSheet; } }
        public List<Rectangle> TileSet { get { return _tileSet; } }

        public void Initialize(int width, int height, int tileWidth, int tileHeight, Texture2D tileSet)
        {
            _width = width;
            _height = height;
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
            _tileSheet = tileSet;
            _tiles = new Tile[Width, Height];
            _emptyTile = new Tile(tileType: TileType.Empty, isGround: false, isSolid: false, isEmpty: true, isOneWay: false, srcRect: Rectangle.Empty, colRect: Rectangle.Empty);
            for (int i = 0; i <= Width; i++)
            {
                for (int j = 0; j <= Height; j++)
                {
                    _tiles[i, j] = _emptyTile;
                }
            }
        }

        public void SetTile()
        {
            Vector2 mouse;
            int mapMouseX;
            int mapMouseY;
        }

        public void UpdateCamera()
        {
            KeyboardState keys = Keyboard.GetState();
            if (keys.IsKeyDown(Keys.W))
                Camera.Position = new Vector2(Camera.Position.X, Camera.Position.Y - 5);
            if (keys.IsKeyDown(Keys.S))
                Camera.Position = new Vector2(Camera.Position.X, Camera.Position.Y + 5);
            if (keys.IsKeyDown(Keys.A))
                Camera.Position = new Vector2(Camera.Position.X - 5, Camera.Position.Y);
            if (keys.IsKeyDown(Keys.D))
                Camera.Position = new Vector2(Camera.Position.X + 5, Camera.Position.Y);
            if (Camera.Position.X < Camera.MinX)
            {
                Camera.Position.X = Camera.MinX;
            }
            if (Camera.Position.X > Camera.MaxX)
            {
                Camera.Position.X = Camera.MaxX;
            }
            if (Camera.Position.Y < Camera.MinY)
            {
                Camera.Position.Y = Camera.MinY;
            }
            if (Camera.Position.Y > Camera.MaxY)
            {
                Camera.Position.Y = Camera.MaxY;
            }
        }

        //public Vector2 GetTileFromCoordinates(float wX, float wY)
        //{
        //    int mX = (int)(wX / _tileWidth);
        //    int mY = (int)(wY / _tileHeight);
        //    return new Vector2(mX, mY);
        //}
        //
        //public Vector2 GetCoordinatesFromTile(int mX, int mY)
        //{
        //    float wX = mX * _tileWidth;
        //    float wY = mY * _tileHeight;
        //    return new Vector2(wX, wY);
        //}
        //
        //public Tile GetTile(int x, int y)
        //{
        //    return Tiles[x, y];
        //}
        //
        //public Tile GetTile(Vector2 coords)
        //{
        //    return Tiles[(int)coords.X, (int)coords.Y];
        //}
        
        //public void Draw(SpriteBatch spriteBatch)
        //{
        //    int startCol = (int)GetTileFromCoordinates(Camera.Position.X, Camera.Position.Y).X;
        //    int startRow = (int)GetTileFromCoordinates(Camera.Position.X, Camera.Position.Y).Y;
        //    int endCol = (int)GetTileFromCoordinates(Camera.Position.X + Camera.Width, Camera.Position.Y).X;
        //    int endRow = (int)GetTileFromCoordinates(Camera.Position.X, Camera.Position.Y + Camera.Height).Y;
        //
        //    if (endCol != _width)
        //        endCol += 1;
        //    if (endRow != _height)
        //        endRow += 1;
        //
        //    Vector2 offset = new Vector2(GetCoordinatesFromTile(startCol, startRow).X - Camera.Position.X, GetCoordinatesFromTile(startCol, startRow).Y - Camera.Position.Y);
        //
        //    for (int i = startCol; i < endCol; i++)
        //    {
        //        for (int j = startRow; j < endRow; j++)
        //        {
        //            spriteBatch.Draw(_tileSheet, new Rectangle((int)_tileWidth * (i - startCol) + (int)offset.X, (int)_tileHeight * (j - startRow) + (int)offset.Y, _tileWidth, _tileHeight), _tiles[i, j].SourceRectangle, Color.White);
        //        }
        //    }
        //}
    }
}
