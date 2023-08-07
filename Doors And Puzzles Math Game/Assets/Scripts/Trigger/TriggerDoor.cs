using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : Trigger
{
    [SerializeField] private Door door;

    private void Start()
    {
        OnTriggerEnter2DEvent += EnterTrigger;
        OnTriggerExit2DEvent += ExitTrigger;
    }

    private void EnterTrigger(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           door.ChangeStateDoor(StateDoor.Open);
        }
    }

    private void ExitTrigger(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            door.ChangeStateDoor(StateDoor.Close);
        }
    }
}
