using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

 public static GameManager instance;


    public int totalItems = 11;

    private int droppedItems = 0;


    public GameObject finishButton;


    public GameObject resultPanel;


    public TextMeshProUGUI resultText;


    public List<DraggableItem> allItems;

     void Awake()
    {
        instance = this;
    }



    void Start()
    {
        // Show finish button but disable clicking
    finishButton.SetActive(true);

    finishButton.GetComponent<UnityEngine.UI.Button>().interactable = false;


    resultPanel.SetActive(false);
    }



    public void ItemDropped()
    {

        droppedItems++;


        if(droppedItems >= totalItems)
        {
    finishButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }

    }



    public void ShowResult()
    {

        int score = 0;


        foreach(DraggableItem item in allItems)
        {

            if(item.correctAnswer)
            {
                item.ChangeToCorrectColor();

                score += 10;
            }
            else
            {
                item.ChangeToWrongColor();
            }


            // lock movement
            item.LockItem();

        }



        resultPanel.SetActive(true);


        resultText.text =
        "Your Score : " + score + " / " + (totalItems * 10);

    }



    public void TryAgain()
    {

    foreach(DraggableItem item in allItems)
    {
        item.ResetItem();
    }


    droppedItems = 0;


    finishButton.SetActive(true);

    finishButton.GetComponent<UnityEngine.UI.Button>().interactable = false;


    resultPanel.SetActive(false);


    GameState.gameStarted = true;
    }



    public void CancelResult()
    {

        resultPanel.SetActive(false);

    }
}