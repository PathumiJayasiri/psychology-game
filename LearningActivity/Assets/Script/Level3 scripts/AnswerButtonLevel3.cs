using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButtonLevel3 : MonoBehaviour
{
    public Image background;
    public TextMeshProUGUI text;

public GameObject correctImage;
    public GameObject wrongCross;  
      public Button disableAnswerButton1;
    public Button disableAnswerButton2;

    public bool isCorrect;
    public bool alreadyClicked = false;

    public QuizGameSelectLevel3 manager;

public void OnClick()
{
    Debug.Log("Clicked: " + gameObject.name);

    if (alreadyClicked) return;

    alreadyClicked = true;
    if(disableAnswerButton1 != null || disableAnswerButton2 != null)
        {
            disableAnswerButton1.interactable = false;
                        disableAnswerButton2.interactable = false;

        }
    manager.RegisterAnswer(this);
}
    public void SetCorrect()
    {
                correctImage.SetActive(true);

    }

    public void SetWrong()
    {
        background.color = Color.white;

        wrongCross.SetActive(true);
    }

    public void ResetButton()
    {
        background.color = Color.white;
        wrongCross.SetActive(false);
        alreadyClicked = false;
    if(disableAnswerButton1 != null || disableAnswerButton2 != null)
        {
            disableAnswerButton1.interactable = true;
                        disableAnswerButton2.interactable = true;

        }

    }
}