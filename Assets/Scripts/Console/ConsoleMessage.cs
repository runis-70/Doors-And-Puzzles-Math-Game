using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

[System.Serializable]
public class ConsoleMessage
{
    [Header("Ñêîðîñòü òåêñòà â äèàëîãè")]
    public float speedText;
    [Header("Íàñòðîéêà òåêñòà äèàëîãà")]
    public Color colorText = Color.white;
    public Font fontText;
    public FontStyle fontStyleText;
    [Header("Ïðåäëîæåíèÿ è îòâåòû")]
    [TextArea(3, 10)]
    public string Message;
    [Header("Ñîáûòèÿ êîíöà äèàëîãà")]
    public UnityEvent EndWriteMessage;
    [Header("Îæèäàíèå äèàëîãà")]
    public float waitSecond;
    [Header("Анимация написания текста")]
    public bool animatedWriteText = false;
    [Header("Очищать текстовое поле")]
    public bool clearTextField = false;
}
