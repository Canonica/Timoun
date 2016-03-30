using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class Player : MonoBehaviour {
    public int playerID;

    public int healthMax;
    public int health;
    public Image healthImage;

    public int staminaMax;
    public int stamina;
    public Image staminaImage;


    public bool canRegenStamina;
    public bool canAttack;
    public Vector3 position;
    public Monster target;
    

    public bool isAdvanced;
    public Vector3 firstPosition;

    public Text impossibleActionText;

    // Use this for initialization
    void Start () {
        canAttack = true;
        healthMax = 40;
        staminaMax = 40;
        stamina = staminaMax;
        health = healthMax;
        healthImage = GameObject.Find("HealthFull" + (playerID + 1)).GetComponent<Image>();
        staminaImage = GameObject.Find("StaminaFull" + (playerID + 1)).GetComponent<Image>();
        firstPosition = transform.position;
        StartCoroutine(reloadStamina());
        impossibleActionText.DOFade(0, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        healthImage.fillAmount = (float)((float)health / (float)healthMax);
        staminaImage.fillAmount = (float)((float)stamina / (float)staminaMax);
    }

    public void getDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Debug.Log(playerID + " is dead");
    }

    public void Advance()
    {
        isAdvanced = true;
        transform.DOMove(GameObject.Find("Advanced").transform.position, 0.5f);
    }

    public void Back()
    {
        isAdvanced = false;
        transform.DOMove(firstPosition, 0.5f);
    }

    public IEnumerator Attack(int cost, float cooldown, int damage, float stunDuration)
    {
        if ((stamina - cost) > 0)
        {
            canAttack = false;
            stamina -= cost;
            Debug.Log("Attack");
            target.GetDamage(damage);
            target.transform.DOShakePosition(0.5f, 0.5f, 10, 90);
            yield return new WaitForSeconds(cooldown);
            canAttack = true;
        }
        else
        {
            impossibleActionText.transform.DOShakeScale(0.1f, 10);
            impossibleActionText.DOFade(1, 0.2f).OnComplete(() => impossibleActionText.DOFade(0, 0.5f));
            //impossibleActionText.DOFade(0, 0.5f);
            yield break;
        }
        
       
    }

    IEnumerator reloadStamina()
    {
        while (health > 0)
        {
            if (stamina >= 0 && stamina < 15)
            {
                stamina += 1;
                yield return new WaitForSeconds(4);
            }
            else if (stamina >= 15 && stamina < 30)
            {
                stamina += 1;
                yield return new WaitForSeconds(2);
            }
            else if (stamina >= 30 && stamina < 40)
            {
                stamina += 1;
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return 0;
            }
        }
    }
}
