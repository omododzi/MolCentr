using System;
using UnityEngine;
using TMPro;
using YG;
public class Score : MonoBehaviour
{
   public TMP_Text money;
   public TMP_Text moneypersecond;
   public TMP_Text moneyoutput;

   public static int summ; // Инициализируем нулем
   public static float moneyPerSecond;// Начальное значение (например, 1$ в секунду)
    
   private float accumulatedTime;

   private void Start()
   {
      moneyPerSecond = YandexGame.savesData.moneypersec;
      summ = YandexGame.savesData.money;
      UpdateUI();
   }

   private void Update()
   {
      // Накопление времени
      accumulatedTime += Time.deltaTime;
    
      // Когда накопилась 1 секунда
      if (accumulatedTime >= 1.0f)
      {
         // Добавляем деньги
         summ += Mathf.FloorToInt(moneyPerSecond);
            
         // Вычитаем секунду из накопленного времени
         accumulatedTime -= 1.0f;
            
         // Обновляем UI
         UpdateUI();
      }
   }

   private void UpdateUI()
   {
      money.text = summ.ToString("N0") + "$";
      moneypersecond.text = moneyPerSecond.ToString("F1") + "$/сек";
      moneyoutput.text = summ.ToString("N0") + "$";
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
