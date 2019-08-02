using UnityEngine;
using System.Collections;

public class BeeScript : MonoBehaviour {
    bool faceLeft;
    void Start()
    {
        faceLeft = true;
    }
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-2f, 2f), Random.Range(-1f, 1f)));
        if (faceLeft == true && GetComponent<Rigidbody2D>().velocity.x > 0) Flip();
        if (faceLeft == false && GetComponent<Rigidbody2D>().velocity.x < 0) Flip();
	}
    void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        faceLeft = !faceLeft;
    }
}
