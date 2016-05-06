using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class TurnManager : MonoBehaviour {

    private static TurnManager instance = null;

    public Image timer;
    public float maxTimeTurn;
    public float currentTimeTurn;
    public bool isPlaying;

    public int whoPlays;

    public Text textTurn;
    public PlayerManager allPlayers;

    public static TurnManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        maxTimeTurn = 10;
        currentTimeTurn = maxTimeTurn;
        isPlaying = false;
        whoPlays = 0;
        textTurn.text = "Player Turn";
    }

    void Update()
    {
        currentTimeTurn -= Time.deltaTime;
        if (!isPlaying)
        {
            isPlaying = true;
            StartCoroutine(WaitForCdfloat(maxTimeTurn));
        }
        if(currentTimeTurn <= 0)
        {
            changeTurn();
        }
    }

    void changeTurn()
    {
        currentTimeTurn = maxTimeTurn;
        timer.fillAmount = 1;
        StartCoroutine(WaitForCdfloat(maxTimeTurn));
        if(whoPlays == 0)
        {
            whoPlays = 1;
            textTurn.text = "Monster Turn";
            allPlayers.allBack();
            allPlayers.advancedPlayer = null;
        }
        else if (whoPlays == 1)
        {
            whoPlays = 0;
            textTurn.text = "Player Turn";
        }
        textTurn.transform.DOShakePosition(0.1f, 10);
    }

    public IEnumerator WaitForCdfloat(float cdTimer)
    {
            timer.fillAmount = 1;
            yield return StartCoroutine(fillIcon(timer, cdTimer));
    }

    public IEnumerator fillIcon(Image icon, float cdTimer)
    {
        float timer = maxTimeTurn;
        while (timer <= cdTimer)
        {
            icon.fillAmount = timer / cdTimer;
            timer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        timer = 0;
    }
}
