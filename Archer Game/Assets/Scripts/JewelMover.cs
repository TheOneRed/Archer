using UnityEngine;
using System.Collections;

public class JewelMover : MonoBehaviour {

    // Public Instances
    public float speed;
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, GetComponent<Rigidbody2D>().velocity.y); //makes jewel move left on the x-axis
    }

    
}
