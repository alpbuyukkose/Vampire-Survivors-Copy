using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tilePrefab;
    public Transform player;

    public int chunkSize = 20;
    public int viewDistance = 3;

    private Dictionary<Vector2Int, bool> spawnedChunks = new Dictionary<Vector2Int, bool>();

    private void Update()
    {
        Vector2Int playerChunk = new Vector2Int(Mathf.FloorToInt(player.position.x / chunkSize),
            Mathf.FloorToInt(player.position.y / chunkSize));

        for (int x = -viewDistance; x <= viewDistance; x++)
        {
            for (int y = -viewDistance; y <= viewDistance; y++)
            {
                Vector2Int chunkPos = playerChunk + new Vector2Int(x, y);
                if (!spawnedChunks.ContainsKey(chunkPos))
                {
                    SpawnChunk(chunkPos);
                }
            }
        }

        List<Vector2Int> chunksToRemove = new List<Vector2Int>();
        foreach (var chunk in spawnedChunks.Keys)
        {
            if (Vector2Int.Distance(chunk, playerChunk) > viewDistance)
            {
                chunksToRemove.Add(chunk);
            }
        }
        foreach (var chunk in chunksToRemove)
        {
            RemoveChunk(chunk);
        }
    }

    void SpawnChunk(Vector2Int chunkPos)
    {
        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                Vector3Int tilePos = new Vector3Int(
                    chunkPos.x * chunkSize + x,
                    chunkPos.y * chunkSize + y,
                    0
                );
                tilemap.SetTile(tilePos, tilePrefab);
            }
        }
        spawnedChunks[chunkPos] = true;
    }

    void RemoveChunk(Vector2Int chunkPos)
    {
        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                Vector3Int tilePos = new Vector3Int(
                    chunkPos.x * chunkSize + x,
                    chunkPos.y * chunkSize + y,
                    0
                );
                tilemap.SetTile(tilePos, null);
            }
        }
        spawnedChunks.Remove(chunkPos);
    }
}
