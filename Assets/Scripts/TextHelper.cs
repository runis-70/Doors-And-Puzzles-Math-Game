using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHelper : MonoBehaviour
{
   private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void SetText(string newText)
    {
        text.text = newText;
    }
}
