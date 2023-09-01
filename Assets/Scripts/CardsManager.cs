using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour
{
    [SerializeField] private DialogManager dialogManager;

    [SerializeField] private Text CardsText;
    [SerializeField] private Text FichesText;
    [SerializeField] private Text PodskazkaText;
    public GameObject[] PodskazkaIcons;
    public GameObject[] OtvetIcons;
    public GameObject Terminal;
    public GameObject TerminalPanel;
    public int DoorIndex;

    private int countCard = 0;
    private int AnswerCount;


    private void RecountCards(int card)
    {
        countCard += card;
        countCard = Mathf.Clamp(countCard, 0, 1000);
        CardsText.text = "" + countCard;
    }

    public void OtvetBuy()
    {
        if (countCard >= 20)
        {
            RecountCards(-20);
            CardsText.text = "" + countCard;
            OtvetIcons[1].SetActive(true);
            OtvetIcons[0].SetActive(false);
            FichesText.text = "Вам выданы были выданы пропуска";
            AnswerCount++;
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
        if (countCard >= 10)
        {
            countCard -= 25;
            CardsText.text = "" + countCard;
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

  
    

    public void MadeOtvet()
    {
        if (AnswerCount >= 1)
        { 
            
            OtvetIcons[0].SetActive(true);
            OtvetIcons[1].SetActive(false);
            AnswerCount--;

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
                PodskazkaText.text = "Ответ - Клавиша пробел";
            }

            if (DoorIndex == 8)
            {
                PodskazkaText.text = "Ответ - 10,26 лет";
            }

            if (DoorIndex == 9)
            {
                PodskazkaText.text = "Ответ - 1 ч";
            }

            if (DoorIndex == 10)
            {
                PodskazkaText.text = "Ответ - 12,57 лет";
            }

            if (DoorIndex == 11)
            {
                PodskazkaText.text = "Ответ - 10 ч";
            }

            if (DoorIndex == 12)
            {
                PodskazkaText.text = "Ответ - 6,14 лет";
            }

            if (DoorIndex == 13)
            {
                PodskazkaText.text = "Ответ - 20 децибел";
            }

            if (DoorIndex == 14)
            {
                PodskazkaText.text = "Ответ - 10(19)";
            }

            if (DoorIndex == 15)
            {
                PodskazkaText.text = "Ответ - Клавиша пробел";

            }

            if (DoorIndex == 16)
            {
                PodskazkaText.text = "Ответ - 0";
            }

            if (DoorIndex == 17)
            {
                PodskazkaText.text = "Ответ - -4";
            }

            if (DoorIndex == 18)
            {
                PodskazkaText.text = "Ответ - (1, 1)";
            }

            if (DoorIndex == 19)
            {
                PodskazkaText.text = "Ответ - (0, 3)";
            }

            if (DoorIndex == 20)
            {
                PodskazkaText.text = "Ответ - 4, 2";
            }

            if (DoorIndex == 21)
            {
                PodskazkaText.text = "Ответ - (0, 0)";
            }

            if (DoorIndex == 22)
            {
                PodskazkaText.text = "Ответ - (2, 1)";
            }

            if (DoorIndex == 23)
            {
                PodskazkaText.text = "Ответ - Клавиша пробел";

            }

            if (DoorIndex == 24)
            {
                PodskazkaText.text = "Ответ - 2";
            }

            if (DoorIndex == 25)
            {
                PodskazkaText.text = "Ответ - n/4";
            }

            if (DoorIndex == 26)
            {
                PodskazkaText.text = "Ответ - 24";
            }

            if (DoorIndex == 27)
            {
                PodskazkaText.text = "Ответ - x=11 y=26";
            }

            if (DoorIndex == 28)
            {
                PodskazkaText.text = "Ответ - a(2)/8";
            }

         
        }
        else
        {
            PodskazkaText.text = "Недостаточно ответов";
        }
    }

  
          
    

    public void PlusDoorIndex()
    {
        DoorIndex++;
    }


}
