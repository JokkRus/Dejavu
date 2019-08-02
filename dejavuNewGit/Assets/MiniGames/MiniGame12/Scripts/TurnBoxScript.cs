using UnityEngine;
using System.Collections;

public class TurnBoxScript : MonoBehaviour {
    float time;
    int direction;
    int[] angles;
	// Use this for initialization
	void Start () {
        direction = 1;
        time = 0;
        angles = new int[]
        {
            90,
            180,
            270
        };
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        transform.Rotate(0, 0, direction * 0.2f);
        if(time > 0.5f)
        {
            time = 0;
            direction *= -1;
        }
        if(Random.Range(0,30) == 10)
        {
            StartCoroutine(turnBox(angles[Random.Range(0, 3)]));
        }
	}
    IEnumerator turnBox(int angle)
    {
        if (angle > transform.localEulerAngles.z)
        {
            while (transform.localEulerAngles.z < angle)
            {
                transform.Rotate(0, 0, 5);
                yield return null;
            }
        }
        else
        {
            while (transform.localEulerAngles.z > angle)
            {
                transform.Rotate(0, 0, -5);
                yield return null;
            }
        }
    }
}
