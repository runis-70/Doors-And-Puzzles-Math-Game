using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public Fade fade;
    [SerializeField] private Animator cutSceneText;
    [SerializeField] private string animationName;
    [SerializeField] private int nextScene;

    private void Start()
    {
        Time.timeScale = 1;
        fade.FadeWhite();
    }

    private void Update()
    {
        if (IsAnimationPlaying(animationName) == false)
        {
            LoadLevel(nextScene);
        }
    }

    public bool IsAnimationPlaying(string animationName)
    {
        var animatorStateInfo = cutSceneText.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName(animationName))
            return true;
        return false;
    }


    public void LoadLevel(int buildIndex)
    {
        fade.currentIndexScene = buildIndex;
        fade.FadeBlack();
    }
}
