using UnityEngine;
using System.Collections;

public class LetterRotationScript : MonoBehaviour {
    public float speed = 500f;
	// Use this for initialization
	void Start () {
        speed = 500f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, speed * Time.deltaTime);
	}
}
