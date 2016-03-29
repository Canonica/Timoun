using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
    public int healthMax;
    public int health;
    // Use this for initialization
    void Start () {
        healthMax = 40;
        health = healthMax;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        this.gameObject.SetActive(false);
    }
}
