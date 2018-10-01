using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMapEditor.MapThings
{
    public enum TileType { Grass, Jungle, Empty, OneWay }

    public class Tile
    {
        public Rectangle SourceRectangle { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public TileType TileType { get; set; }
        public bool IsGround { get; set; }
        public bool IsSolid { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsOneWay { get; set; }

        public Tile(TileType tileType, bool isGround, bool isSolid, bool isEmpty, bool isOneWay, Rectangle srcRect, Rectangle colRect)
        {
            TileType = tileType;
            IsGround = isGround;
            IsSolid = isSolid;
            IsEmpty = IsEmpty;
            IsOneWay = isOneWay;
            SourceRectangle = srcRect;
            CollisionRectangle = colRect;
        }
    }
}
