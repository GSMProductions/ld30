using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   if (Input.GetKeyUp("space")) {
            GameObject.Find("Global State").GetComponent<GlobalState>().LoadingScreen();
            Application.LoadLevel("001-house_interior_A");
       }
	}
}
