using UnityEngine;
using System.Collections;

public class ShipScript : MonoBehaviour {
    [SerializeField]
    GameObject Particle;
    public float torq;
    float power;
	// Use this for initialization
	void Start () {
        torq = 1;
	}
	
	// Update is called once per frame
	void Update () {
        power = Random.Range(-torq * 2, torq * 2);
        GetComponent<Rigidbody2D>().AddTorque(power);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-power, 0));

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (transform.localEulerAngles.z < 40 || transform.localEulerAngles.z > 320)
        {

        }
        else
        {
            Instantiate(Particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
