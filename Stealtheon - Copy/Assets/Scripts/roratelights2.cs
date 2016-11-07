using UnityEngine;
using System.Collections;
[Author ("Zac Desogner")]
public class roratelights2 : MonoBehaviour {

    public float speed = 1f;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(Vector3.down, speed, Space.World);
        transform.Rotate(Vector3.left, speed, Space.World);
    }

}
