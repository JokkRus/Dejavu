using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RocketScript : MonoBehaviour {
    float power;
    public float turbul = 0.1f;
    public float rotateSpeed = 0.1f;
	// Use this for initialization
	void Start () {
        turbul = 0.1f;
   rotateSpeed = 0.1f;
}
	
	// Update is called once per frame
	void Update () {
        power = Random.Range(-turbul, turbul);
        GetComponent<Rigidbody2D>().AddTorque(power*5);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-power*40, 0));
    }
    public void TurnRocket(int Direction)
    {
        GetComponent<Rigidbody2D>().AddTorque(-Direction*rotateSpeed * 5);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Direction * rotateSpeed * 40, 0));
    }
}
