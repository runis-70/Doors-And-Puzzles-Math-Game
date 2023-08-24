using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CutScene : MonoBehaviour
{
    public Fade fade;
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private Animator cutSceneText;
    [SerializeField] private string animationName;
    [SerializeField] private int nextScene;
    [SerializeField] private ParticleSystem particle;

    private void Start()
    {
        Time.timeScale = 1;
        musicManager.SoundResurrection(1f);
        fade.FadeWhite();
    }

    private void Update()
    {
        if (IsAnimationPlaying(animationName) == false)
        {
            LoadLevel(nextScene);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
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
        fade.particle = particle;
        musicManager.SoundDecay(1f);
        fade.FadeBlack();
    }
}
