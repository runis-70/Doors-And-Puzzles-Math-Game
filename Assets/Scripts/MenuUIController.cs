using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] private Button buttonBegin;
    [SerializeField] private Button buttonContinue;
    [SerializeField] private Button buttonNewGame;
    [SerializeField] private MusicManager musicManager;
    public Fade fade;

    private ReservationManagerIO saveManagerIO;
    private string pathToApplicationFile;
    private ApplicationData applicationData;

    private void Start()
    {
        pathToApplicationFile = Application.persistentDataPath + $"/ApplicationData.dap";
        saveManagerIO = new ReservationManagerIO(pathToApplicationFile);
        applicationData = saveManagerIO.LoadReservationApplicationData();

        if (applicationData != null)
        {
            if (IsThereSave())
            {
                buttonContinue.gameObject.SetActive(true);
                buttonNewGame.gameObject.SetActive(true);
                buttonBegin.gameObject.SetActive(false);
            }
            else
            {
                buttonContinue.gameObject.SetActive(false);
                buttonNewGame.gameObject.SetActive(false);
                buttonBegin.gameObject.SetActive(true);
            }
        }

        Time.timeScale = 1;
        fade.FadeWhite();
    }

    public void LoadLevel(int buildIndex)
    {
        fade.currentIndexScene = buildIndex;
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

    public void NewGame()
    {
        saveManagerIO = new ReservationManagerIO(Application.persistentDataPath);
        saveManagerIO.DeleteAll();

        LoadLevel(2);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool IsThereSave()
    {
        pathToApplicationFile = Application.persistentDataPath + $"/ApplicationData.dap";
        saveManagerIO = new ReservationManagerIO(pathToApplicationFile);
        applicationData = saveManagerIO.LoadReservationApplicationData();

        if (applicationData != null)
        {
            for (int i = 0; i < applicationData.reservationElementUIData.Count; i++)
            {
                if (applicationData.reservationElementUIData[i] != null)
                {
                    return true;
                }
                return false;
            }
        }
        return false;
    }

    public void ApllicationQuit()
    {
        Application.Quit();
    }
}
