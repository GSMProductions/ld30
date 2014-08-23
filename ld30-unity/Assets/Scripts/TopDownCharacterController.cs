using UnityEngine;
using System.Collections;

public class TopDownCharacterController : MonoBehaviour {

    public float speed = 6.0F;
    private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal")*6.0f, Input.GetAxis("Vertical")*6.0f);
	}
}
