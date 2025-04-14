using System;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
   public TMP_Text money;
   public TMP_Text moneypersecond;
   public TMP_Text moneyoutput;
   public static int summ; // Общая сумма денег
   private float moneyPerSecond; // Деньги в секунду
   private float accumulatedTime; // Накопленное время

   private void Update()
   {
      // Накопление времени
      accumulatedTime += Time.deltaTime;
    
      // Когда накопилась 1 секунда
      if (accumulatedTime >= 1.0f)
      {
         // Добавляем деньги
         summ += (int)moneyPerSecond;
        
         // Вычитаем секунду из накопленного времени
         accumulatedTime -= 1.0f;
      }
   }

   void FixedUpdate()
   {
     
      money.text = summ + "$";
      moneypersecond.text = moneyPerSecond + "$";
      moneyoutput.text = summ + "$";
   }
}
