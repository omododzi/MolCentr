using UnityEngine;
using System.Collections.Generic;

public class ChangeMagaz : MonoBehaviour
{
    private ButtontoBY _button;
    public GameObject sport;
    public GameObject pets;
    public GameObject fish;
    public GameObject baker;
    public GameObject jewelery;
    public GameObject pomoyka;
    List<GameObject> cards;
    public List<GameObject>magazines =  new List<GameObject>();
    private GameObject button;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Button"))
        {
            _button = hit.gameObject.GetComponent<ButtontoBY>();
            _button.candestroy = true;
            if (_button.magazinetype != null)
            {
                button = hit.gameObject;
            }
            
            if (_button.Visitmagazine != null)
            {
                HandleMagazineActivation();
            }
        }
    }
    private void HandleMagazineActivation()
    {
        
        foreach (var visitMag in _button.Visitmagazine)
        {
            switch (LayerMask.LayerToName(visitMag.layer))
            {
                case "sport":
                    if (magazines.Count > 0) magazines[0].SetActive(true);
                    break;
                case "cafe":
                    if (magazines.Count > 1) magazines[1].SetActive(true);
                    break;
                case "toilet":
                    if (magazines.Count > 2) magazines[2].SetActive(true);
                    break;
                case "pet":
                    if (magazines.Count > 3) magazines[3].SetActive(true);
                    break;
                case "jewelery":
                    if (magazines.Count > 4) magazines[4].SetActive(true);
                    break;
                case "fish":
                    if (magazines.Count > 5) magazines[5].SetActive(true);
                    break;
            }
        }
    }
    private void ProcessShopType(GameObject prefab, string spawnTag)
    {
        

        // Сначала находим все объекты для спавна и уничтожения
        List<GameObject> toDestroy = new List<GameObject>();
        GameObject spawnPoint = null;
        
        foreach (var obj in _button.magazinetype)
        {
            if (obj == null) continue;

            if (obj.CompareTag(spawnTag))
            {
                spawnPoint = obj;
            }
            else
            {
                toDestroy.Add(obj);
            }
        }
        toDestroy.Add(button);

        // Спавним новый объект
        if (spawnPoint != null && prefab != null)
        {
            Instantiate(prefab, spawnPoint.transform.localPosition, spawnPoint.transform.rotation);
        }

        foreach (var obj in _button.magazinetype)
        {
            if (obj == null) continue;

            toDestroy.Add(obj);
        }

        // Уничтожаем ненужные объекты
        foreach (var obj in toDestroy)
        {
            if (obj != null) Destroy(obj);
        }

        // Деактивируем Visitmagazine
        if (_button.Visitmagazine != null)
        {
            cards = new List<GameObject>(GameObject.FindGameObjectsWithTag("Cards"));
            foreach (var obj in _button.Visitmagazine)
            {
                if (obj != null) obj.SetActive(false);
                
                for (int i = 0; i < cards.Count; i++)
                {
                    cards[i].SetActive(false);
                }
            }
            cards.Clear();
        }
    }

    public void Sportshop() => ProcessShopType(sport, "spawn sport");
    public void Petshop() => ProcessShopType(pets, "spawn pet shop");
    public void Fishshop() => ProcessShopType(fish, "spawn fish");
    public void Bakershop() => ProcessShopType(baker, "spawn baker");
    public void Jeweleryshop() => ProcessShopType(jewelery, "spawn jewelery");
    public void Pomoykashop() => ProcessShopType(pomoyka, "SpawnTilet");
}