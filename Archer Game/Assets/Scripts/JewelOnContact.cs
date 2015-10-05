using UnityEngine;
using System.Collections;

public class JewelOnContact : MonoBehaviour
{

    //Public Instances
    public int AddScore;
	public int LoseScore;

    //Private Instances
    private GameController gameController; //To reference GameController script
	private JewelController jewelController; //To reference JewelController script

    void Start()
    {
		// Finding GameController game object to access methods in GameController script 
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
		
		// Finding JewelController game object to access methods in JewelController script 
		GameObject jewelControllerObject = GameObject.FindWithTag("JewelController");
		if (jewelControllerObject != null)
		{
			jewelController = jewelControllerObject.GetComponent<JewelController>();
		}


    }
	
	//When jewel comes into contact with other colliders
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameController.GainScore(AddScore); //reference to GameController to gain point for collecting the jewel
            Destroy(gameObject);
        }

		if (other.tag == "Arrow") 
		{
			jewelController.breakSound(); //reference to JewelController to play sound. If the audiosource were to be a component in Jewel can called, it would not play because gameobject gets destroyed
			gameController.GainScore(LoseScore); //reference to GameController to lose points for breaking the jewel
			Destroy(gameObject);
		}
	}


}
