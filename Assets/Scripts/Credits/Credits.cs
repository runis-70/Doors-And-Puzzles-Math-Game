using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private Animator creditsText;
    [SerializeField] private ParticleSystem particle;

    private void Update()
    {
        if (IsAnimationPlaying("CreditsAnimation") == false)
        {
            creditsPanel.gameObject.SetActive(false);
            particle.transform.position = new Vector3(particle.transform.position.x, particle.transform.position.y, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            creditsPanel.gameObject.SetActive(false);
            particle.transform.position = new Vector3(particle.transform.position.x, particle.transform.position.y, 0);
        }
    }

    public bool IsAnimationPlaying(string animationName)
    {
        var animatorStateInfo = creditsText.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName(animationName))
        {
            return true;
        }
        return false;
    }

    public void EndAnimation()
    {
        creditsPanel.gameObject.SetActive(false);
    }
}
