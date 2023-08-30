  using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    [Header("Component Console")]
    [SerializeField] private ConsoleWindow consoleWindow;
    [SerializeField] private UIController uIController;
    [Header("Messages")]
    [SerializeField] private List<ConsoleMessagePoint> consoleMessagePoints;
    private int currentIndexConsoleMessagePoint;
    private int currentIndexConsoleMessage = -1;

    private void OnEnable()
    {
        if (consoleMessagePoints.Count >= 1 && consoleMessagePoints[0].consoleMessages.Count >= 1)
            StartWriteMessage(0);
    }

    public void StartWriteMessage(int indexConsoleMessagePoint)
    {
        uIController.playerController.enabled = false;
        uIController.playerController.ZeroPhysic();
        currentIndexConsoleMessagePoint = indexConsoleMessagePoint;
        TypeLine(consoleMessagePoints[indexConsoleMessagePoint]);
    }
    private void EndMessagePoint()
    {
        StartCoroutine(EnablePlayer());
        consoleMessagePoints[currentIndexConsoleMessagePoint].consoleMessages[currentIndexConsoleMessage].EndWriteMessage.Invoke();
    }
    private IEnumerator EnablePlayer()
    {
        yield return new WaitForSeconds(0.4f);
        uIController.playerController.enabled = true;
    }

    public void TypeLine(ConsoleMessagePoint consoleMessagePoint)
    {
        StartCoroutine(TypeLineIE(consoleMessagePoint));
    }

    IEnumerator TypeLineIE(ConsoleMessagePoint consoleMessagePoint)
    {
        for (int i = 0; i < consoleMessagePoint.consoleMessages.Count; i++)
        {
            currentIndexConsoleMessage = i;
            // Style Text
            consoleWindow.textConsole.font = consoleMessagePoint.consoleMessages[i].fontText;
            consoleWindow.textConsole.color = consoleMessagePoint.consoleMessages[i].colorText;
            consoleWindow.textConsole.fontStyle = consoleMessagePoint.consoleMessages[i].fontStyleText;
            if (consoleMessagePoint.consoleMessages[i].clearTextField)
               consoleWindow.textConsole.text = null;

            if (consoleMessagePoint.consoleMessages[i].animatedWriteText)
            {
                for (int j = 0; j < consoleMessagePoint.consoleMessages[i].Message.ToCharArray().Length; j++)
                {
                    consoleWindow.textConsole.text += consoleMessagePoint.consoleMessages[i].Message[j];
                    yield return new WaitForSeconds(consoleMessagePoint.consoleMessages[i].speedText);
                }
            }
            else
                consoleWindow.textConsole.text = consoleMessagePoint.consoleMessages[i].Message;

            yield return new WaitForSeconds(consoleMessagePoint.consoleMessages[i].waitSecond);

            EndMessagePoint();
        }      
    }   

}
