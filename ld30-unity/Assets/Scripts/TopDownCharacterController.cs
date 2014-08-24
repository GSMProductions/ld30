using UnityEngine;
using System.Collections;

public class TopDownCharacterController : MonoBehaviour {

    public float speed = 6.0f;
    private Vector3 moveDirection = Vector3.zero;

    Animator anim;

	// Use this for initialization
	void Start () {
	   anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y) && Mathf.Abs(moveDirection.x) > 0.01) {
            if (moveDirection.x > 0)
                anim.SetTrigger("Go Right");
            else
                anim.SetTrigger("Go Left");
        } else if (Mathf.Abs(moveDirection.y) > 0.01){
            if (moveDirection.y > 0)
                anim.SetTrigger("Go Up");
            else
                anim.SetTrigger("Go Down");
        }

        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, Input.GetAxis("Vertical")*speed);
	}
}
