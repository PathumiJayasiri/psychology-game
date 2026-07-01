using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public GameObject exitDialogPanel;


    // Called when Exit button is clicked
    public void ShowExitDialog()
    {
        exitDialogPanel.SetActive(true);
    }


    // Called when YES button is clicked
    public void ExitGame()
    {
        Application.Quit();

        Debug.Log("Game Closed");
    }


    // Called when NO button is clicked
    public void CancelExit()
    {
        exitDialogPanel.SetActive(false);
    }
}