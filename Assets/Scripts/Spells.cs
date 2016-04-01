using UnityEngine;
using System.Collections;

public class Spells : MonoBehaviour {

    public Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Boost()
    {

    }

    public void Heal()
    {

    }

    public void SaveBreath()
    {

    }

    public void Attack()
    {

    }

    IEnumerator ApplyBoost(float boostDuration, int boostDamage)
    {
        int initialDamage = player.damageAttackA;
        player.damageAttackA *= boostDamage;
        yield return new WaitForSeconds(boostDuration);
        player.damageAttackA = initialDamage;
    }
}
