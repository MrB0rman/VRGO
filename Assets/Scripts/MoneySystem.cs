using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    public int money;
    public int maxMoney;
    public int moneyGain;
    public int[] moneyFarm;
    public int moneySafeBank;
    bool stop = false;

    public Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        moneyFarm = new int[2];
        moneyFarm[0] = 1;
        moneyFarm[1] = 3;
        InvokeRepeating("stonksMoney", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(money > maxMoney)
        {
            money = maxMoney;
            stop = true;
        }
        else
        {
            stop = false;
        }
        moneyText.text = money + "/" + maxMoney + " rub";
    }
    void stonksMoney()
    {
        if (!stop)
        {
            money += moneyGain;
        }
    }

}
