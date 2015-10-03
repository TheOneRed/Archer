using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArrowShot : MonoBehaviour {

    public float speed;
   

    private GameController gameController;
    private EnemyController enemyController;

    // Use this for initialization
    void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y); //makes bullet move left on the x-axis
	
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
