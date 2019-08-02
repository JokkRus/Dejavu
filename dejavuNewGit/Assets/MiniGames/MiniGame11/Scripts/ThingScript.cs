using UnityEngine;
using System.Collections;

public class ThingScript : MonoBehaviour {
    [SerializeField]
    GameObject Particle;
    float rotate;
	void OnMouseDown()
    {
        Instantiate(Particle, transform.position, Quaternion.identity);
        if (tag == "Computer")
        {
            GameObject controller = GameObject.Find("GameController");
            controller.GetComponent<MiniGameController11>().LostLife();
        }
        Destroy(gameObject);
    }
    void Start()
    {
        rotate = Random.Range(-10,10);
    }
    void Update()
    {
        transform.Rotate(0, 0, rotate);
    }
}
