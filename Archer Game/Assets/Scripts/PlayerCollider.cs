using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    public int lifeValue;
    private GameController gameController;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D otherGameObject)
    {
        if (otherGameObject.tag == "Ninja")
        {
            gameController.LoseLife(lifeValue);
        }
    }
}
