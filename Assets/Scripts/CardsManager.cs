using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour
{

    public int Cards = 0;
    public Text CardsText;
    public Text FichesText;
    public GameObject[] PodskazkaIcons;
    public GameObject[] OtvetIcons;
    public GameObject Terminal;
    public BoxCollider2D col;
    public GameObject TerminalPanel;
    void Start()
    {
        col = Terminal.GetComponent<BoxCollider2D>();
    }

    public void PlusCards()
    {
        Cards+= 10;
        CardsText.text = "" + Cards;
    }

    public void OtvetBuy()
    {
        if (Cards >= 20)
        {
            Cards -= 20;
            CardsText.text = "" + Cards;
            OtvetIcons[1].SetActive(true);
            OtvetIcons[0].SetActive(false);
            FichesText.text = "Вам выданы были выданы пропуска";
        }
       else
        {

            OtvetIcons[0].SetActive(true);
            OtvetIcons[1].SetActive(false);
            FichesText.text = "Недостаточно карт доступа";
        }
    }

    public void PodskazkaBuy()
    {
        if (Cards >= 10)
        {
            Cards -= 10;
            CardsText.text = "" + Cards;
            PodskazkaIcons[1].SetActive(true);
            PodskazkaIcons[0].SetActive(false);
            FichesText.text = "Вам выданы были выданы пропуска";
        }
        else
        {

            PodskazkaIcons[0].SetActive(true);
            PodskazkaIcons[1].SetActive(false);
            FichesText.text = "Недостаточно карт доступа";
        }
    }

    //private void OnTriggerEnter2D(BoxCollider2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        TerminalPanel.SetActive(true);
    //    }
    //}

}
