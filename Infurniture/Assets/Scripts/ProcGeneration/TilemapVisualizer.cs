using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
   [SerializeField]
   private Tilemap floorTilemap, wallTilemap, corridorTilemap;
   [SerializeField]
   private TileBase floorTile, wallTop, corridorTile;

   public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
   {
      PaintTiles(floorPositions, floorTilemap, floorTile);
   }

   public void PaintCorridorTiles(IEnumerable<Vector2Int> corridorPositions)
   {
      PaintTiles(corridorPositions, corridorTilemap, corridorTile);
   }

   private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
   {
      foreach(var position in positions)
      {
         PaintSingleTile(tilemap, tile, position);
      }
   }

   private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
   {
      var tilePosition = tilemap.WorldToCell((Vector3Int)position);
      tilemap.SetTile(tilePosition, tile);
   }

   internal void PaintSingleWallTile(Vector2Int position)
   {
      PaintSingleTile(wallTilemap, wallTop, position);
   }

   public void Clear()
   {
      floorTilemap.ClearAllTiles();
      wallTilemap.ClearAllTiles();
      corridorTilemap.ClearAllTiles();
   }
}
