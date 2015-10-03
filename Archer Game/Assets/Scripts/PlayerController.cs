using UnityEngine;
using System.Collections;

[System.Serializable]
public class Area
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    
    public float speed;
    public GameObject arrow;
    public Transform shotSpawn;
    public float fireRate;
    public Area moveArea;

    private float nextFire;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
           
            nextFire = Time.time + fireRate;
            Instantiate(arrow, shotSpawn.position, shotSpawn.rotation); //as GameObject;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        GetComponent<Rigidbody2D>().velocity = movement * speed;

        GetComponent<Rigidbody2D>().position = new Vector2
            (
                Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, moveArea.xMin, moveArea.xMax),
                Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, moveArea.yMin, moveArea.yMax)
            );

    }

    public void kill()
    {
        Destroy(gameObject);
    }
}
