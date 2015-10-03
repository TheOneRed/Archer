using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArrowShot : MonoBehaviour {

    //Public Instances
    public float speed;

	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y); //makes bullet move right on the x-axis
	
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        Destroy(gameObject); //Remove itself
      
    }
}
