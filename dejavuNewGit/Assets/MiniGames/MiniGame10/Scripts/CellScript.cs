using UnityEngine;
using System.Collections;

public class CellScript : MonoBehaviour {
    float repCell;
   public static bool isInvoking;
	// Use this for initialization
	void Start () {
         repCell =  2.5f;
        InvokeRepeating("MakeCell", repCell, repCell);
        isInvoking = true;
	}
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)));
         transform.Rotate(0, 0, 10);
        if (!isInvoking) CancelInvoke();
	}
    void OnMouseDown()
    {
        Destroy(gameObject);
    }
    void MakeCell()
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }
}
