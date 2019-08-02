using UnityEngine;
using System.Collections;

public class EndRegionScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(coll.gameObject);
    }
}
