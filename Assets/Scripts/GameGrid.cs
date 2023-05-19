using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public int columnLenght, rowLenght;
    public float x_Space, z_Space;

    public GameObject grass;
    public GameObject gridFarm;
    public GameObject gridBank;
    public GameObject gridFarm2;

    public GameObject[] currentGrid;

    public bool gotGrid;

    public Texture2D cursorBase;
    public Texture2D farm;
    public Texture2D bank;
    public Texture2D sale;

    public CursorMode cursorMode = CursorMode.Auto;

    public Vector2 hotSpot = Vector2.zero;

    private RaycastHit _Hit;

    public GameObject hitted;

    public GameObject UIManager;
    public GameObject shopManager;
    public GameObject moneySystem;

    private void Awake()
    {
        Cursor.SetCursor(cursorBase, hotSpot, cursorMode);
    }

    void Start()
    {
        for (int i = 0; i < columnLenght * rowLenght; ++i)
        {
            Instantiate(grass, new Vector3(x_Space + (x_Space * (i%columnLenght)), 0, z_Space + (z_Space * (i / columnLenght))), Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gotGrid == false)
        {
            currentGrid = GameObject.FindGameObjectsWithTag("grid");
            gotGrid = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _Hit))
            {
                if (UIManager.gameObject.GetComponent<UIManager>().id != 1)
                {
                    if (_Hit.transform.tag == "grid")
                    {
                        switch (UIManager.gameObject.GetComponent<UIManager>().id)
                        {
                            case 2:
                                if(moneySystem.gameObject.GetComponent<MoneySystem>().money >= shopManager.gameObject.GetComponent<ShopManager>().priceBuy[0])
                                {
                                    hitted = _Hit.transform.gameObject;
                                    Instantiate(gridFarm, hitted.transform.position, Quaternion.identity);
                                    Destroy(hitted);
                                    moneySystem.gameObject.GetComponent<MoneySystem>().money -= shopManager.gameObject.GetComponent<ShopManager>().priceBuy[0];
                                    moneySystem.gameObject.GetComponent<MoneySystem>().moneyGain += moneySystem.gameObject.GetComponent<MoneySystem>().moneyFarm[0];
                                }
                                break;
                            case 3:
                                if (moneySystem.gameObject.GetComponent<MoneySystem>().money >= shopManager.gameObject.GetComponent<ShopManager>().priceBuy[1])
                                {
                                    hitted = _Hit.transform.gameObject;
                                    Instantiate(gridBank, hitted.transform.position, Quaternion.identity);
                                    Destroy(hitted);
                                    moneySystem.gameObject.GetComponent<MoneySystem>().money -= shopManager.gameObject.GetComponent<ShopManager>().priceBuy[1];
                                    moneySystem.gameObject.GetComponent<MoneySystem>().maxMoney += moneySystem.gameObject.GetComponent<MoneySystem>().moneySafeBank;
                                }
                                break;
                        }
                    }
                    else if(_Hit.transform.tag == "farm" && UIManager.gameObject.GetComponent<UIManager>().id == 2)
                    {
                        if (moneySystem.gameObject.GetComponent<MoneySystem>().money >= shopManager.gameObject.GetComponent<ShopManager>().priceBuy[0] * 3)
                        {
                            hitted = _Hit.transform.gameObject;
                            Instantiate(gridFarm2, hitted.transform.position, Quaternion.identity);
                            Destroy(hitted);
                            moneySystem.gameObject.GetComponent<MoneySystem>().moneyGain -= moneySystem.gameObject.GetComponent<MoneySystem>().moneyFarm[0];
                            moneySystem.gameObject.GetComponent<MoneySystem>().money -= shopManager.gameObject.GetComponent<ShopManager>().priceBuy[0] * 3;
                            moneySystem.gameObject.GetComponent<MoneySystem>().moneyGain += moneySystem.gameObject.GetComponent<MoneySystem>().moneyFarm[1];
                        }
                    }
                    else if(UIManager.gameObject.GetComponent<UIManager>().id == 4)
                    {
                        if(_Hit.transform.tag == "farm")
                        {
                            moneySystem.gameObject.GetComponent<MoneySystem>().money += shopManager.gameObject.GetComponent<ShopManager>().priceSale[0];
                            moneySystem.gameObject.GetComponent<MoneySystem>().moneyGain -= moneySystem.gameObject.GetComponent<MoneySystem>().moneyFarm[0]; 
                        }
                        else if (_Hit.transform.tag == "bank")
                        {
                            moneySystem.gameObject.GetComponent<MoneySystem>().money += shopManager.gameObject.GetComponent<ShopManager>().priceSale[1];
                            moneySystem.gameObject.GetComponent<MoneySystem>().maxMoney -= moneySystem.gameObject.GetComponent<MoneySystem>().moneySafeBank;
                        } else if(_Hit.transform.tag == "farm2")
                        {
                            moneySystem.gameObject.GetComponent<MoneySystem>().money += shopManager.gameObject.GetComponent<ShopManager>().priceSale[0] * 2;
                            moneySystem.gameObject.GetComponent<MoneySystem>().moneyGain -= moneySystem.gameObject.GetComponent<MoneySystem>().moneyFarm[1];
                        }
                        hitted = _Hit.transform.gameObject;
                        Instantiate(grass, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);
                    }
                }
            }

        }
    }
}
