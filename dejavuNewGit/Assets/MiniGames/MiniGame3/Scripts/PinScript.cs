using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinScript : MonoBehaviour {
    [SerializeField]
    MiniGameControllerThree controller;
    float yPos;
    float offset;
    Vector3 MainPos;
    public bool death = false;
	// Use this for initialization
	void Start () {
        offset = 160;
        death = false;
        MainPos = transform.localPosition;
     yPos = transform.localPosition.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        yPos += Random.Range(-.2f, controller.Difficulty/2f);
        transform.localPosition = new Vector3(MainPos.x, Mathf.Clamp(yPos, MainPos.y - 10, MainPos.y + offset), MainPos.z);
        if (transform.localPosition.y >= MainPos.y + offset)
        {
            death = true;
            GetComponent<Image>().color = new Color(1, 0, 0, 1);
        }
	}
    public void Reset()
    {
        transform.localPosition = MainPos;
        yPos = transform.localPosition.y;
    }
}
