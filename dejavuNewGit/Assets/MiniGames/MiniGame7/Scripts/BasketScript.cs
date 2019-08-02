using UnityEngine;
using System.Collections;

public class BasketScript : MonoBehaviour {
    public int score;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (tag == coll.tag) score++; 
    }
	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
