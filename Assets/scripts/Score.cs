using UnityEngine;
using TMPro;
using YG;

public class Score : MonoBehaviour
{
    public TMP_Text money;
    public TMP_Text moneypersecond;
    public static int summ; // Инициализация на случай отсутствия savesData
    public static float moneyPerSecond ; // Значение по умолчанию
    
    private float accumulatedTime;
    public GameObject image;

    private void Awake()
    {
        // Принудительно включаем объект и скрипт
        gameObject.SetActive(true);
        this.enabled = true;
    }

    private void Start()
    {
        // Загружаем данные из Яндекс Игр (с проверкой на null)
        if (YandexGame.savesData != null)
        {
            moneyPerSecond = YandexGame.savesData.moneypersec;
            summ = YandexGame.savesData.money;
        }
        else
        {
            Debug.LogWarning("YandexGame.savesData == null! Используются значения по умолчанию.");
        }

        // Проверяем, есть ли image (чтобы не было NullReferenceException)
        if (image != null)
        {
            image.SetActive(true);
            var imagescript1 = image.GetComponent<Score>();
            if (imagescript1 != null) imagescript1.enabled = true;
        }

     
        UpdateUI();
    }

    private void Update()
    {
        if (accumulatedTime >= 1.0f)
        {
            summ += Mathf.FloorToInt(moneyPerSecond);
            accumulatedTime -= 1.0f;
            UpdateUI();
        }
        accumulatedTime += Time.deltaTime;
        YandexGame.savesData.moneypersec = moneyPerSecond;
        YandexGame.savesData.money = summ;
    }

    private void UpdateUI()
    {
        if (money != null) money.text = summ.ToString("N0") + "$";
        if (moneypersecond != null) moneypersecond.text = moneyPerSecond.ToString("F1") + "$/сек";
    }

    public void UpdateMoneyPerSecond(float newValue)
    {
        moneyPerSecond += newValue;
        UpdateUI();
    }

    public void MinusMoneyPerSecond()
    {
        moneyPerSecond = 1;
        UpdateUI();
    }
}