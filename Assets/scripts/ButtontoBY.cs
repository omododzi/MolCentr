using System;
using UnityEngine;

public class ButtontoBY : MonoBehaviour
{
    public GameObject[] obj;
    public GameObject[] buttons;
    public GameObject floor;
    public GameObject spawnfloor;
    private Spawnguest _spawn;

    void Start()
    {
        _spawn = new Spawnguest();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (obj != null)
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    obj[i].SetActive(true);
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
        }
    }
}
