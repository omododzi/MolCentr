using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawnguest : MonoBehaviour
{
  public GameObject[] guests;
  private GameObject[] spawnPoints;
  public int scoreguests = 1;
  private int numfloor = 0;

  void Start()
  {
      spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
    for (int i = 0; i < scoreguests; i++)
    {
        int rand = Random.Range(0, guests.Length);
        //Instantiate(guests[rand], spawnPoints[numfloor].transform.position, Quaternion.identity);
    }
  }
  public void SpawnGuests()
  {
      spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
      numfloor++;
      for (int i = 0; i < scoreguests; i++)
      {
          int rand = Random.Range(0, guests.Length);
          //Instantiate(guests[rand], spawnPoints[numfloor].transform.position, Quaternion.identity);
      }
  }
}
