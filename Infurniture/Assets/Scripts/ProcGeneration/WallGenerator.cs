using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
   public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
   {
      var basicWallPositions = FindWallsDirection(floorPositions, Direction2D.eightDirectionsList);

      foreach(var position in basicWallPositions)
      {
         tilemapVisualizer.PaintSingleWallTile(position);
      }
   }

   private static HashSet<Vector2Int> FindWallsDirection(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
   {
      HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();

      foreach(var position in floorPositions)
      {
         foreach(var direction in directionList)
         {
            var neighborPosition = position + direction;

            if(floorPositions.Contains(neighborPosition) == false) //its neighbor is not in the list of floor positions so it must be a wall
            {
               wallPositions.Add(neighborPosition);
            }
         }
      }

      return wallPositions;
   }
}
