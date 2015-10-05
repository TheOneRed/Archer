using UnityEngine;
using System.Collections;

public class NinjaOnContact : MonoBehaviour {

    // Public Instances
    public int lifeValue;
    public int AddScore;
   
	// Private Instances
    private GameController gameController;

    void Start()
    {
		// Finding GameController game object to access methods in GameController script 
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
		
    }

	// Score/Lives update system when colliding
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameController.LoseLife(lifeValue);
        }
        
        if (other.tag == "Arrow")
        {
            gameController.GainScore(AddScore);
        }
    }
}
