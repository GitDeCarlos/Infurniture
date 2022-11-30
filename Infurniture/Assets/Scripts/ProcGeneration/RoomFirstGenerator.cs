using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomFirstGenerator : AbstractLayoutGenerator
{
   [SerializeField]
   private int minRoomWidth = 4, minRoomHeight = 4;
   [SerializeField]
   private int gridWidth = 20, gridHeight = 20; // min size of the grid to work on
   [SerializeField]
   [Range(0,10)]
   private int offset = 1;

   protected override void RunProceduralGeneration()
   {
      CreateRooms();
   }

   private void CreateRooms()
   {
      var roomsList = ProceduralGenerationAlgorithms.BinarySpacePartitioning(new BoundsInt((Vector3Int)startPosition, new Vector3Int(gridWidth, gridHeight, 0)), minRoomWidth, minRoomHeight);

      HashSet<Vector2Int> floor =  new HashSet<Vector2Int>();
      floor = CreateSimpleRooms(roomsList);

      List<Vector2Int> roomCenters = new List<Vector2Int>();
      foreach(var room in roomsList)
      {
         roomCenters.Add((Vector2Int)Vector3Int.RoundToInt(room.center));
      }

      HashSet<Vector2Int> corridors = ConnectRooms(roomCenters);
      floor.UnionWith(corridors);

      tilemapVisualizer.PaintFloorTiles(floor);
      WallGenerator.CreateWalls(floor, tilemapVisualizer);
   }

   private HashSet<Vector2Int> ConnectRooms(List<Vector2Int> roomCenters)
   {
      HashSet<Vector2Int> corridors = new HashSet<Vector2Int>();
      var currentRoomCenter = roomCenters[Random.Range(0,roomCenters.Count)]; //choose a random room to start with
      roomCenters.Remove(currentRoomCenter);

      while(roomCenters.Count > 0)
      {
         Vector2Int closest = FindClosestPointTo(currentRoomCenter, roomCenters);
         roomCenters.Remove(closest);
         HashSet<Vector2Int> newCorridor = CreateCorridor(currentRoomCenter, closest);
         currentRoomCenter = closest;
         corridors.UnionWith(newCorridor);
      }

      return corridors;
   }

   private Vector2Int FindClosestPointTo(Vector2Int currentRoomCenter, List<Vector2Int> roomCenters)
   {
      Vector2Int closest = Vector2Int.zero;
      float distance = float.MaxValue;

      //find distance from current room center to the room ur checking
      foreach(var position in roomCenters)
      {
         float currentDistance = Vector2.Distance(position, currentRoomCenter);
         if(currentDistance < distance)
         {
            distance = currentDistance;
            closest = position;
         }
      }

      return closest;
   }

   private HashSet<Vector2Int> CreateCorridor(Vector2Int currentRoomCenter, Vector2Int destination)
   {
      HashSet<Vector2Int> corridor = new HashSet<Vector2Int>();
      var position = currentRoomCenter;
      var left = position + Vector2Int.left;
      var right = position + Vector2Int.right;
      var up = position + Vector2Int.up;
      var down = position + Vector2Int.down;
      corridor.Add(position);
      corridor.Add(left);
      corridor.Add(right);
      corridor.Add(up);
      corridor.Add(down);

      while(position.y != destination.y)
      {
         if(destination.y > position.y)
         {
            position += Vector2Int.up;
            left += Vector2Int.up;
            right += Vector2Int.up;
         }
         else if(destination.y < position.y)
         {
            position += Vector2Int.down;
            left += Vector2Int.down;
            right += Vector2Int.down;
         }
         corridor.Add(position);
         corridor.Add(left);
         corridor.Add(right);
      }

      while(position.x != destination.x)
      {
         if(destination.x > position.x)
         {
            position += Vector2Int.right;
            up += Vector2Int.right;
            down += Vector2Int.right;
         }
         else if(destination.x < position.x)
         {
            position += Vector2Int.left;
            up += Vector2Int.left;
            down += Vector2Int.left;
         }
         corridor.Add(position);
         corridor.Add(up);
         corridor.Add(down);
      }

      return corridor;
   }

   private HashSet<Vector2Int> CreateSimpleRooms(List<BoundsInt> roomsList)
   {
      HashSet<Vector2Int> floor =  new HashSet<Vector2Int>();
      foreach(var room in roomsList)
      {
         for(int col=offset; col < room.size.x - offset; col++)
         {
            for(int row=offset; row < room.size.y - offset; row++)
            {
               Vector2Int position = (Vector2Int)room.min + new Vector2Int(col, row);
               floor.Add(position);
            }
         }
      }
      return floor;
   }
}
