using UnityEngine;
using System.Collections;

public class PuzzleScript : MonoBehaviour {

    void OnMouseDown()
    {
        StartCoroutine(RotatePuzzle());
        MiniGameControllerFour.numberOfTries++;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator RotatePuzzle()
    {
        for(int i = 0; i<15;i++)
        {
            transform.Rotate(0, 0, -6);
			yield return new WaitForFixedUpdate ();
        }
    }
}
