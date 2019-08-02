using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

	void OnTriggerExit2D(Collider2D coll)
    {
        MiniGameController10.goneCell++;
        Destroy(coll.gameObject);
    }
}
