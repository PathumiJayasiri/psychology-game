using UnityEngine;
using TMPro;

public class QuizGameSelectLevel3 : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public AnswerButtonSingle[] allAnswers;

    int score = 0;

    void Start()
    {
        score = 0;
        UpdateScore();
                        ResetQuiz();

    }

    public void RegisterAnswer(AnswerButtonLevel3 btn)
    {
        Debug.Log("Manager received: " + btn.name);

        if (btn.isCorrect)
        {
            Debug.Log("Correct Answer");
            score += 10;
            btn.SetCorrect();
        }
        else
        {
            Debug.Log("Wrong Answer");
            btn.SetWrong();
        }

        UpdateScore();
    }

    void UpdateScore()
    {
        if(scoreText != null)
            scoreText.text = "Score: " + score;
    }
         public void ResetQuiz()
    {
        score = 0;

        foreach(AnswerButtonSingle answer in allAnswers)
        {
            answer.ResetButton();
        }

        UpdateScore();
    }

}