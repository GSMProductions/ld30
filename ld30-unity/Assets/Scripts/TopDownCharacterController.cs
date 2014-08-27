using UnityEngine;
using System.Collections;

public class TopDownCharacterController : MonoBehaviour {

    public float speed = 6.0f;
    private Vector3 moveDirection = Vector3.zero;

    public bool canMove = true;

    Animator anim;

    GlobalState state;

	// Use this for initialization
	void Start () {
	   anim = GetComponent<Animator>();
       state = GameObject.Find("Global State").GetComponent<GlobalState>();
	}

    void Update() {
        if (!canMove) {
            return;
        }

        if (Input.GetKeyUp("x")) {
            if (state.unlocked_characters > 0) {
                Input.ResetInputAxes();
                canMove = false;
                Debug.Log("Test");
                state.characters_world[state.current_character] = Application.loadedLevelName;
                state.characters_position[state.current_character] = new Vector2(transform.position.x, transform.position.y); 
                state.cameras_position[state.current_character] = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
                int previous_character = state.current_character;
                state.current_character += 1;
                if (state.current_character > state.unlocked_characters) {
                    state.current_character = 0;
                }
                if (state.characters_world[previous_character] == state.characters_world[state.current_character]) {
                    Camera.main.transform.position = state.cameras_position[state.current_character];
                    GameObject.Find(state.characters[state.current_character]).GetComponent<TopDownCharacterController>().canMove = true;
                } else {
                    
                }
            }
        }
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
