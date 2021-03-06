﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Range
{
    public float xMin, xMax, yMin, yMax;
}

public class JewelController : MonoBehaviour
{

    // Public Instances
    public GameObject jewel;
    public int jewelCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Range boundary;
	AudioSource crack; // empty Arcade SFX Free from unity asset store

    //Private Instances
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
		crack = GetComponent<AudioSource> ();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < jewelCount; i++)
            {
                Vector2 spawnPosition = new Vector2(boundary.xMax, Random.Range(boundary.yMin, boundary.yMax));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(jewel, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);


        }
    }

	public void breakSound()
	{
		crack.Play(); //play audio clip
	}

 
}
