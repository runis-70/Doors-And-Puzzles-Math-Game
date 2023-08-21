using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class ReservationManager : MonoBehaviour
{
    [SerializeField] private GameObject contentPage;
    [SerializeField] private GameObject DeleteAnswerPanel;
    [SerializeField][HideInInspector] private List<PageReservation> pageSafes;
    private ReservationManagerIO saveManagerIO;
    private List<ReservationElementUIData> reservationElementUIDatas;
    [SerializeField] private Player player;

    private string pathToApplicationFile;
    private ApplicationData applicationData;

    private void Awake()
    {
        pathToApplicationFile = Application.persistentDataPath + $"/ApplicationData.dap";
        saveManagerIO = new ReservationManagerIO(pathToApplicationFile);

        for (int i = 0; i < contentPage.transform.childCount; i++)
        {
            pageSafes.Add(contentPage.transform.GetChild(i).GetChild(0).GetComponent<PageReservation>());
        }

        if (saveManagerIO.LoadReservationApplicationData() == null)
        {
            applicationData = new ApplicationData();
            reservationElementUIDatas = new List<ReservationElementUIData>();
            for (int i = 0; i < pageSafes.Count; i++)
            {
                for (int j = 0; j < pageSafes[i].reservationElements.Count; j++)
                {
                    reservationElementUIDatas.Add(new ReservationElementUIData());
                }
            }
        }
        else
        {
            applicationData = saveManagerIO.LoadReservationApplicationData();
            reservationElementUIDatas = new List<ReservationElementUIData>(applicationData.reservationElementUIData);
        }
    }

    private void Start()
    {
        DrawReservationElements();
    }

    private void DrawReservationElements()
    {
        if (pageSafes.Count != 0)
        {
            int temp = 0;
            for (int i = 0; i < pageSafes.Count; i++)
            {
                for (int j = 0; j < pageSafes[i].reservationElements.Count; j++)
                {
                    pageSafes[i].reservationElements[j].indexReservationElement = j + temp;
                    pageSafes[i].reservationElements[j].OnClickRemoveReservationEvent += (index) =>
                    {
                        RemoveReservation(index);
                    };
                    if (pageSafes[i].reservationElements[j].stateReservationElementUI == StateReservationElementUI.LoadReservation)
                    {
                        pageSafes[i].reservationElements[j].OnClickLoadReservationEvent += (index) =>
                        {
                            LoadReservation(index);
                        };
                    }
                    else if (pageSafes[i].reservationElements[j].stateReservationElementUI == StateReservationElementUI.CreateReservation)
                    {
                        pageSafes[i].reservationElements[j].OnClickCreateReservationEvent += (index) =>
                        {
                            AddReservation(index);
                        };
                    }

                    if (FindReservationElementDataOfIndex(pageSafes[i].reservationElements[j].indexReservationElement) == null)
                    {
                        ReservationElementUIData reservationElementUIData = new ReservationElementUIData();
                        pageSafes[i].reservationElements[j].OnDrawReservationElement(reservationElementUIData.isFull);
                    }
                    else
                    {
                        ReservationElementUIData reservationElementUIData = FindReservationElementDataOfIndex(pageSafes[i].reservationElements[j].indexReservationElement);
                        pageSafes[i].reservationElements[j].OnDrawReservationElement(reservationElementUIData.isFull);
                    }
                }
                temp = pageSafes[i].reservationElements.Count;
            }
        }
    }

    private ReservationElementUI FindReservationElementOfIndex(int indexReservation)
    {
        for (int i = 0; i < pageSafes.Count; i++)
        {
            for (int j = 0; j < pageSafes[i].reservationElements.Count; j++)
            {
                if (pageSafes[i].reservationElements[j].indexReservationElement == indexReservation)
                {
                    return pageSafes[i].reservationElements[j];
                }
            }
        }
        return null;
    }

    private void AddReservationElementDataOfIndex(int indexReservation, ReservationElementUIData reservationElementUIData)
    {
        for (int i = 0; i < pageSafes.Count; i++)
        {
            for (int j = 0; j < pageSafes[i].reservationElements.Count; j++)
            {
                if (pageSafes[i].reservationElements[j].indexReservationElement == indexReservation)
                {
                    reservationElementUIDatas[indexReservation] = reservationElementUIData;
                }
            }
        }
    }

    private ReservationElementUIData FindReservationElementDataOfIndex(int indexReservation)
    {
        for (int i = 0; i < reservationElementUIDatas.Count; i++)
        {
            if (reservationElementUIDatas[i].indexReservationElementUI == indexReservation)
            {
                return reservationElementUIDatas[i];
            }
        }
        return null;
    }

    public void LoadReservation(int indexReservation)
    {

    }

    public void AddReservation(int indexReservation)
    {
        if (player != null)
        {
            PlayerData playerData = new PlayerData(player);
            string path = 
                Application.persistentDataPath 
                + $"/{DateTime.Now.ToString("MM/dd/yyyy")}_{DateTime.Now.ToString("HHmmss")}.dap";

            ReservationElementUI reservationElementUI = FindReservationElementOfIndex(indexReservation);
            reservationElementUI.OnDrawReservationElement(true);
            reservationElementUI.OnDrawAfterReservation
                ($"{DateTime.Now.ToString("MM/dd/yyyy")} {DateTime.Now.ToString("HH:mm:ss")}");

            saveManagerIO = new ReservationManagerIO(path);
            saveManagerIO.CreateReservationPlayerData(playerData);

            ReservationElementUIData reservationElementUIData = new ReservationElementUIData();

            reservationElementUIData.indexReservationElementUI = reservationElementUI.indexReservationElement;
            reservationElementUIData.isFull = reservationElementUI.isFull;
            reservationElementUIData.path = path;


            AddReservationElementDataOfIndex(indexReservation, reservationElementUIData);

            applicationData.reservationElementUIData = reservationElementUIDatas;

            saveManagerIO = new ReservationManagerIO(pathToApplicationFile);
            saveManagerIO.CreateReservationApplicationData(applicationData);
        }
    }

    public void RemoveReservation(int indexReservation)
    {
        DeleteAnswerPanel.gameObject.SetActive(true);
        for (int i = 0; i < DeleteAnswerPanel.transform.GetChild(0).transform.childCount; i++)
        {
            if (DeleteAnswerPanel.transform.GetChild(0).transform.GetChild(i).name == "Yes")
            {
                DeleteAnswerPanel.
transform.GetChild(0).
transform.GetChild(i).
transform.GetComponent<Button>().
onClick.RemoveAllListeners();

                DeleteAnswerPanel.
                    transform.GetChild(0).
                    transform.GetChild(i).
                    transform.GetComponent<Button>().
                    onClick.AddListener(
                    () =>
                    {
                        for (int i = 0; i < pageSafes.Count; i++)
                        {
                            for (int j = 0; j < pageSafes[i].reservationElements.Count; j++)
                            {
                                if (pageSafes[i].reservationElements[j].indexReservationElement == indexReservation)
                                {
                                    pageSafes[i].reservationElements[j].OnDrawReservationElement(false);
                                    ReservationElementUIData reservationElementUIData = FindReservationElementDataOfIndex(pageSafes[i].reservationElements[j].indexReservationElement);
                                    saveManagerIO = new ReservationManagerIO(reservationElementUIData.path);
                                    saveManagerIO.Delete();

                                    saveManagerIO = new ReservationManagerIO(pathToApplicationFile);

                                    reservationElementUIData.indexReservationElementUI = -1;
                                    reservationElementUIData.isFull = false;
                                    reservationElementUIData.path = "";

                                    AddReservationElementDataOfIndex(indexReservation, reservationElementUIData);

                                    applicationData.reservationElementUIData = reservationElementUIDatas;

                                    saveManagerIO.CreateReservationApplicationData(applicationData);
                                }
                            }
                        }
                        DeleteAnswerPanel.gameObject.SetActive(false);
                    }
                    );
            }
        }
    }

    public void ClearAllReservation()
    {
        for (int i = 0; i < pageSafes.Count; i++)
        {
            for (int j = 0; j < pageSafes[i].reservationElements.Count; j++)
            {
                pageSafes[i].reservationElements[j].OnDrawReservationElement(false);
            }
        }
    }

    public void AutoReservation()
    {
        if (player != null)
        {
            PlayerData playerData = new PlayerData(player);
            string path = Application.persistentDataPath 
                + $"/{DateTime.Now.ToString("MM/dd/yyyy")}_{DateTime.Now.ToString("HHmmss")}.dap";
            saveManagerIO = new ReservationManagerIO(path);
            saveManagerIO.CreateReservationPlayerData(playerData);
        }
    }
}
