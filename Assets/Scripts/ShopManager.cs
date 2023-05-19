using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public int[] priceBuy;
    public int[] priceSale;
    void Start()
    {
        priceBuy = new int[3];
        priceBuy[0] = 100;
        priceBuy[1] = 300;
        priceSale = new int[2];
        priceSale[0] = 50;
        priceSale[1] = 150;
    }
}
