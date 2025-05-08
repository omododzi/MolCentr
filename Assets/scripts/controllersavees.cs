using UnityEngine;
using YG;
using System.Collections.Generic;

public class conrollersavees : MonoBehaviour
{
    public static conrollersavees Instance;
    
    [Header("Save Settings")]
    [Tooltip("Prefabs for object creation")]
    [SerializeField] private List<GameObject> objectPrefabs;
    [Tooltip("Tags of objects to save")]
    [SerializeField] private List<string> objectTags = new List<string>() { "Saveable" };
    
    private HashSet<GameObject> spawnedObjects = new HashSet<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        YandexGame.GetDataEvent += OnDataLoaded;
    }

    private void Start()
    {
        FindExistingObjects();
        if (YandexGame.SDKEnabled)
            OnDataLoaded();
    }

    public bool IsObjectRegistered(GameObject obj)
    {
        return obj != null && spawnedObjects.Contains(obj);
    }

    public bool IsObjectUsed(GameObject obj)
    {
        if (YandexGame.savesData.objectPrefabNames == null || obj == null) 
            return false;

        string prefabName = GetPrefabName(obj);
        for (int i = 0; i < YandexGame.savesData.objectPrefabNames.Count; i++)
        {
            if (YandexGame.savesData.objectPrefabNames[i] == prefabName &&
                i < YandexGame.savesData.objectStates.Count)
            {
                return !YandexGame.savesData.objectStates[i];
            }
        }
        return false;
    }

    private string GetPrefabName(GameObject obj)
    {
        foreach (var prefab in objectPrefabs)
        {
            if (obj.name.StartsWith(prefab.name))
                return prefab.name;
        }
        return obj.name;
    }

    private void FindExistingObjects()
    {
        foreach (string tag in objectTags)
        {
            if (string.IsNullOrEmpty(tag)) continue;
            
            GameObject[] foundObjects = GameObject.FindGameObjectsWithTag(tag);
            foreach (var obj in foundObjects)
            {
                if (obj != null && !spawnedObjects.Contains(obj))
                {
                    spawnedObjects.Add(obj);
                }
            }
        }
    }

    public void RegisterNewObject(GameObject newObj, string tagToAdd = null)
    {
        if (newObj == null) return;
        
        if (!spawnedObjects.Contains(newObj))
        {
            spawnedObjects.Add(newObj);
            
            if (!string.IsNullOrEmpty(tagToAdd) && !newObj.CompareTag(tagToAdd))
                newObj.tag = tagToAdd;
            
            SaveObjects();
        }
    }

    private void OnDataLoaded()
    {
        LoadObjects();
    }

    private void SaveObjects()
    {
        YandexGame.savesData.objectPrefabNames = new List<string>();
        YandexGame.savesData.objectPositions = new List<Vector3>();
        YandexGame.savesData.objectRotations = new List<Quaternion>();
        YandexGame.savesData.objectStates = new List<bool>();
        YandexGame.savesData.objectTags = new List<string>();

        // Сохраняем статические переменные
        if (YandexGame.savesData.customData == null)
            YandexGame.savesData.customData = new CustomSaveData();

        YandexGame.savesData.customData.savedLvlfloor = ButtontoBY.lvlfloor;
        YandexGame.savesData.customData.savedSummbaff = ButtontoBY.summbaff;
        YandexGame.savesData.customData.savedRibild = ButtontoBY.ribild;

        foreach (var obj in spawnedObjects)
        {
            if (obj != null)
            {
                string prefabName = GetPrefabName(obj);
                if (!string.IsNullOrEmpty(prefabName))
                {
                    YandexGame.savesData.objectPrefabNames.Add(prefabName);
                    YandexGame.savesData.objectPositions.Add(obj.transform.position);
                    YandexGame.savesData.objectRotations.Add(obj.transform.rotation);
                    YandexGame.savesData.objectStates.Add(obj.activeSelf);
                    
                    foreach (string tag in objectTags)
                    {
                        if (obj.CompareTag(tag))
                        {
                            YandexGame.savesData.objectTags.Add(tag);
                            break;
                        }
                    }
                }
            }
        }

        YandexGame.SaveProgress();
    }

    private void LoadObjects()
    {
        ClearAllObjects();
        
        // Загружаем статические переменные
        if (YandexGame.savesData.customData != null)
        {
            ButtontoBY.lvlfloor = YandexGame.savesData.customData.savedLvlfloor;
            ButtontoBY.summbaff = YandexGame.savesData.customData.savedSummbaff;
            ButtontoBY.ribild = YandexGame.savesData.customData.savedRibild;
        }
        
        if (YandexGame.savesData.objectPrefabNames == null || 
            YandexGame.savesData.objectPrefabNames.Count == 0)
            return;

        for (int i = 0; i < YandexGame.savesData.objectPrefabNames.Count; i++)
        {
            string prefabName = YandexGame.savesData.objectPrefabNames[i];
            Vector3 position = YandexGame.savesData.objectPositions[i];
            Quaternion rotation = YandexGame.savesData.objectRotations[i];
            bool isActive = YandexGame.savesData.objectStates[i];
            string objectTag = (YandexGame.savesData.objectTags != null && i < YandexGame.savesData.objectTags.Count) 
                ? YandexGame.savesData.objectTags[i] 
                : "Saveable";

            foreach (var prefab in objectPrefabs)
            {
                if (prefab.name == prefabName)
                {
                    GameObject newObj = Instantiate(prefab, position, rotation);
                    newObj.SetActive(isActive);
                    
                    if (objectTags.Contains(objectTag))
                        newObj.tag = objectTag;
                    
                    spawnedObjects.Add(newObj);
                    break;
                }
            }
        }
    }

    private void ClearAllObjects()
    {
        foreach (var obj in spawnedObjects)
        {
            if (obj != null) Destroy(obj);
        }
        spawnedObjects.Clear();
    }

    public void RefreshObjectStates()
    {
        SaveObjects();
    }

    private void OnDestroy()
    {
        YandexGame.GetDataEvent -= OnDataLoaded;
    }
}