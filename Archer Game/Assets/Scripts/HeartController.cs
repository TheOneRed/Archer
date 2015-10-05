using UnityEngine;
using System.Collections;

public class HeartController : MonoBehaviour {

    // Public Instances
    public GameObject heart;
    public int heartCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Range boundary;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < heartCount; i++)
            {
                Vector2 spawnPosition = new Vector2(boundary.xMax, Random.Range(boundary.yMin, boundary.yMax));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(heart, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);


        }
    }


 
}
