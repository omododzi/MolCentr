using UnityEngine;
using YG;
public class YGadd : MonoBehaviour
{
    public static void TryShowFullscreenAdWithChance(int chance)
    {
        var random = Random.Range(0, 101);

        if (chance < random)
            return;

        YandexGame.FullscreenShow();
    }
}
