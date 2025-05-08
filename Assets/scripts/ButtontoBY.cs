using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ButtontoBY : MonoBehaviour
{
    [Header("References")]
    public List<GameObject> magazinetype;
    public GameObject[] Buttons;
    public GameObject floor;
    public GameObject spawnfloor;
    public TMP_Text text;
    public GameObject Decor;
    public GameObject CubeDecor;
    public GameObject stair;
    public GameObject mycassa;
    public GameObject[] Preftospawn;
    public GameObject[] Visitmagazine;

    [Header("Settings")]
    public int summBY = 1;
    public int pribavka = 5;
    public Vector3 offsetRotation = Vector3.zero;
    
    public static int lvlfloor = 1;
    public static int summbaff = 1;
    public static bool ribild;
    
    private Transform player;
    private GameObject manager;
    private Score score;
    private bool actionPerformed = false;
    private bool canAction = false;
    public int lvl;
    public bool candestroy = false;

    private void Awake()
    {
        gameObject.tag = "Saveable";
        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
        // Ждем инициализации системы сохранений
        while (conrollersavees.Instance == null)
            yield return null;

        // Проверяем состояние объекта
        if (conrollersavees.Instance.IsObjectUsed(gameObject))
        {
            SetUsedState();
            yield break;
        }

        // Регистрируем объект
        if (!conrollersavees.Instance.IsObjectRegistered(gameObject))
            conrollersavees.Instance.RegisterNewObject(gameObject);

        // Инициализация остальных компонентов
        manager = GameObject.FindGameObjectWithTag("moneymanager");
        score = manager.GetComponent<Score>();
        text = text ?? GetComponent<TMP_Text>();
        player = Camera.main.transform;
        
        UpdatePrice();
        summBY *= summbaff;
    }

    private void SetUsedState()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        enabled = false;
    }

    private void UpdatePrice()
    {
        summBY = lvlfloor switch
        {
            1 => 3,
            2 => 5000,
            3 => 20000,
            4 => 40000,
            5 => 60000,
            _ => summBY
        };
    }

    void Update()
    {
        if (!enabled) return;
        
        text.text = $"{summBY}$";
      
        if (ribild && lvlfloor < 4)
        {
            summBY = 3;
            summbaff = 1;
        }

        if (canAction)
            PerformActions();
    }

    private void PerformActions()
    {
        if (actionPerformed) return;

        bool anyAction = false;
        
        if (magazinetype != null && magazinetype.Count > 0)
        {
            magazinetype.ForEach(obj => obj.SetActive(true));
            anyAction = true;
        }
    
        if (Buttons != null && Buttons.Length > 0)
        {
            System.Array.ForEach(Buttons, btn => btn.SetActive(true));
            anyAction = true;
        }
    
        if (Decor != null && CubeDecor != null)
        {
            CubeDecor.SetActive(true);
            GameObject newObj = Instantiate(Decor, CubeDecor.transform.position, CubeDecor.transform.rotation);
            newObj.name = Decor.name;
            conrollersavees.Instance.RegisterNewObject(newObj);
            score.UpdateMoneyPerSecond(8);
            anyAction = true;
        }
    
        if (floor != null && lvlfloor < 4)
        {
            lvlfloor++;
            summbaff += 3;
            GameObject newFloor = Instantiate(floor, spawnfloor.transform.position, Quaternion.identity);
            conrollersavees.Instance.RegisterNewObject(newFloor);
            stair.SetActive(true);
            anyAction = true;
        }
        else if (floor != null && lvlfloor == 4)
        {
            ribild = true;
        }
    
        if (Preftospawn != null && Preftospawn.Length > 0)
        {
            System.Array.ForEach(Preftospawn, prefab => prefab.SetActive(true));
            score.UpdateMoneyPerSecond(8);
            anyAction = true;
        }

        if (anyAction)
        {
            actionPerformed = true;
            Score.summ -= summBY;
            canAction = false;
            SetUsedState();
            conrollersavees.Instance.RefreshObjectStates();
        }
        else if (candestroy)
        {
            Score.summ -= summBY;
            candestroy = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || Score.summ < summBY || !enabled)
            return;

        canAction = true;
    }
}