using System.Collections.Generic;
using UnityEngine;

public class BackgroundTiler : MonoBehaviour
{
    public GameObject tilePrefab;       // The background tile prefab
    public Transform player;            // The player object to track
    public int tileSize = 10;           // Size of each tile (assuming square tiles)
    public int renderDistance = 3;      // Number of tiles to render around the player

    private Vector2Int previousTile;    // Tracks the last tile position
    private Dictionary<Vector2Int, GameObject> activeTiles = new Dictionary<Vector2Int, GameObject>();

    void Start()
    {
        UpdateTiles(); // Generate initial tiles
    }

    void Update()
    {
        Vector2Int currentTile = GetTilePosition(player.position);
        if (currentTile != previousTile)
        {
            previousTile = currentTile;
            UpdateTiles();
        }
    }

    Vector2Int GetTilePosition(Vector3 position)
    {
        return new Vector2Int(Mathf.FloorToInt(position.x / tileSize), Mathf.FloorToInt(position.y / tileSize));
    }

    void UpdateTiles()
    {
        Vector2Int currentTile = GetTilePosition(player.position);

        // Remove tiles that are out of range
        List<Vector2Int> tilesToRemove = new List<Vector2Int>();
        foreach (var tile in activeTiles)
        {
            if (Mathf.Abs(tile.Key.x - currentTile.x) > renderDistance || Mathf.Abs(tile.Key.y - currentTile.y) > renderDistance)
            {
                tilesToRemove.Add(tile.Key);
            }
        }

        foreach (var tile in tilesToRemove)
        {
            Destroy(activeTiles[tile]);
            activeTiles.Remove(tile);
        }

        // Add new tiles around the player
        for (int x = -renderDistance; x <= renderDistance; x++)
        {
            for (int y = -renderDistance; y <= renderDistance; y++)
            {
                Vector2Int tilePos = new Vector2Int(currentTile.x + x, currentTile.y + y);
                if (!activeTiles.ContainsKey(tilePos))
                {
                    Vector3 tilePosition = new Vector3(tilePos.x * tileSize, tilePos.y * tileSize, 0);
                    GameObject newTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity);
                    activeTiles.Add(tilePos, newTile);
                }
            }
        }
    }
}
