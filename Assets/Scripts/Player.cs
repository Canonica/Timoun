using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
    public int playerID;

    public int healthMax;
    public int health;
    public Image healthImage;

    public int stamina;
    public bool canAttack;
    public Vector3 position;
    public Monster target;

    public bool isAdvanced;
    public Vector3 firstPosition;

    // Use this for initialization
    void Start () {
        canAttack = true;
        healthMax = 40;
        stamina = 40;
        health = healthMax;
        healthImage = GameObject.Find("HealthFull" + (playerID + 1)).GetComponent<Image>();
        firstPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        healthImage.fillAmount = (float)((float)health / (float)healthMax);
    }

    IEnumerator skillCD(int cdBetween)
    {
        canAttack = false;
        yield return new WaitForSeconds(cdBetween);
        canAttack = true;
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
}
