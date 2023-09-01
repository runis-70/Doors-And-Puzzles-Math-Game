using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject attentionPanel;
    [SerializeField] private MusicManager musicManager;
    public Player playerController;
    public Fade fade;

    [SerializeField] private GameObject panels;
    private ApplicationData applicationData;
    private string pathToApplicationFile;

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
        musicManager.SoundResurrection(1f);
        fade.FadeWhite();

        pathToApplicationFile = Application.persistentDataPath + $"/ApplicationData.dap";
        ReservationManagerIO saveManagerIO = new ReservationManagerIO(pathToApplicationFile);

        if (saveManagerIO.LoadReservationApplicationData() == null)
        {
            applicationData = new ApplicationData();
            attentionPanel.SetActive(true);
        }
        else
        {
            applicationData = saveManagerIO.LoadReservationApplicationData();
            if (applicationData.isFirstStart == false)
                attentionPanel.SetActive(false);
            else
                attentionPanel.SetActive(true);
        }
    }

    public void SetFirstStart(bool value)
    {
        ReservationManagerIO saveManagerIO = new ReservationManagerIO(pathToApplicationFile);
        saveManagerIO = new ReservationManagerIO(pathToApplicationFile);
        applicationData.isFirstStart = value;
        saveManagerIO.CreateReservationApplicationData(applicationData);
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
        musicManager.SoundDecay(1f);
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
