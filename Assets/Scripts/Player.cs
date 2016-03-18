using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public int playerID;
    public int health;
    public int stamina;
    public bool canAttack;
    public Vector3 position;
	// Use this for initialization
	void Start () {
        canAttack = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator skillCD(int cdBetween)
    {
        canAttack = false;
        yield return new WaitForSeconds(cdBetween);
        canAttack = true;
    }
}
