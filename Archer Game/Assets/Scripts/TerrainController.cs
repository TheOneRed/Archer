using UnityEngine;
using System.Collections;

public class TerrainController : MonoBehaviour {

    public float speed;
   

	// Use this for initialization
	void Start () {
        this.Reset();
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        currentPosition.x -= speed;
        gameObject.GetComponent<Transform>().position = currentPosition;

        if (currentPosition.x <= -17.9) //when background hits a certian position on the x-axis..... 
        {
            this.Reset();
        }
    }

    private void Reset() //reset back to first position
    {
        Vector2 resetPosition = new Vector2(5.28f, 1.7f);
        gameObject.GetComponent<Transform>().position = resetPosition;
    }

    
}
