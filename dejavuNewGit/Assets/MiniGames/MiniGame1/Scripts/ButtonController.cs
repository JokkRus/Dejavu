using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
    [SerializeField]
    MiniGameControllerOne controller;
	// Use this for initialization
    void OnMouseOver()
    {
        controller.AddPower();
        transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }
    void OnMouseUp()
    {
        controller.StartFly();
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
