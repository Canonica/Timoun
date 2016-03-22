using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {

    private static TurnManager instance = null;

    public Image timer;
    public float maxTimeTurn;
    public float currentTimeTurn;
    public bool isPlaying;

    public int whoPlays;
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
    }

    void Update()
    {
        Debug.Log(whoPlays);
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
        }else if (whoPlays == 1)
        {
            whoPlays = 0;
        }
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
