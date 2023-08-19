using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeElement : MonoBehaviour
{
    public Image imageSafe;
    public Image imageNullSafe;
    public Text textSafeData;
    public Button buttonRemoveSafe;
    public Button buttonLoadSafe;
    [HideInInspector] public bool isFull = false;

    public int indexSafeElement;

    public Action<int> OnClickRemoveSafeEvent;

    private void Start()
    {
        buttonRemoveSafe.onClick.AddListener(OnClickRemoveSafe);
    }

    public void OnDrawSafeElement(bool isFull)
    {
        if (isFull == false)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            imageNullSafe.gameObject.SetActive(true);

            this.isFull = false;
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            imageNullSafe.gameObject.SetActive(false);

            this.isFull = true;
        }
    }

    private void OnClickRemoveSafe()
    {
        OnClickRemoveSafeEvent?.Invoke(indexSafeElement);
    }
}
