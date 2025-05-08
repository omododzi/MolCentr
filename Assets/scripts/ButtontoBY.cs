using System.Collections.Generic;
using UnityEngine;
using TMPro;
using YG;

public class ButtontoBY : MonoBehaviour
{
    public List<GameObject> magazinetype;
    public GameObject[] Buttons;
    public GameObject floor;
    public GameObject spawnfloor;
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

    public GameObject[] Preftospawn;
    public GameObject[] Visitmagazine;

    private Transform player;

    public bool candestroy = false;
    public static bool ribild;
    
    public Vector3 offsetRotation = Vector3.zero;
    private GameObject manager;
    private Score score;
    
    private bool actionPerformed = false;
    private bool canAction = false;
  

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("moneymanager");
        score = manager.GetComponent<Score>();
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

       

        summBY *= summbaff;
    }

    void Update()
    {
        text.text = summBY + "$";
      
        if (ribild && lvlfloor < 4)
        {
            summBY = 3;
            summbaff = 1;
        }

        if (canAction)
        {
            if (magazinetype != null && magazinetype.Count > 0)
            {
                foreach (var obj in magazinetype) obj.SetActive(true);
                actionPerformed = true;
            }
    
            if (Buttons != null && Buttons.Length > 0)
            {
                foreach (var btn in Buttons) btn.SetActive(true);
                
                actionPerformed = true;
            }
    
            if (Decor != null && CubeDecor != null)
            {
                CubeDecor.SetActive(true);
                GameObject NewObj =Instantiate(Decor, CubeDecor.transform.localPosition, CubeDecor.transform.rotation);
                score.UpdateMoneyPerSecond(8);
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
                    //Save(newFloor,newFloor.transform.position);
                    stair.SetActive(true);
                    //Save(stair,stair.transform.position);
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
                score.UpdateMoneyPerSecond(8);
                actionPerformed = true;
            }
    
            // Если действие выполнено, снимаем деньги и уничтожаем объект
            if (actionPerformed)
            {
                Score.summ -= summBY;
                canAction = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") || Score.summ < summBY)
            return;

        bool actionPerformed = false;

       canAction = true;
       
    }

  
}