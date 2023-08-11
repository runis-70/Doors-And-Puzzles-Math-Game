using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    public event Action<string> OnInputChanged;

    public void ClearInputField()
    {
        inputField.text = "";
    }

    public void ReadStringInput(string s)
    {
        OnInputChanged?.Invoke(s);
    }
}
