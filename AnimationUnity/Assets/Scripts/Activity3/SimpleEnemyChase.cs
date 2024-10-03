using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyChase : MonoBehaviour
{
    public float speed;
    Transform playerTr;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 chase = new Vector3 (0,0,0);

        chase = playerTr.position - transform.position;
        chase = Vector3.Normalize(chase) * speed * Time.deltaTime;

        transform.position += chase;
    }
}
