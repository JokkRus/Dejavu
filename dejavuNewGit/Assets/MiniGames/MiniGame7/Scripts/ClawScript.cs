using UnityEngine;
using System.Collections;

public class ClawScript : MonoBehaviour {
    [SerializeField]
    GameObject LeftClaw;
    [SerializeField]
    GameObject RightClaw;
    public int clawSpeed = 30;
    float time = 0;
    int direction = 1;
    public float moveSpeed = 1.65f;
    // Use this for initialization
    void Update()
    {
        time += Time.deltaTime * moveSpeed * direction;
        if (Mathf.Abs(time) <= 2)
        {
            transform.position = new Vector3(time, transform.position.y, transform.position.z);
            
        }
        else
        {
            time = 2 * direction;
            direction *= -1;
        }
    }
    void Start()
    {
        clawSpeed = 30;
        time = 0;
        direction = 1;
        moveSpeed = 1.65f;
}
	public void OpenClaw()
    {
        StartCoroutine(ClawWork());
    }
    IEnumerator ClawWork()
    {
        while(RightClaw.transform.localEulerAngles.z < 20)
        {
            LeftClaw.transform.Rotate(0, 0, -clawSpeed * Time.deltaTime);
            RightClaw.transform.Rotate(0, 0, clawSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(.2f);
        while (RightClaw.transform.localEulerAngles.z > 5)
        {
            LeftClaw.transform.Rotate(0, 0, clawSpeed * Time.deltaTime);
            RightClaw.transform.Rotate(0, 0, -clawSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
