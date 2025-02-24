using UnityEngine;

public class PlanetTerrainGenerator : MonoBehaviour
{
    public int size = 256;
    public float heightScale = 50f;
    public float noiseScale = 0.1f;

    private Terrain terrain;

    void Start()
    {
        terrain = GetComponent<Terrain>();
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        TerrainData terrainData = terrain.terrainData;
        terrainData.heightmapResolution = size + 1;
        terrainData.size = new Vector3(size, heightScale, size);

        float[,] heights = new float[size, size];

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                float xCoord = (float)x / size * noiseScale;
                float yCoord = (float)y / size * noiseScale;
                heights[x, y] = Mathf.PerlinNoise(xCoord, yCoord);
            }
        }

        terrainData.SetHeights(0, 0, heights);
    }
}
