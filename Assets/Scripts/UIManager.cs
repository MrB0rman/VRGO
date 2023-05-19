using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Animator shopPanel;

    public AudioSource click;
    public AudioSource back;

    public Slider changingSound;

    public GameObject gameGrid;

    public GameObject game;
    public GameObject menu;

    bool isClick = false;
    public GameObject moneySystem;
    public int id = 1;
    public void Update()
    {
        
    }

    public void ToggleMenu()
    {
        id = 1;
        bool isHidden = shopPanel.GetBool("isHidden");
        shopPanel.SetBool("isHidden", !isHidden);
        click.Play();
        Cursor.SetCursor(gameGrid.GetComponent<GameGrid>().cursorBase, gameGrid.GetComponent<GameGrid>().hotSpot, gameGrid.GetComponent<GameGrid>().cursorMode);
    }
    public void cursorFarm()
    {
        id = 2;
        Cursor.SetCursor(gameGrid.GetComponent<GameGrid>().farm, gameGrid.GetComponent<GameGrid>().hotSpot, gameGrid.GetComponent<GameGrid>().cursorMode);   
    }
    public void cursorBank()
    {
        id = 3;
        Cursor.SetCursor(gameGrid.GetComponent<GameGrid>().bank, gameGrid.GetComponent<GameGrid>().hotSpot, gameGrid.GetComponent<GameGrid>().cursorMode);
    }
    public void sale()
    {
        click.Play();
        if(!isClick)
        {
            id = 4;
            Cursor.SetCursor(gameGrid.GetComponent<GameGrid>().sale, gameGrid.GetComponent<GameGrid>().hotSpot, gameGrid.GetComponent<GameGrid>().cursorMode);
            isClick = true;
        }
        else
        {
            id = 1;
            Cursor.SetCursor(gameGrid.GetComponent<GameGrid>().cursorBase, gameGrid.GetComponent<GameGrid>().hotSpot, gameGrid.GetComponent<GameGrid>().cursorMode);
            isClick = false;
        }
        
    }
    public void volumeBack()
    {
        back.volume = changingSound.value;
    }
    public void menuCanvas()
    {
        id = 1;
        Cursor.SetCursor(gameGrid.GetComponent<GameGrid>().cursorBase, gameGrid.GetComponent<GameGrid>().hotSpot, gameGrid.GetComponent<GameGrid>().cursorMode);
        game.SetActive(false);
        menu.SetActive(true);
    }
    public void gameCanvas()
    {
        menu.SetActive(false);
        game.SetActive(true);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
