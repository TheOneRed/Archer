using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    Animator ninjaDeath;
    public int lifeValue;
    public int AddScore;

    private EnemyController enemyController;
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
        gameController.GainScore(AddScore);

        if (other.tag == "Player")
        {
            gameController.LoseLife(lifeValue);
        }
        
    }
}
