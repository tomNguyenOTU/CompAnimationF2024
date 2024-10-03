using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLookat : MonoBehaviour
{
    Transform playerTr;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 adjustLoc = playerTr.position;
        adjustLoc.y = transform.position.y;

        transform.LookAt(adjustLoc);
    }
}
