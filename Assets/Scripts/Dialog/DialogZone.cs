using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogZone : MonoBehaviour
{
    [SerializeField] private DialogManager dialogManager;
    [SerializeField] private int indexDialog;
    [SerializeField] private bool disableAfterTrigger;
    [SerializeField] private TriggerDoor triggerDoor;

    private void Start()
    {
        if (triggerDoor != null)
            triggerDoor.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogManager.StartDialog(indexDialog);
        }
    }

    public void EnableTriggerDoor()
    {
        if (triggerDoor != null)
            triggerDoor.gameObject.SetActive(true);
        if (disableAfterTrigger)
            gameObject.SetActive(false);
    }
}
