using UnityEngine;
using System.Collections;

[System.Serializable]
public class Area
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    // Public Instances
    public float speed;
    public GameObject arrow;
    public Transform shotSpawn;
    public float fireRate;
    public Area moveArea; //boundary where player is restricted
	AudioSource pickUp; //Sound when player collides with jewel


	// Private Instances
    private float nextFire;


    void Start()
    {
		pickUp = GetComponent<AudioSource>(); //Finds audio source
	}

    void Update()
    {
		if (Input.GetButton("Fire1") && Time.time > nextFire) //Left click to fire
        {
           
            nextFire = Time.time + fireRate;
            Instantiate(arrow, shotSpawn.position, shotSpawn.rotation); //as GameObject;
        }
		
    }

    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal"); //x-axis
        float moveVertical = Input.GetAxis("Vertical"); //y-axis

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        GetComponent<Rigidbody2D>().velocity = movement * speed;

		// Area restriction of the player
        GetComponent<Rigidbody2D>().position = new Vector2
            (
                Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, moveArea.xMin, moveArea.xMax),
                Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, moveArea.yMin, moveArea.yMax)
            );

    }

	// For sound purposes
	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Jewel") 
		{
			pickUp.Play(); //play sound clip
		}
	}
		


    public void kill()
    {
        Destroy(gameObject); // Kill itself
    }
}
