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
        if (Cards >= 20)
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
        if (Cards >= 10)
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
                PodskazkaText.text = "Ответ - ";
            }

            if (DoorIndex == 20)
            {
                PodskazkaText.text = "Ответ - 6,14 лет";
            }

            if (DoorIndex == 21)
            {
                PodskazkaText.text = "Ответ - 20 децибел";
            }

            if (DoorIndex == 22)
            {
                PodskazkaText.text = "Ответ - 10(19)";
            }

            if (DoorIndex == 23)
            {
                PodskazkaText.text = "Ответ - Клавиша пробел";

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
            }

            if (DoorIndex == 6)
            {
                PodskazkaText.text = "Премените действия с дробями";
            }

            if (DoorIndex == 7)
            {
                PodskazkaText.text = "Введите пробел в поле ответа";
            }

            if (DoorIndex == 8)
            {
                PodskazkaText.text = "Продолжите вычисление - Пусть через x лет площадь леса достигнет 1200 гектаров. Тогда - 1000 * 1,02(x) = 1200 1,02(x) = 1,2";
            }

            if (DoorIndex == 9)
            {
                PodskazkaText.text = "Продолжите вычисление - Пусть начальная численность популяции бактерий составляет n. Тогда через t часов численность популяции будет равна 2n. n * 2(t)";
            }

            if (DoorIndex == 10)
            {
                PodskazkaText.text = "Продолжите вычисление - Пусть начальная концентрация вещества составляет c. Тогда через x лет концентрация вещества будет равна c/1000.";
            }

            if (DoorIndex == 11)
            {
                PodskazkaText.text = "Продолжите вычисление - Пусть начальная численность популяции бактерий составляет n. Тогда через t часов численность популяции будет равна 2n.";
            }

            if (DoorIndex == 12)
            {
                PodskazkaText.text = "Продолжите вычисление - Пусть через x лет стоимость принтера станет равной $500 рублей. Тогда..";
            }

            if (DoorIndex == 13)
            {
                PodskazkaText.text = "Продолжите вычисление - Подставляя I=100, получаем: L=10log100...";
            }

            if (DoorIndex == 14)
            {
                PodskazkaText.text = "Продолжите вычисление - Подставляя t=20, получаем: r = 10(20) = 10(2) * 10(18) = ... ";
            }

            if (DoorIndex == 15)
            {
                PodskazkaText.text = "Введите пробел в поле ответа";
            }

        }
        else
        {
            PodskazkaText.text = "Недостаточно подсказок";
        }
    }

    public void PlusDoorIndex()
    {
        DoorIndex++;
    }


}
