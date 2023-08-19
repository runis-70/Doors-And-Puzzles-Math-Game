using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageSafe : MonoBehaviour
{
    [SerializeField][HideInInspector]public List<SafeElement> safeElements;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            safeElements.Add(transform.GetChild(i).GetComponent<SafeElement>());
        }
    }
}
