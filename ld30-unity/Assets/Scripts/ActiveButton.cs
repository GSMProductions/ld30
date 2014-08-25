using UnityEngine;
using System.Collections;

public class ActiveButton : MonoBehaviour {
    public GameObject opener;
    public GameObject linkedObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
        {

        if (opener == other.gameObject)
            {
            foreach(Transform child in transform)
                {
                if(child.gameObject.name == "on")
                    {
                        child.gameObject.active = false;
                    }
                if(child.gameObject.name == "off")
                    {
                        child.gameObject.active = true;
                    }
                }
            foreach(Transform child in linkedObject.transform)
                {
                if(child.gameObject.name == "on")
                    {
                        child.gameObject.active = false;
                    }
                if(child.gameObject.name == "off")
                    {
                        child.gameObject.active = true;
                    }
                }

            }
        }
}
