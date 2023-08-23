using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Player playerController;
    [SerializeField] private Text scoreText;

    public Fade fade;

    [SerializeField] private GameObject panels;

    private void Update()
    {
        if (panels != null && Input.GetKeyDown(KeyCode.Escape))
        {          
            for (int i = 0; i < panels.transform.childCount; i++)
            {
                if (panels.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    panels.transform.GetChild(i).gameObject.SetActive(false);
                    Time.timeScale = 1f;
                }
                else if (panels.transform.GetChild(i).gameObject.tag == "Pause")
                {
                    panels.transform.GetChild(i).gameObject.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
            
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
        playerController.OnRecountedScore += PlayerController_OnRecountedScore;
        fade.FadeWhite();
    }

    private void PlayerController_OnRecountedScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }


    public void LoadLevel(int buildIndex)
    {
        fade.currentIndexScene = buildIndex;
        if (panels != null)
        {
            for (int i = 0; i < panels.transform.childCount; i++)
            {
                if (panels.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    panels.transform.GetChild(i).gameObject.SetActive(false);
                    Time.timeScale = 1f;
                }
            }

        }
        fade.FadeBlack();
    }
    public void ChangeTimeScale(int timeScale)
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
