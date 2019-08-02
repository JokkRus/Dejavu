using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BombController : MonoBehaviour {
    [SerializeField]
    GameObject Explosion;
    public bool inFly = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject() && inFly == false)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = objectPos.x - mousePos.x;
            mousePos.y = objectPos.y - mousePos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90));
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "tower")
        {
            Instantiate(Explosion, coll.transform.position + new Vector3(0,-0.5f,0), Quaternion.identity);
            MiniGameControllerOne.Success();
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(Explosion, transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
            MiniGameControllerOne.Failure();
          Destroy(gameObject);
        }
    }
}
