using UnityEngine;

public class InstructionManagerHome : MonoBehaviour
{
    public GameObject instructionPanel;

    // Keeps value only while the game is running
    private static bool instructionClosedThisSession = false;

    private void Start()
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


    public void CloseInstructions()
    {
        Debug.Log("Close button clicked");

        instructionPanel.SetActive(false);

        // Remember only during this game session
        instructionClosedThisSession = true;
    }
}