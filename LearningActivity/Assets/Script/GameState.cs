using UnityEngine;

public class GameState : MonoBehaviour
{

    // This variable is shared by the whole game
    public static bool gameStarted = false;


    void Awake()
    {
        // Make sure the game always starts locked
        gameStarted = false;
    }

}