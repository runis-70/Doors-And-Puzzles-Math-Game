using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private TMP_InputField inputField;
    public event Action<string> OnInputChanged;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Emergence()
    {
        animator.SetInteger("StateInput", 2);
    }

    public void Disappearance()
    {
        animator.SetInteger("StateInput", 1);
    }

    public void ClearInputField()
    {
        inputField.text = "";
    }

    public void ReadStringInput(string s)
    {
        OnInputChanged?.Invoke(s);
    }
}
