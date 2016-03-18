using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

    private static TurnManager instance = null;

    enum gameState
    {
        Menu,
        Pause,
        GameOver,
        Playing
    };

    gameState currentGamestate;

    public static TurnManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
