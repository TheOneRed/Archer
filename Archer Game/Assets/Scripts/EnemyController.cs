using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed
{
    public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Move
{
    public float minMove, maxMove;
}

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}


public class EnemyController : MonoBehaviour
{
    // PUBLIC INSTANCE VARIABLES
    public Speed speed;
    public Move move;
    public Boundary boundary;

    // PRIVATE INSTANCE VARIABLES
    private float _CurrentSpeed;
    private float _CurrentMove;

    // Use this for initialization
    void Start()
    {
        this.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        currentPosition.x += this._CurrentMove;
        currentPosition.y -= this._CurrentSpeed;
        gameObject.GetComponent<Transform>().position = currentPosition;

        //Makes ninjas rebound off top
        if (currentPosition.y >= boundary.yMax)
        {
            this._CurrentSpeed = this._CurrentSpeed * -1;
        }

        //Makes ninjas rebound off bottom
        if (currentPosition.y <= boundary.yMin)
        {
            this._CurrentSpeed = this._CurrentSpeed * -1;
        }

            // Check bottom boundary
            if (currentPosition.x <= boundary.xMin)
        {
            this.Reset();
        }
    }

  

// resets the gameObject
public void Reset()
    {
        this._CurrentMove = Random.Range(move.minMove, move.maxMove);
        this._CurrentSpeed = Random.Range(speed.minSpeed, speed.maxSpeed);
        Vector2 resetPosition = new Vector2(boundary.xMax, Random.Range(boundary.yMin, boundary.yMax));
        gameObject.GetComponent<Transform>().position = resetPosition;
    }

}
