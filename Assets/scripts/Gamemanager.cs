using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    void Start()
    {
        GameObject importantObj = GameObject.Find("ATM3 1");
        if (importantObj != null && !importantObj.activeSelf)
        {
            importantObj.SetActive(true); // Принудительно включаем
            Debug.Log("Объект был выключен, включили принудительно!");
        }
    }
}
