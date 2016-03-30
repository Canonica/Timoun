using UnityEngine;
using System.Collections;
using DG.Tweening;
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
        //Camera.main.DOKill(true);
        //Camera.main.DOShakePosition(0.5f, 2, 10, 30);
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
