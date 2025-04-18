using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawnguest : MonoBehaviour
{
  public GameObject[] guests;
  private GameObject[] spawnPoints;
  public int scoreguests = 1;

  public float spawnInterval = 3f;  // Задержка между спавном гостей
  private float lastSpawnTime;

  void Start()
  {
    spawnPoints =GameObject.FindGameObjectsWithTag("SpawnPoint");
  }
  void Update()
  {
    if (Time.time - lastSpawnTime >= spawnInterval)
    {
      SpawnGuests();
      lastSpawnTime = Time.time;
    }
  }
  void SpawnGuests()
  {
      
  }
}
