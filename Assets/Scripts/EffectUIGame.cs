using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectUIGame : MonoBehaviour
{
    public Animator animator;

    public void EmergenceLeft()
    {
        gameObject.SetActive(true);
        animator.SetInteger("State", 2);
    }

    public void DisappearanceRight()
    {
        animator.SetInteger("State", 1);
    }

    public void EmergenceTransparency()
    {
        gameObject.SetActive(true);
        animator.SetInteger("State", 4);
    }

    public void DisappearanceTransparency()
    {
        animator.SetInteger("State", 3);
    }

    public void SetActiveUI()
    {
        gameObject.SetActive(false);
    }
}
