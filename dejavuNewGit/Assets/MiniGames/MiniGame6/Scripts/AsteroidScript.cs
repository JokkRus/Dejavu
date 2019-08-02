using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour {
    [SerializeField]
    GameObject Explosion;
    float direction;
    public float rotSpeed = 90;
    public float moveSpeed = 3.5f;
	// Use this for initialization
    void OnMouseDown()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
	void Awake () {
        rotSpeed = 90;
        moveSpeed = 3.5f;
    direction = Random.Range(-rotSpeed, rotSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -moveSpeed * Time.deltaTime, 0, Space.World);
        transform.Rotate(0, 0, direction * Time.deltaTime);
	}
}
