using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeLoader : MonoBehaviour
{
    [SerializeField] private GameObject contentPage;
    [SerializeField] private GameObject DeleteAnswerPanel;
    [SerializeField][HideInInspector] private List<PageSafe> pageSafes;
    private SaveManager saveManager;

    private void Awake()
    {
        string path = Application.persistentDataPath;
        saveManager = new SaveManager(path);

        for (int i = 0; i < contentPage.transform.childCount; i++)
        {
            pageSafes.Add(contentPage.transform.GetChild(i).GetChild(0).GetComponent<PageSafe>());
        }
    }

    private void Start()
    {
        DrawSafeElements();
    }

    private void DrawSafeElements()
    {
        if (pageSafes.Count != 0)
        {
            int temp = 0;
            for (int i = 0; i < pageSafes.Count; i++)
            {
                for (int j = 0; j < pageSafes[i].safeElements.Count; j++)
                {
                    pageSafes[i].safeElements[j].indexSafeElement = j + temp;
                    pageSafes[i].safeElements[j].OnClickRemoveSafeEvent += (index) =>
                    {
                        ShowDeleteSafePanel(index);
                    };
                    pageSafes[i].safeElements[j].OnDrawSafeElement(true);
                }
                temp = pageSafes[i].safeElements.Count;
            }
        }
    }

    public void AddSafe()
    {
        
    }

    public void RemoveSafe()
    {

    }

    public void ClearAllSafe()
    {

    }

    private void ShowDeleteSafePanel(int index)
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
                            for (int j = 0; j < pageSafes[i].safeElements.Count; j++)
                            {
                                if (pageSafes[i].safeElements[j].indexSafeElement == index)
                                {
                                    pageSafes[i].safeElements[j].OnDrawSafeElement(false);
                                }
                            }
                        }
                        DeleteAnswerPanel.gameObject.SetActive(false);
                    }
                    );
            }
        }
    }
}
