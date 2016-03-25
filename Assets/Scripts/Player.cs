using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

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
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.DOMove(GameObject.Find("Advanced").transform.position, 0.5f);
        //}
        //if (Input.GetKey(KeyCode.B))
        //{
        //    transform.DOMove(firstPosition, 0.5f);
        //}
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
}
