using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinScriptTwo : MonoBehaviour {
    [SerializeField]
    MiniGameController13 controller;
    float yPos;
    float offset;
    Vector3 MainPos;
    public bool power = false;
	// Use this for initialization
	void Start () {
        offset = 160;
        power = false;
        MainPos = transform.localPosition;
     yPos = transform.localPosition.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        yPos += Random.Range(-.2f, controller.Difficulty);
        transform.localPosition = new Vector3(MainPos.x, Mathf.Clamp(yPos, MainPos.y - 10, MainPos.y + offset), MainPos.z);
        if (transform.localPosition.y >= MainPos.y + offset)
        {
            power = true;
            GetComponent<Image>().color = new Color(1, 0, 0, 1);
        }
	}
    public void Reset()
    {
        transform.localPosition = MainPos;
        yPos = transform.localPosition.y;
        power = false;
        GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }
}
