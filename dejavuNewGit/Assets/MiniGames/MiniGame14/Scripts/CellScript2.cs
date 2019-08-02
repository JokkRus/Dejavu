using UnityEngine;
using System.Collections;

public class CellScript2 : MonoBehaviour {
    [SerializeField]
    GameObject Explosion;
    float rotSpeed;
	// Use this for initialization
	void Start () {
        rotSpeed = Random.Range(-20, 20);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, rotSpeed);
	}
    void OnMouseDown()
    {
        if (tag == "wrong")
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            GameObject controller = GameObject.Find("GameController");
            controller.GetComponent<MiniGameController14>().ChangeLife();
            StartCoroutine(WrongChoice());
        }
    }
    IEnumerator WrongChoice()
    {
        while(GetComponent<SpriteRenderer>().color.b > 0.01f)
        {
            GetComponent<SpriteRenderer>().color -= new Color(0, 0.1f, 0.1f,0);
            yield return null;
        }
        while (GetComponent<SpriteRenderer>().color.b < 0.99f)
        {
            GetComponent<SpriteRenderer>().color += new Color(0, 0.05f, 0.05f, 0);
            yield return null;
        }
    }
}
