using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour
{

    public int Cards = 0;
    public int Podskazka;
    public int Otvet;
    public Text CardsText;
    public Text FichesText;
    public Text PodskazkaText;
    public Text OtvetText;
    public GameObject[] PodskazkaIcons;
    public GameObject[] OtvetIcons;
    public GameObject Terminal;
    public BoxCollider2D col;
    public GameObject TerminalPanel;
    public int DoorIndex;

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
        if (Cards >= 30)
        {
            Cards -= 30;
            CardsText.text = "" + Cards;
            OtvetIcons[1].SetActive(true);
            OtvetIcons[0].SetActive(false);
            FichesText.text = "Вам выданы были выданы пропуска";
            Otvet++;
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
        if (Cards >= 25)
        {
            Cards -= 25;
            CardsText.text = "" + Cards;
            PodskazkaIcons[1].SetActive(true);
            PodskazkaIcons[0].SetActive(false);
            FichesText.text = "Вам выданы были выданы пропуска";
            Podskazka++;
        }
        else
        {

            PodskazkaIcons[0].SetActive(true);
            PodskazkaIcons[1].SetActive(false);
            FichesText.text = "Недостаточно карт доступа";
        }
    }

  
    

    public void MadeOtvet()
    {
        if (Otvet >= 1)
        { 
            
            OtvetIcons[0].SetActive(true);
            OtvetIcons[1].SetActive(false);
            Otvet--;

            if (DoorIndex == 0)
            {
                PodskazkaText.text = "Ответ - 39,6";
            }

            if (DoorIndex == 1)
            {
                PodskazkaText.text = "Ответ - -2,32";
            }

            if (DoorIndex == 2)
            {
                PodskazkaText.text = "Ответ - 4950";
            }

            if (DoorIndex == 3)
            {
                PodskazkaText.text = "Ответ - 12500";
            }

            if (DoorIndex == 4)
            {
                PodskazkaText.text = "Ответ - 2,5";
            }

            if (DoorIndex == 5)
            {
                PodskazkaText.text = "Ответ - 56%";
            }

            if (DoorIndex == 6)
            {
                PodskazkaText.text = "Ответ - 105";
            }

            if (DoorIndex == 7)
            {
                PodskazkaText.text = "Ответ - 0,72";
            }
        }
        else
        {
            PodskazkaText.text = "Недостаточно ответов";
        }
    }

    public void MadePodskazka()
    {
        if (Podskazka >= 1)
        {

            PodskazkaIcons[0].SetActive(true);
            PodskazkaIcons[1].SetActive(false);
            Podskazka--;

            if (DoorIndex == 0)
            {
                PodskazkaText.text = "Считайте сначала значение в скобках, а далее умножите его на 7,2";
            }

            if (DoorIndex == 1)
            {
                PodskazkaText.text = "Помните - / = дробная черта";
            }

            if (DoorIndex == 2)
            {
                PodskazkaText.text = "Найдите 10% от изначальной суммы и прибавьте к изначальной сумме";
            }

            if (DoorIndex == 3)
            {
                PodskazkaText.text = "Сосчитайте проценты от числа";
            }

            if (DoorIndex == 4)
            {
                PodskazkaText.text = "Сосчитайте сначала свежие грибы без воды, а затем сухие без воды, применив действия с долями";
            }

            if (DoorIndex == 5)
            {
                PodskazkaText.text = "Получите цену января, далее цену февраля от цены января, а далее от начальной цены";

                if (DoorIndex == 6)
                {
                    PodskazkaText.text = "";
                }

                if (DoorIndex == 7)
                {
                    PodskazkaText.text = "Ответ - 0,72";
                }
            }
            else
            {
                PodskazkaText.text = "Недостаточно ответов";
            }
        }
    }

    public void PlusDoorIndex()
    {
        DoorIndex++;
    }


}
