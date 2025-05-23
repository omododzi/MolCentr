using System.Collections.Generic;
using UnityEngine;

public class Restarting : MonoBehaviour
{
    [SerializeField] private GameObject _prefLarge; // Добавлен атрибут SerializeField и префикс _
    public Transform _player;
    private Vector3 _playerStartPosition; // Храним позицию вместо Transform
    private Vector3 _firstLargePosition; // Храним позицию вместо Transform
    private Quaternion _firstLargeRotation; // Храним вращение отдельно
    private Score _score;


    // Магазины будем находить по тегам динамически
    private readonly string[] _magazineTags =
    {
        "card sport", "card pet", "card fish",
        "card cafe", "card jewelery", "card toilet"
    };


    void Start()
    {

        _score = gameObject.GetComponent<Score>();
        if (_player == null) Debug.Log("Player not found!");

        _playerStartPosition = _player.position;

        var firstLarge = GameObject.FindGameObjectWithTag("large");
        if (firstLarge != null)
        {
            _firstLargePosition = firstLarge.transform.position;
            _firstLargeRotation = firstLarge.transform.rotation;
        }
        else
        {
            Debug.Log("Large object not found!");
        }
    }

    void Update()
    {
        if (ButtontoBY.ribild)
        {
            Restart();
            ButtontoBY.ribild = false;
        }
    }

public void Restart()
    {
        var controller = _player.GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;
        }

        // 2. Телепортируем игрока
        _player.position = _playerStartPosition;

        // 3. Включаем CharacterController обратно
        if (controller != null)
        {
            controller.enabled = true;
        }

        DestroyAllWithTag("large");
        
        // Удаляем все магазины
        foreach (var tag in _magazineTags)
        {
            Debug.Log(tag);
            DestroyAllWithTag(tag);
        }
        
        // Создаем новый large объект
        Instantiate(_prefLarge, _firstLargePosition, _firstLargeRotation);
        
        // Возвращаем игрока на стартовую позицию
       
        if (ButtontoBY.lvlfloor <= 4)
        {
            _score.MinusMoneyPerSecond();
            Score.summ = 0;
        }
        ButtontoBY.lvlfloor = 1;
        YGadd.TryShowFullscreenAdWithChance(100);
    }
    
    // Вспомогательный метод для удаления всех объектов с определенным тегом
    private void DestroyAllWithTag(string tag)
    {
        var objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (var obj in objects)
        {
            Destroy(obj);
        }
    }
}