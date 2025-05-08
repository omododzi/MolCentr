using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;
        public float moneypersec = 1;

        public List<string> objectPrefabNames = new List<string>();
        public List<Vector3> objectPositions = new List<Vector3>();
        public List<Quaternion> objectRotations = new List<Quaternion>();
        public List<bool> objectStates = new List<bool>(); // Новое поле для состояний
        public List<string> objectTags = new List<string>();

        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения
        public CustomSaveData customData; // Добавленное поле

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны

        // Вы можете выполнить какие-то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива
            openLevels[1] = true;

            // Инициализация customData
            customData = new CustomSaveData();
        }
    }

    [System.Serializable]
    public class CustomSaveData
    {
        public int savedLvlfloor;
        public int savedSummbaff;
        public bool savedRibild;
    }
}