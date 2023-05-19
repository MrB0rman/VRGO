using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public GameObject moneySystem;
    public GameObject gameGrid;

    public void Save()
    {
        GameObject[] grid = GameObject.FindGameObjectsWithTag("grid");
        for(int i = 0; i < grid.Length; ++i)
        {
            PlayerPrefs.SetFloat("gridX" + i, grid[i].transform.position.x);
            PlayerPrefs.SetFloat("gridZ" + i, grid[i].transform.position.z);
        }
        GameObject[] farm = GameObject.FindGameObjectsWithTag("farm");
        for (int i = 0; i < farm.Length; ++i)
        {
            PlayerPrefs.SetFloat("farmX" + i, farm[i].transform.position.x);
            PlayerPrefs.SetFloat("farmZ" + i, farm[i].transform.position.z);
        }
        GameObject[] bank = GameObject.FindGameObjectsWithTag("bank");
        for (int i = 0; i < bank.Length; ++i)
        {
            PlayerPrefs.SetFloat("bankX" + i, bank[i].transform.position.x);
            PlayerPrefs.SetFloat("bankZ" + i, bank[i].transform.position.z);
        }
        GameObject[] farm2 = GameObject.FindGameObjectsWithTag("farm2");
        for (int i = 0; i < farm2.Length; ++i)
        {
            PlayerPrefs.SetFloat("farm2X" + i, farm2[i].transform.position.x);
            PlayerPrefs.SetFloat("farm2Z" + i, farm2[i].transform.position.z);
        }

        PlayerPrefs.SetInt("scoreGrid", grid.Length);
        PlayerPrefs.SetInt("scoreFarm", farm.Length);
        PlayerPrefs.SetInt("scoreBank", bank.Length);
        PlayerPrefs.SetInt("scoreFarm2", farm2.Length);

        PlayerPrefs.SetInt("money", moneySystem.GetComponent<MoneySystem>().money);
        PlayerPrefs.SetInt("maxMoney", moneySystem.GetComponent<MoneySystem>().maxMoney);
        PlayerPrefs.SetInt("moneyGain", moneySystem.GetComponent<MoneySystem>().moneyGain);
        PlayerPrefs.SetInt("isSave", 1);
    }

    public void Load()
    {
        if(PlayerPrefs.HasKey("isSave"))
        {         
            moneySystem.GetComponent<MoneySystem>().money = PlayerPrefs.GetInt("money");
            moneySystem.GetComponent<MoneySystem>().maxMoney = PlayerPrefs.GetInt("maxMoney");
            moneySystem.GetComponent<MoneySystem>().moneyGain = PlayerPrefs.GetInt("moneyGain");
            GameObject[] grid = GameObject.FindGameObjectsWithTag("grid");
            for (int i = 0; i < grid.Length; ++i)
            {
                Destroy(grid[i]);
            }
            GameObject[] farm = GameObject.FindGameObjectsWithTag("farm");
            for (int i = 0; i < farm.Length; ++i)
            {
                Destroy(farm[i]);
            }
            GameObject[] bank = GameObject.FindGameObjectsWithTag("bank");
            for (int i = 0; i < bank.Length; ++i)
            {
                Destroy(bank[i]);
            }
            GameObject[] farm2 = GameObject.FindGameObjectsWithTag("farm2");
            for (int i = 0; i < farm2.Length; ++i)
            {
                Destroy(farm2[i]);
            }

            int scoreGrid = PlayerPrefs.GetInt("scoreGrid"),
                scoreFarm = PlayerPrefs.GetInt("scoreFarm"),
                scoreBank = PlayerPrefs.GetInt("scoreBank"),
                scoreFarm2 = PlayerPrefs.GetInt("scoreFarm2");
            for (int i = 0; i < scoreGrid; ++i)
            {
                float x = PlayerPrefs.GetFloat("gridX" + i);
                float z = PlayerPrefs.GetFloat("gridZ" + i);
                Instantiate(gameGrid.GetComponent<GameGrid>().grass, new Vector3(x, 0, z), Quaternion.identity);
            }
            for (int i = 0; i < scoreFarm; ++i)
            {
                float x = PlayerPrefs.GetFloat("farmX" + i);
                float z = PlayerPrefs.GetFloat("farmZ" + i);
                Instantiate(gameGrid.GetComponent<GameGrid>().gridFarm, new Vector3(x, 0, z), Quaternion.identity);
            }
            for (int i = 0; i < scoreBank; ++i)
            {
                float x = PlayerPrefs.GetFloat("bankX" + i);
                float z = PlayerPrefs.GetFloat("bankZ" + i);
                Instantiate(gameGrid.GetComponent<GameGrid>().gridBank, new Vector3(x, 0, z), Quaternion.identity);
            }
            for (int i = 0; i < scoreFarm2; ++i)
            {
                float x = PlayerPrefs.GetFloat("farm2X" + i);
                float z = PlayerPrefs.GetFloat("farm2Z" + i);
                Instantiate(gameGrid.GetComponent<GameGrid>().gridFarm2, new Vector3(x, 0, z), Quaternion.identity);
            }
        }
    }
}
