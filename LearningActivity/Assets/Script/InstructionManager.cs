using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionManager : MonoBehaviour
{

    public GameObject instructionPanel;
    public GameObject resetConfirmPanel;
    private static bool instructionClosedThisSession = false;


    void Start()
    {
        // Show instruction box
  if (instructionClosedThisSession)
        {
            instructionPanel.SetActive(false);
        }
        else
        {
            instructionPanel.SetActive(true);
        }        resetConfirmPanel.SetActive(false);

      // Lock game
        GameState.gameStarted = false;
    }



    public void CloseInstructions()
    {

        instructionPanel.SetActive(false);
        instructionClosedThisSession = true;


        // Start game
        GameState.gameStarted = true;

    }

  // RESET BUTTON CLICK
    public void ShowResetConfirmation()
    {

        resetConfirmPanel.SetActive(true);

    }



    // YES BUTTON
    public void ConfirmReset()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }



    // NO BUTTON
    public void CancelReset()
    {

        resetConfirmPanel.SetActive(false);

    }
public void GoHome()
    {
        SceneManager.LoadScene("HomePage");
    }
}