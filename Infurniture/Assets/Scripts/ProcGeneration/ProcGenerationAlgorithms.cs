using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class ProceduralGenerationAlgorithms
{

   public static List<BoundsInt> BinarySpacePartitioning(BoundsInt spaceToSplit, int minWidth, int minHeight)
   {
      Queue<BoundsInt> roomsQueue = new Queue<BoundsInt>();
      List<BoundsInt> roomsList = new List<BoundsInt>();
      roomsQueue.Enqueue(spaceToSplit);

      while(roomsQueue.Count > 0) //while there are rooms to split, do BSP
      {
         var room = roomsQueue.Dequeue();

         if(room.size.y >= minHeight && room.size.x >= minWidth) // this room can contain a room(s)
         {
            if(UnityEngine.Random.value < 0.5f)
            {
               if(room.size.y >= minHeight * 2) // can contain 2 rooms and have space left if split horizontal
               {
                  SplitHorizontally(minHeight, roomsQueue, room);
               }
               else if(room.size.x >= minWidth * 2)
               {
                  SplitVertically(minWidth, roomsQueue, room);
               }
               else if(room.size.x >= minWidth && room.size.y >= minHeight) // space cannot be split, but can contain a room
               {
                  roomsList.Add(room);
               }
            }
            else
            {
               if(room.size.x >= minWidth * 2)
               {
                  SplitVertically(minWidth, roomsQueue, room);
               }
               else if(room.size.y >= minHeight * 2) // can contain 2 rooms and have space left if split horizontal
               {
                  SplitHorizontally(minHeight, roomsQueue, room);
               }
               else if(room.size.x >= minWidth && room.size.y >= minHeight) // space cannot be split, but can contain a room
               {
                  roomsList.Add(room);
               }
            }
         }
      }

      return roomsList;
   }

   private static void SplitVertically( int minWidth, Queue<BoundsInt> roomsQueue, BoundsInt room)
   {
      var xSplit = Random.Range(1, room.size.x);
      BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(xSplit, room.size.y, room.size.z));
      BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x + xSplit, room.min.y, room.min.z), new Vector3Int(room.size.x - xSplit, room.size.y, room.size.z));

      roomsQueue.Enqueue(room1);
      roomsQueue.Enqueue(room2);
   }

   private static void SplitHorizontally( int minHeight, Queue<BoundsInt> roomsQueue, BoundsInt room)
   {
      var ySplit = Random.Range(1, room.size.y);
      BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(room.size.x, ySplit, room.size.z));
      BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x, room.min.y + ySplit, room.min.z), new Vector3Int(room.size.x, room.size.y - ySplit, room.size.z));

      roomsQueue.Enqueue(room1);
      roomsQueue.Enqueue(room2);
   }
}


// gets random direction
public static class Direction2D
{
   public static List<Vector2Int> cardinalDirectionsList = new List<Vector2Int>
   {
      new Vector2Int(0,1), // up direction
      new Vector2Int(1,0), // right direction
      new Vector2Int(0,-1), // down direction
      new Vector2Int(-1,0) //left direction
   };

   public static Vector2Int GetRandomCardinalDirection()
   {
      return cardinalDirectionsList[Random.Range(0, cardinalDirectionsList.Count)];
   }
}
