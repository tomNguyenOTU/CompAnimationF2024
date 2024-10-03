using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            transform.position += new Vector3 (-Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.S)) {
            transform.position += new Vector3 (Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.A)) {
            transform.position += new Vector3 (0, 0, -Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)) {
            transform.position += new Vector3 (0, 0, Time.deltaTime);
        }
    }
}
