using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class Dialog
{
    [Header("Участник диалога")]
    public PartnerDialog partnerDialog;
    [Header("Анимации начала и конца диалога")]
    public DropEnum enterDrop;
    public DropEnum exitDrop;
    [Header("Скорость текста в диалоги")]
    public float speedText;
    [Header("Настройка текста диалога")]
    public Color colorText = Color.white;
    public Font fontText;
    public FontStyle fontStyleText;
    [Header("Предложения и ответы")]
    public string Sentences;
    public string Answer;
    [Header("События конца диалога")]
    public UnityEvent EndDialog;
    [Header("Ожидание диалога")]
    public float waitSecond;
    [Header("Переключения на следующию сцену")]
    public bool isFade = false;
    public int nextIndexScene;
}
