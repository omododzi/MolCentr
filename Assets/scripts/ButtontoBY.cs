using System;
using UnityEngine;
using TMPro;

public class ButtontoBY : MonoBehaviour
{
    public GameObject[] CubeorDecor;
    public GameObject[] buttons;
    public GameObject floor;
    public GameObject spawnfloor;
    private Spawnguest _spawn;
    public TMP_Text text;
    public int summBY;

    public GameObject Preftospawn;
    public GameObject Cube;

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
            if (CubeorDecor != null)
            {
                for (int i = 0; i < CubeorDecor.Length; i++)
                {
                    CubeorDecor[i].SetActive(true);
                }
            }
            if (buttons != null)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].SetActive(true);
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
            }
            Destroy(gameObject);
        }
    }
}
