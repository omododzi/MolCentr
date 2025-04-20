using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using TMPro;


public class ButtontoBY : MonoBehaviour
{
    
    public List<GameObject> magazinetype;
    public GameObject[] ButtonsOrDecor;
    public GameObject floor;
    public GameObject spawnfloor;
    private Spawnguest _spawn;
    public TMP_Text text;
    public int summBY;

    public GameObject Preftospawn;
    public GameObject Cube;
    
    public GameObject[] Visitmagazine;

    void Start()
    {
        _spawn = new Spawnguest();
    }

    void Update()
    {
        text.text = summBY + "$";
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (magazinetype != null)
            {
                for (int i = 0; i < magazinetype.Count; i++)
                {
                    magazinetype[i].SetActive(true);
                   
                }
            }
            if (ButtonsOrDecor != null)
            {
                for (int i = 0; i < ButtonsOrDecor.Length; i++)
                {
                    ButtonsOrDecor[i].SetActive(true);
                }
            }

            if (floor != null)
            { 
                Instantiate(floor, spawnfloor.transform.position, Quaternion.identity);
                _spawn.SpawnGuests();
            }

            if (Cube != null && Preftospawn != null)
            {
                Instantiate(Preftospawn,Cube.transform.position,Quaternion.identity);
                Destroy(Cube);
            }
            if (Visitmagazine != null)
            {
                for (int i = 0; i < Visitmagazine.Length; i++)
                {
                    Visitmagazine[i].SetActive(true);
                }
            }
            Destroy(gameObject);
        }
    }
}
