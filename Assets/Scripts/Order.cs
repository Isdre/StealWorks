using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Order", menuName = "Orders/Order")]
public class Order : ScriptableObject
{
   public string name;
   public Sprite icon;
   public String[] ingridients;
}
