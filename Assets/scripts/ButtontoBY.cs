using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    
    public Vector3 offsetRotation = Vector3.zero;

    void Start()
    {
        if (text == null) text = GetComponent<TMP_Text>();
        
        lvl = lvlfloor;
        player = Camera.main.transform;
        
        // Установка стоимости в зависимости от уровня
        switch (lvlfloor)
        {
            case 1: summBY = 3; break;
            case 2: summBY = 5000; break;
            case 3: summBY = 20000; break;
            case 4: summBY = 40000; break;
            case 5: summBY = 60000; break;
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
      
        if (ribild && lvlfloor < 4)
        {
            summBY = 3;
            summbaff = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") || Score.summ < summBY)
            return;

        bool actionPerformed = false;

        // Проверяем и выполняем действия
        if (magazinetype != null && magazinetype.Count > 0)
        {
            foreach (var obj in magazinetype) obj.SetActive(true);
            actionPerformed = true;
        }

        if (Buttons != null && Buttons.Length > 0)
        {
            foreach (var btn in Buttons) btn.SetActive(true);
            if (_money != null)
            {
                _money.money += pribavka;
                _money.Plusmoney();
            }
            actionPerformed = true;
        }

        if (Decor != null && CubeDecor != null)
        {
            CubeDecor.SetActive(true);
            GameObject NewObj =Instantiate(Decor, CubeDecor.transform.localPosition, CubeDecor.transform.rotation);
            actionPerformed = true;
        }

        if (floor != null)
        {
            if (lvlfloor < 4)
            {
                lvlfloor++;
                summbaff += 3;
                Debug.Log(lvlfloor);

                GameObject newFloor = Instantiate(floor, spawnfloor.transform.position, Quaternion.identity);
                stair.SetActive(true);
                actionPerformed = true;
            }
            else if (lvlfloor == 4)
            {
                ribild = true;
            }
        }

        if (Preftospawn != null && Preftospawn.Length > 0)
        {
            foreach (var prefab in Preftospawn) prefab.SetActive(true);
            if (_money != null)
            {
                _money.money += pribavka;
                _money.Plusmoney();
            }
            actionPerformed = true;
        }

        // Если действие выполнено, снимаем деньги и уничтожаем объект
        if (actionPerformed)
        {
            Score.summ -= summBY;
            Destroy(gameObject);
        }
        else if (candestroy)
        {
            // Только если candestroy = true, но действие не выполнено
            Score.summ -= summBY;
            candestroy = false;
        }
    }
}