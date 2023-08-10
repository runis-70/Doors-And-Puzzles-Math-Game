using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private DialogueWindow dialogueWindowPlayer;
    [SerializeField] private DialogueWindow dialogueWindowNPC;
    [SerializeField] private InputController inputController;
    [SerializeField] private float speedText;
    [SerializeField] private Canvas canvasDialog;
    [SerializeField] private UIController uIController;
    [SerializeField] private int currentIndexScene;
    private DialogueScript dialogueScript;
    private bool skipDialog = false;
    private int currentIndexDialogPoint;
    private int currentIndexDialog = -1;

    private void Start()
    {
        dialogueScript = GetComponent<DialogueScript>();
        inputController.OnInputChanged += InputController_OnInputChanged;
    }

    private void InputController_OnInputChanged(string inputText)
    { 
        if (currentIndexDialog != - 1 && dialogueScript.dialogPoints[currentIndexDialogPoint].dialog[currentIndexDialog].Answer == inputText)
        {
            StartCoroutine(EndDialogWaitTime(1));
        }
    }

    public void StartDialog(int indexDialogPoint)
    {
        canvasDialog.gameObject.SetActive(true);
        uIController.gameObject.SetActive(false);
        uIController.playerController.enabled = false;
        uIController.playerController.ZeroPhysic();
        inputController.Emergence();
        currentIndexDialogPoint = indexDialogPoint;
        TypeLine(dialogueScript.dialogPoints[indexDialogPoint]);
    }
    private void EndDialog()
    {
        canvasDialog.gameObject.SetActive(false);
        uIController.gameObject.SetActive(true);
        uIController.playerController.enabled = true;
        inputController.Disappearance();
        inputController.ClearInputField();
        dialogueScript.dialogPoints[currentIndexDialogPoint].dialog[currentIndexDialog].EndDialog.Invoke();
    }

    private IEnumerator EndDialogWaitTime(int time)
    {
        yield return new WaitForSeconds(time);
        EndDialog();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            skipDialog = true;
    }

    public void TypeLine(DialogPoint dialogPoint)
    {
        StartCoroutine(TypeLineIE(dialogPoint));
    }

    IEnumerator TypeLineIE(DialogPoint dialogPoint)
    {

        for (int i = 0; i < dialogPoint.dialog.Count; i++)
        {
            if (dialogPoint.dialog[i].Answer.Length != 0)
                currentIndexDialog = i;

            EnterDrop(dialogPoint.dialog[i]);
            DialogueWindow dialogueWindow = WhoseDialog(dialogPoint.dialog[i]);
            dialogueWindow.Header.sprite = dialogPoint.dialog[i].partnerDialog.Head;
            dialogueWindow.textName.text = dialogPoint.dialog[i].partnerDialog.Name;
            dialogueWindow.textDialog.text = null;
            for (int j = 0; j < dialogPoint.dialog[i].Sentences.ToCharArray().Length; j++)
            {
                if (skipDialog)
                    j = dialogPoint.dialog[i].Sentences.ToCharArray().Length;
                else
                {
                    dialogueWindow.textDialog.text += dialogPoint.dialog[i].Sentences[j];
                    yield return new WaitForSeconds(speedText);
                }
            }

            if (skipDialog)
            {
                ExitDrop(dialogPoint.dialog[i]);
                skipDialog = false;
            }
            else if(dialogPoint.dialog[i].waitSecond != -1)
            {
                yield return new WaitForSeconds(dialogPoint.dialog[i].waitSecond);
                ExitDrop(dialogPoint.dialog[i]);
            }

            if (dialogPoint.dialog[i].isFade)
            {
                EndDialog();
                uIController.fade.currentIndexScene = currentIndexScene;
                uIController.fade.FadeBlack();
            }

            if (i == dialogPoint.dialog.Count - 1 && dialogPoint.dialog[i].waitSecond != -1)
                EndDialog();

            if (dialogPoint.dialog[i].waitSecond != -1)
                dialogPoint.dialog[i].EndDialog.Invoke();
        }      
    }

    private void EnterDrop(Dialog dialog)
    {
        switch (dialog.enterDrop)
        {
            case DropEnum.DropDown:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropDown();
                    else
                        dialogueWindowNPC.DropDown();
                }
                break;

            case DropEnum.DropUp:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropUp();
                    else
                        dialogueWindowNPC.DropUp();
                }
                break;
            case DropEnum.DropRight:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropRight();
                    else
                        dialogueWindowNPC.DropRight();
                }
                break;
            case DropEnum.DropLeft:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropLeft();
                    else
                        dialogueWindowNPC.DropLeft();
                }
                break;
        }
    }
    private void ExitDrop(Dialog dialog)
    {
        switch (dialog.exitDrop)
        {
            case DropEnum.DropDown:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropDown();
                    else
                        dialogueWindowNPC.DropDown();
                }
                break;

            case DropEnum.DropUp:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropUp();
                    else
                        dialogueWindowNPC.DropUp();
                }
                break;
            case DropEnum.DropRight:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropRight();
                    else
                        dialogueWindowNPC.DropRight();
                }
                break;
            case DropEnum.DropLeft:
                {
                    if (dialog.partnerDialog.gameObject.tag == "Player")
                        dialogueWindowPlayer.DropLeft();
                    else
                        dialogueWindowNPC.DropLeft();
                }
                break;
        }
    }
    private DialogueWindow WhoseDialog(Dialog dialog)
    {
        if (dialog.partnerDialog.gameObject.tag == "Player")
            return dialogueWindowPlayer;
        else
            return dialogueWindowNPC;
    }
}
