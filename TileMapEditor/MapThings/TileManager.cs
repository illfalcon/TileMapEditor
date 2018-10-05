using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMapEditor.MapThings
{
    public class TileManager
    {
        private List<Tile> _tiles;

        public List<Tile> Tiles { get { return _tiles; } }

        public TileManager()
        {
            _tiles = new List<Tile>();
            //0 empty
            _tiles.Add(new Tile(isGround: false, isSolid: false, isEmpty: true, isOneWay: false, srcRect: Rectangle.Empty, colRect: Rectangle.Empty, id: 0));
        }

        public void AddTile(Tile tile)
        {
            _tiles.Add(tile);
        }
    }
}
