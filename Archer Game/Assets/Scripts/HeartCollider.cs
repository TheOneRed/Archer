using UnityEngine;
using System.Collections;

public class HeartCollider : MonoBehaviour {

    //Public Instances
    public int getHeart;
    public int hitHeart;
    public float speed;

    //Private Instances
    private GameController gameController;
   
    // Use this for initialization
    void Start()
    {
        // Finding GameController game object to access methods in GameController script 
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, GetComponent<Rigidbody2D>().velocity.y); //makes heart move left on the x-axis
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameController.pickUpHeart();
            gameController.LoseLife(getHeart);
            Destroy(gameObject);
        }

        if (other.tag == "Arrow")
        {
            gameController.breakHeart();
            gameController.GainScore(hitHeart);
            Destroy(gameObject);
        }
    }


}
