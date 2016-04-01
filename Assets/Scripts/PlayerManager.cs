using UnityEngine;
using System.Collections;
using DG.Tweening;
public class PlayerManager : MonoBehaviour {
    public Player[] players;
    public Player selectedPlayer;
    public Player advancedPlayer;

    public GameObject[] indicatorPlayer;
    public Vector3 initialCamPosition = Camera.main.transform.position;
    bool isInCombo;
    // Use this for initialization
    void Start () {
	    for(int i = 0; i < players.Length; i++)
        {
            players[i].playerID = i;
            indicatorPlayer[i].SetActive(false);
        }
        isInCombo = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.G))
        {
            //Camera.main.DOFieldOfView(30, 1);
            
            
        }

        if (Input.GetKey(KeyCode.H))
        {
            
        }
        float h = Input.GetAxisRaw("L_YAxis_1");
        float v = Input.GetAxisRaw("L_XAxis_1");

        float triggerRight = Input.GetAxisRaw("TriggersR_1");
        float triggerLeft = Input.GetAxisRaw("TriggersL_1");

        if (TurnManager.GetInstance().whoPlays == 0)
        {
            if (Input.GetKey(KeyCode.A) || v > 0.4 && advancedPlayer == null)
            {
                if (!players[0].isAdvanced)
                {
                    selectedPlayer = players[0];
                    HideIndicators();
                    indicatorPlayer[0].SetActive(true);
                }
            }
            if (Input.GetKey(KeyCode.Z) || h > 0.4 && advancedPlayer == null)
            {
                if (!players[1].isAdvanced)
                {
                    selectedPlayer = players[1];
                    HideIndicators();
                    indicatorPlayer[1].SetActive(true);
                }
            }
            if (Input.GetKey(KeyCode.E) || h < -0.4 && advancedPlayer == null)
            {
                if (!players[2].isAdvanced)
                {
                    selectedPlayer = players[2];
                    HideIndicators();
                    indicatorPlayer[2].SetActive(true);
                }
            }

            if( h == 0 && v == 0)
            {
                selectedPlayer = null;
                HideIndicators();
            }

            if (triggerRight > 0.5f && selectedPlayer != null && !selectedPlayer.isAdvanced)
            {
                allBack();
                selectedPlayer.isAdvanced = true;
                advancedPlayer = selectedPlayer;
                advancedPlayer.Advance();
                
            }
            if (triggerLeft > 0.5f && advancedPlayer != null)
            {
                advancedPlayer.isAdvanced = false;
                advancedPlayer.Back();
                advancedPlayer = null;
                Camera.main.transform.DOLookAt(initialCamPosition, 0.5f);
                Camera.main.DOFieldOfView(60, 1f);
            }

            if (Input.GetButtonDown("A_button_1") && advancedPlayer.isAdvanced && advancedPlayer.canAttack && !isInCombo)
            {
                advancedPlayer.AttackA();
            }

            if (Input.GetButtonDown("B_button_1") && advancedPlayer.isAdvanced && advancedPlayer.canAttack && !isInCombo)
            {
                advancedPlayer.AttackB();
            }

            if(Input.GetButtonDown("X_button_1") && advancedPlayer.isAdvanced && advancedPlayer.canAttack && !isInCombo)
            {
                Combo();
            }
        }
    }

    public void allBack()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].Back();
        }
        Camera.main.transform.DOLookAt(initialCamPosition, 0.5f);
        Camera.main.DOFieldOfView(60, 1f);
    }

    void HideIndicators()
    {
        for(int i =0; i < indicatorPlayer.Length; i++)
        {
            indicatorPlayer[i].SetActive(false);
        }
    }

    void Combo()
    {
        isInCombo = true;
        float timer = 1;
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
            if (Input.GetButtonDown("A_button_1"))
            {
                Debug.Log("mdr");
            }
        }
    }
}
