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
        money = ButtontoBY.lvlfloor += 10;
        Plusmoney();
    }
    public void Plusmoney()
    {
        score.UpdateMoneyPerSecond(money);
    }
}
