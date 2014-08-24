using UnityEngine;
using System.Collections;

public class TopDownCharacterController : MonoBehaviour {

    public float speed = 6.0f;
    private Vector3 moveDirection = Vector3.zero;

    public bool canMove = true;

    Animator anim;

	// Use this for initialization
	void Start () {
	   anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (!canMove) {
            rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (Mathf.Abs(moveDirection.x) >= Mathf.Abs(moveDirection.y) && Mathf.Abs(moveDirection.x) > 0) {
            if (moveDirection.x > 0)
                anim.SetTrigger("Go Right");
            else if (moveDirection.x < 0)
                anim.SetTrigger("Go Left");
        } else if (Mathf.Abs(moveDirection.y) > 0) {
            if (moveDirection.y > 0)
                anim.SetTrigger("Go Up");
            else if (moveDirection.y < 0)
                anim.SetTrigger("Go Down");
        }

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;



        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, Input.GetAxis("Vertical")*speed);
	}
}
