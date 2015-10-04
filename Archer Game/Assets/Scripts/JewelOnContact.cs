using UnityEngine;
using System.Collections;

public class JewelOnContact : MonoBehaviour
{

    //Public Instances
    public int AddScore;

    //Private Instances
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameController.GainScore(AddScore);
            Destroy(gameObject);
        }

	}
}
