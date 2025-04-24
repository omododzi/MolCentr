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
    public int summBY = 1;
    public int pribavka;
    public static int lvlfloor = 1;
    public static int summbaff;

    public GameObject mycassa;
    private CassaMoney _money;

    public GameObject[] Preftospawn;
    public GameObject[] Visitmagazine;

    void Start()
    {
        if (lvlfloor == 1)
        {
            summBY = 150;
        }else if (lvlfloor == 2)
        {
            summBY = 300;
        }else if (lvlfloor == 3)
        {
            summBY = 400;
        }else if (lvlfloor == 4)
        {
            
        }else if (lvlfloor == 5)
        {
            summBY = 500;
        }

        if (mycassa != null)
        {
            _money = mycassa.GetComponent<CassaMoney>();
        }
        else
        {
            Debug.Log("pox");
        }
        summBY *= summbaff;
        _spawn = new Spawnguest();
    }

    void Update()
    {
        //text.text = summBY + "$";
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
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("pox");
            }
            if (ButtonsOrDecor != null)
            {
                for (int i = 0; i < ButtonsOrDecor.Length; i++)
                {
                    ButtonsOrDecor[i].SetActive(true);
                   
                }
                if (mycassa != null)
                {
                    _money.money += pribavka;
                }else
                {
                    Debug.Log("pox");
                }
                Destroy(gameObject);
            } else
            {
                Debug.Log("pox");
            }

            if (floor != null)
            {
                lvlfloor++;
                summbaff += 3;
                Instantiate(floor, spawnfloor.transform.position, Quaternion.identity);
                _spawn.SpawnGuests();
                Destroy(gameObject);
            } else
            {
                Debug.Log("pox");
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
                }else
                {
                    Debug.Log("pox");
                }
                Destroy(gameObject);
            } else
            {
                Debug.Log("pox");
            }
            if (Visitmagazine != null)
            {
                for (int i = 0; i < Visitmagazine.Length; i++)
                {
                    Visitmagazine[i].SetActive(true);
                }
                Destroy(gameObject);
            } else
            {
                Debug.Log("pox");
            }
            
        }
    }
}
