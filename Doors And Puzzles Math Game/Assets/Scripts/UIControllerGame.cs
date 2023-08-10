using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerGame : UIController
{
    public PlayerController playerController;
    [SerializeField] private Text scoreText;

    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;

    [SerializeField] private GameObject allPanels;

    private void Awake()
    {
        playerController.OnRecountedScore += PlayerController_OnRecountedScore;
    }

    private void PlayerController_OnRecountedScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void Lose()
    {
        ChangeTimeScale(0);
        losePanel.SetActive(true);
        playerController.enabled = false;
        playerController.ZeroPhysic();
    }
    public void Win()
    {
        ChangeTimeScale(0);
        winPanel.SetActive(true);
        playerController.enabled = false;
        playerController.ZeroPhysic();
    }

    private void Update()
    {
        if (allPanels != null && Input.GetKeyDown(KeyCode.Escape))
        {
            for (int i = 0; i < allPanels.transform.childCount; i++)
            {
                if (allPanels.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    allPanels.transform.GetChild(i).gameObject.SetActive(false);
                    Time.timeScale = 1f;
                }
                else if (allPanels.transform.GetChild(i).gameObject.tag == "Pause" && losePanel.gameObject.activeInHierarchy == false && winPanel.gameObject.activeInHierarchy == false)
                {
                    allPanels.transform.GetChild(i).gameObject.SetActive(true);
                    Time.timeScale = 0f;
                }
            }

        }
    }
}
