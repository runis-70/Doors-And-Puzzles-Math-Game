using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleWindow : MonoBehaviour
{
    public Text textConsole;

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
