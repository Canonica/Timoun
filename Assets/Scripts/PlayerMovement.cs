using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public Vector3 dir;
    public CharacterController characterController;
    public float speed = 2.0f;
    public float rotateSpeed = 0.05f;


    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {

        float horizontalLeftStick = Input.GetAxisRaw("L_XAxis_1");
        float verticalLeftStick = Input.GetAxisRaw("L_YAxis_1");
        float angleT = Mathf.Atan2(horizontalLeftStick, verticalLeftStick);
        
        if (!(Mathf.Abs(horizontalLeftStick) < 0.3f && Mathf.Abs(verticalLeftStick) < 0.3f))
        {
            characterController.Move(new Vector3(horizontalLeftStick, 0f, -verticalLeftStick) * speed * Time.deltaTime);
            playerRotate(angleT);
        }
    }

    private void playerRotate(float angle)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, (angle * Mathf.Rad2Deg*-1), 0f), rotateSpeed);
    }
}
