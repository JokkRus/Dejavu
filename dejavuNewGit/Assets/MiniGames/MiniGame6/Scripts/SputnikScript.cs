using UnityEngine;
using System.Collections;

public class SputnikScript : MonoBehaviour {
    float time = -1.5f;
    int direction = 1;
    public float rotSpeed = 15;
    public float moveSpeed = 1;
   int life = 3;
    [SerializeField]
    GameObject Explosion;
    [SerializeField]
    GameObject[] Lifes;
	// Use this for initialization
	void Start () {
        time = -1.5f;
        direction = 1;
    rotSpeed = 15;
    moveSpeed = 1;
    int life = 3;
}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, Time.deltaTime * rotSpeed);
        time += Time.deltaTime* moveSpeed * direction;
        if(Mathf.Abs(time) <= 2)
        {
            transform.position = new Vector3(time ,transform.position.y, transform.position.z);
        }
        else
        {
            direction *= -1;
        }
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        Instantiate(Explosion, coll.transform.position, Quaternion.identity);
        Destroy(coll.gameObject);
        life--;
        Lifes[life].SetActive(false);
        if(life == 0) Invoke("ShipDestroy", .5f);  
    }
    void ShipDestroy()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
