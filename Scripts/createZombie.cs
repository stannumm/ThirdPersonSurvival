using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createZombie : MonoBehaviour {

    public GameObject zombiePrefab;
	// Use this for initialization
	void Start () {
        InvokeRepeating("create", 3f, 5f);
	}
	//x 39 -48 z -55 -34 x44 58 -37 18
    void create()
    {
        Instantiate(zombiePrefab, new Vector3(Random.Range(-48,39), 0, Random.Range(-55,-34)), Quaternion.identity);
        Instantiate(zombiePrefab, new Vector3(Random.Range(44, 58), 0, Random.Range(-37, 18)), Quaternion.identity);
    }
}
