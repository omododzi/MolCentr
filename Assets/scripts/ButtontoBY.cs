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
    public int pribavka = 5;
    public static int lvlfloor = 1;
    public int lvl;
    public static int summbaff = 1;
    public GameObject Decor;
    public GameObject CubeDecor;
    public GameObject stair;

    public GameObject mycassa;
    private CassaMoney _money;

    public GameObject[] Preftospawn;
    public GameObject[] Visitmagazine;

    private Transform player;

    public bool candestroy = false;
    public static bool ribild;

 void Start()
    {
        lvl = lvlfloor;
        player = Camera.main.transform;
        if (lvlfloor == 1)
        {
            summBY = 3;
        }
        else if (lvlfloor == 2)
        {
            summBY = 5000;
        }
        else if (lvlfloor == 3)
        {
            summBY = 20000;
        }
        else if (lvlfloor == 4)
        {
            summBY = 40000;

        }
        else if (lvlfloor == 5)
        {
            summBY = 60000;
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
        text.transform.LookAt(player);
        text.transform.rotation = Quaternion.LookRotation(transform.position - player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            if (magazinetype != null)
            {
                for (int i = 0; i < magazinetype.Count; i++)
                {
                    magazinetype[i].SetActive(true);
                }
                if (candestroy)
                {
                    Score.summ -= summBY;
                    candestroy = false;
                }
            }

            if (Buttons != null&& Score.summ >= summBY)
            {
                for (int i = 0; i < Buttons.Length; i++)
                {
                    Buttons[i].SetActive(true);
                }
                if (mycassa != null)
                {
                    _money.money += pribavka;
                    _money.Plusmoney();
                }
                if (candestroy)
                {
                    Score.summ -= summBY;
                    candestroy = false;
                }
                Destroy(gameObject);
            }

            if (Decor != null && CubeDecor != null&& Score.summ >= summBY)
            {
                CubeDecor.SetActive(true);
                Instantiate(Decor, CubeDecor.transform.localPosition,CubeDecor.transform.rotation);
                if (candestroy)
                {
                    Score.summ -= summBY;
                    candestroy = false;
                }
                Destroy(gameObject);

            }
            if (floor != null && Score.summ >= summBY)
            {
                lvlfloor++;
                summbaff += 3;
                Debug.Log(lvlfloor);

                var newObj = Instantiate(floor, spawnfloor.transform.position, Quaternion.identity);
                Vector3 newPosition = newObj.transform.localPosition;
                stair.SetActive(true);
                switch (lvl)
                {
                    case 2:
                        newPosition.y += 11.95f;
                        break;
                    case 3:
                        newPosition.y += 23.9f;
                        break;
                
                    // case 1 не требует изменений
                }
                newObj.transform.localPosition = newPosition;
                //_spawn.SpawnGuests();
                if (candestroy)
                {
                    Score.summ -= summBY;
                    candestroy = false;
                }
               Destroy(gameObject);
            }
            else if (lvlfloor == 4 && floor != null)
            {
                ribild = true;
            }

            if (Preftospawn != null&& Score.summ >= summBY)
            {
                for (int i = 0; i < Preftospawn.Length; i++)
                {
                    Preftospawn[i].SetActive(true);
                }
                if (mycassa != null)
                {
                    _money.money += pribavka;
                    _money.Plusmoney();
                }

                if (candestroy)
                {
                    Score.summ -= summBY;
                    candestroy = false;
                }
               
                Destroy(gameObject);
            }
        }
    }
}
