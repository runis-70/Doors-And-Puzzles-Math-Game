using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Action<Collider2D> OnTriggerEnter2DEvent;
    public Action<Collider2D> OnTriggerExit2DEvent;
    public Action<Collider2D> OnTriggerStay2DEvent;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEnter2DEvent?.Invoke(collision);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        OnTriggerExit2DEvent?.Invoke(collision);
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerStay2DEvent?.Invoke(collision);
    }
}
