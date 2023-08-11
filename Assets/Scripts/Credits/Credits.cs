using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            creditsPanel.gameObject.SetActive(false);
        }
    }
}
