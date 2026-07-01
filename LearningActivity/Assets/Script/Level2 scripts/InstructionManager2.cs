using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstructionManager2 : MonoBehaviour
{
    public GameObject instructionPanel;
    public GameObject resetConfirmPanel;

    public AnswerButtonSingle[] answerButtons;
    private static bool instructionClosedThisSession = false;


    void Start()
    {
 if (instructionClosedThisSession)
        {
            instructionPanel.SetActive(false);
        }
        else
        {
            instructionPanel.SetActive(true);
        }
    }


    // RESET BUTTON CLICK
    public void ShowResetConfirmation()
    {
        Debug.Log("RESET BUTTON CLICKED");

        resetConfirmPanel.SetActive(true);

        DisableAnswers();   // disable answer buttons
    }



    // YES BUTTON
    public void ConfirmReset()
    {
        Debug.Log("YES BUTTON WORKING");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    // NO BUTTON
    public void CancelReset()
    {
        Debug.Log("NO BUTTON WORKING");

        resetConfirmPanel.SetActive(false);

        EnableAnswers();   // enable answer buttons again
    }



    public void CloseInstructions()
    {
        instructionPanel.SetActive(false);
              instructionClosedThisSession = true;

    }



    public void GoHome()
    {
        SceneManager.LoadScene("HomePage");
    }



    void DisableAnswers()
    {
        foreach(AnswerButtonSingle answer in answerButtons)
        {
            answer.GetComponent<Button>().interactable = false;
        }
    }



    void EnableAnswers()
    {
        foreach(AnswerButtonSingle answer in answerButtons)
        {
            answer.GetComponent<Button>().interactable = true;
        }
    }
}