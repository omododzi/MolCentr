using System;
using UnityEngine;

public class leader : MonoBehaviour
{
   private void OnEnable()
   {
      conrollersavees.Instance.RefreshObjectStates();
   }
}
