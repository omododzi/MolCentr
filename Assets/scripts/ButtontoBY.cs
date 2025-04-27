using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtontoBY : MonoBehaviour
{
    public List<GameObject> magazinetype;
    public GameObject[] Buttons;
    public GameObject floor;
    public GameObject spawnfloor;
    private Spawnguest _spawn;
    public TMP_Text text;
    public int summBY = 1;
    public int pribavka;
    public static int lvlfloor = 1;
    public static int summbaff;
    public GameObject Decor;
    public GameObject CubeDecor;

    public GameObject mycassa;
    private CassaMoney _money;

    public GameObject[] Preftospawn;
    public GameObject[] Visitmagazine;

    private GameObject player;

    public bool candestroy = false;

 void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (lvlfloor == 1)
        {
            summBY = 150;
        }
        else if (lvlfloor == 2)
        {
            summBY = 300;
        }
        else if (lvlfloor == 3)
        {
            summBY = 400;
        }
        else if (lvlfloor == 4)
        {

        }
        else if (lvlfloor == 5)
        {
            summBY = 500;
        }

        if (mycassa != null)
        {
            _money = mycassa.GetComponent<CassaMoney>();
        }

        summBY *= summbaff;
        _spawn = new Spawnguest();
    }

    void Update()
    {
        text.text = summBY + "$";
        text.transform.LookAt(player.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (magazinetype != null)
            {
                for (int i = 0; i < magazinetype.Count; i++)
                {
                    magazinetype[i].SetActive(true);
                }

                if (candestroy)
           {
                    // Удаление объекта через 0.5 секунд
                }
            }

            if (Buttons != null)
            {
                for (int i = 0; i < Buttons.Length; i++)
                {
                    Buttons[i].SetActive(true);
                }
                if (mycassa != null)
                {
                    _money.money += pribavka;
                }
                Destroy(gameObject);
            }

            if (Decor != null && CubeDecor != null)
            {
                CubeDecor.SetActive(true);
                Instantiate(Decor, CubeDecor.transform.localPosition,CubeDecor.transform.rotation);
                Destroy(gameObject);

            }
            if (floor != null && lvlfloor != 5)
            {
                lvlfloor++;
                summbaff += 3;
                Instantiate(floor, spawnfloor.transform.position, Quaternion.identity);
                //_spawn.SpawnGuests();
               Destroy(gameObject);
            }
            else if (lvlfloor == 5 && floor != null)
            {
                Debug.Log("restart");
            }

            if (Preftospawn != null)
            {
                for (int i = 0; i < Preftospawn.Length; i++)
                {
                    Preftospawn[i].SetActive(true);
                }
                if (mycassa != null)
                {
                    _money.money += pribavka;
                }
                Destroy(gameObject);
            }
        }
    }
}
