using UnityEngine;

public class CassaMoney : MonoBehaviour
{
    public int money;
    private float timer;
    private GameObject manager;
    private Score score;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("EditorOnly");
        score = manager.GetComponent<Score>();
        if (ButtontoBY.lvlfloor == 1)
        {
            money = 10;
        }else if (ButtontoBY.lvlfloor == 2)
        {
            money = 20;
        }else if (ButtontoBY.lvlfloor == 3)
        {
            money = 30;
        }else if (ButtontoBY.lvlfloor == 4)
        {
            money = 40;
        }else if (ButtontoBY.lvlfloor == 5)
        {
            money = 50;
        }
        Plusmoney();
    }
    public void Plusmoney()
    {
        score.UpdateMoneyPerSecond(money);
    }
}
