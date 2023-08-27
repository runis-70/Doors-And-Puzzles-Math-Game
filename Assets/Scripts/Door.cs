using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   private Animator animator;

   public Action<StateDoor> ChangedStateDoor;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

   public void ChangeStateDoor(StateDoor stateDoor)
   {
        switch (stateDoor)
        {
            case StateDoor.Open:
                {
                    animator.SetInteger("StateDoor", 2);
                }
                break;
            case StateDoor.Close:
                {
                    animator.SetInteger("StateDoor", 1);
                }
                break;
        }
        ChangedStateDoor?.Invoke(stateDoor);
   }
   public void OpenDoor()
    {
        ChangeStateDoor(StateDoor.Open);
    }
    public void CloseDoor()
    {
        ChangeStateDoor(StateDoor.Close);
    }

    
}

public enum StateDoor
{
    Open, Close
}
