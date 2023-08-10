using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Fade fade;

    private void Start()
    {
        ChangeTimeScale(1);
        fade.FadeWhite();
    }

    public void LoadLevel(int buildIndex)
    {
        fade.currentIndexScene = buildIndex;
        fade.FadeBlack();
    }

    public void ChangeTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }


    public void SetActiveUI(GameObject gameObject)
    {
        if (gameObject.activeInHierarchy == false)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
