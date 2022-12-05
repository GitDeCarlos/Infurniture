using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject chunkLoadBounds;
    [SerializeField]
    private RoomFirstGenerator roomFirstGenerator;

    private Queue<Vector2Int> chunksToLoad;
    private List<Vector2Int> chunksLoaded;

    private Vector2Int currentChunk = Vector2Int.zero;

    private Vector2Int[] directionalBearings = new Vector2Int[8];

    private void Start()
    {
        chunksToLoad = new Queue<Vector2Int>();
        chunksLoaded = new List<Vector2Int>();

        directionalBearings[0] = new Vector2Int(-1,0);
        directionalBearings[1] = new Vector2Int(0,1);
        directionalBearings[2] = new Vector2Int(1,1);
        directionalBearings[3] = new Vector2Int(1,0);
        directionalBearings[4] = new Vector2Int(1,-1);
        directionalBearings[5] = new Vector2Int(0,-1);
        directionalBearings[6] = new Vector2Int(-1,-1);
        directionalBearings[7] = new Vector2Int(-1,0);

        chunksToLoad.Enqueue(new Vector2Int(0,0));
        chunksToLoad.Enqueue(new Vector2Int(0,-1));
        chunksToLoad.Enqueue(new Vector2Int(-1,0));
        chunksToLoad.Enqueue(new Vector2Int(-1,-1));
    }
    
    private void Update()
    {
        //Debug.Log("min: " + chunkLoadBounds.GetComponent<CircleCollider2D>().bounds.min + "max: " + chunkLoadBounds.GetComponent<CircleCollider2D>().bounds.max);
        //Debug.Log(chunkLoadBounds.GetComponent<CircleCollider2D>().bounds.center / 100);
        
        // Finds the current residing chunk of player 
        Vector2 center = (Vector2)chunkLoadBounds.GetComponent<CircleCollider2D>().bounds.center;
        currentChunk = new Vector2Int(Mathf.FloorToInt(center.x / 100), Mathf.FloorToInt(center.y / 100));

        if (chunksToLoad.Count > 0)
        {
            Vector2Int currentChunk = chunksToLoad.Dequeue();
            if (!chunksLoaded.Contains(currentChunk))
            {
                roomFirstGenerator.CreateRooms(currentChunk * 100);
                chunksLoaded.Add(currentChunk);
            }
        }
        else 
        {
            for (int i = 0; i < 8; i++)
            {
                if (!chunksLoaded.Contains(currentChunk + directionalBearings[i]))
                {
                    chunksToLoad.Enqueue(currentChunk + directionalBearings[i]);
                }
            }

        }
    }
}
