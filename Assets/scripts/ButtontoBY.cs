using System;
using UnityEngine;

public class ButtontoBY : MonoBehaviour
{
    public GameObject[] obj;
    public GameObject[] buttons;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].SetActive(true);
            }
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(true);
            }
        }
    }
}
