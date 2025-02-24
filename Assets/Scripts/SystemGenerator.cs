using System.Collections.Generic;
using UnityEngine;

public class SystemGenerator : MonoBehaviour
{
    public GameObject starPrefab;
    public GameObject planetPrefab;
    public int numberOfPlanets = 5;
    public float minOrbitRadius = 10f;
    public float orbitSpacing = 5f;

    private List<GameObject> planets = new List<GameObject>();

    void Start()
    {
        GenerateSystem();
    }

    void GenerateSystem()
    {
        GameObject star = Instantiate(starPrefab, Vector3.zero, Quaternion.identity);
        star.name = "Star";

        for (int i = 0; i < numberOfPlanets; i++)
        {
            float orbitRadius = minOrbitRadius + i * orbitSpacing;
            Vector3 planetPosition = new Vector3(orbitRadius, 0, 0);
            GameObject planet = Instantiate(planetPrefab, planetPosition, Quaternion.identity);
            planet.name = "Planet_" + (i + 1);
            planet.transform.parent = star.transform;
            planets.Add(planet);
        }
    }
}
