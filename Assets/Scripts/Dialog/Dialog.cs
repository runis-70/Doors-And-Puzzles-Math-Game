using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class Dialog
{
    [Header("Ó÷àñòíèê äèàëîãà")]
    public PartnerDialog partnerDialog;
    [Header("Àíèìàöèè íà÷àëà è êîíöà äèàëîãà")]
    public DropEnum enterDrop;
    public DropEnum exitDrop;
    [Header("Ñêîðîñòü òåêñòà â äèàëîãè")]
    public float speedText;
    [Header("Íàñòðîéêà òåêñòà äèàëîãà")]
    public Color colorText = Color.white;
    public Font fontText;
    public FontStyle fontStyleText;
    [Header("Ïðåäëîæåíèÿ è îòâåòû")]
    public string Sentences;
    public string Answer;
    [Header("Ñîáûòèÿ êîíöà äèàëîãà")]
    public UnityEvent EndDialog;
    [Header("Îæèäàíèå äèàëîãà")]
    public float waitSecond;
    [Header("Ïåðåêëþ÷åíèÿ íà ñëåäóþùèþ ñöåíó")]
    public bool isFade = false;
    public int nextIndexScene;
}
