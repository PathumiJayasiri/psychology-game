using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButtonSingle : MonoBehaviour
{
    public Image background;
    public TextMeshProUGUI text;

    // public GameObject wrongCross;   
    public Button otherAnswerButton;

    public bool isCorrect;
    public bool alreadyClicked = false;

    public QuizGameManager manager;

public void OnClick()
{
    Debug.Log("Clicked: " + gameObject.name);

    if (alreadyClicked) return;

    alreadyClicked = true;
    if(otherAnswerButton != null)
        {
            otherAnswerButton.interactable = false;
        }
    manager.RegisterAnswer(this);
}
    public void SetCorrect()
    {
        background.color = Color.green;
    }

    public void SetWrong()
    {
        background.color = Color.red;
        // wrongCross.SetActive(true);
    }

    public void ResetButton()
    {
         background.color = Color.white;

    // if (wrongCross != null)
    // {
    //     wrongCross.SetActive(false);
    // }

    alreadyClicked = false;

    // Enable the other answer again
    if(otherAnswerButton != null)
    {
        otherAnswerButton.interactable = true;
    }
    }
}