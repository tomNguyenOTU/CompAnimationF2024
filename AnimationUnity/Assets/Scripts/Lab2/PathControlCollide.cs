using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathControlCollide : MonoBehaviour
{
    [SerializeField]
    public PathManager pathManager;

    List<Waypoint> thePath;
    Waypoint target;

    public float MoveSpeed;
    public float RotateSpeed;

    public Animator animator;
    bool isWalking;

    void RotateTowardsTarget() {
        float stepSize = RotateSpeed * Time.deltaTime;

        Vector3 targetDir = target.pos - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    void MoveForward() {
        float stepSize = MoveSpeed * Time.deltaTime;
        float distanceToTarget = Vector3.Distance(transform.position, target.pos);
        
        if (distanceToTarget < stepSize) {
            // overshooting target
            return;
        }

        Vector3 moveDir = Vector3.forward;
        transform.Translate(moveDir * stepSize);
    }

    // Start is called before the first frame update
    void Start()
    {
        thePath = pathManager.GetPath();
        if (thePath != null && thePath.Count > 0) {
            target = thePath[0];
        }

        isWalking = true;
        animator.SetBool("isWalking", isWalking);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            // toggle if key pressed
            isWalking = !isWalking;
        }
        if (isWalking) {
            RotateTowardsTarget();
            MoveForward();
        }
        //if (target == null) {
        //    target = thePath[0];
        //}
        animator.SetBool("isWalking", isWalking);
    }

    private void OnTriggerEnter(Collider other) {
        // next target
        target = pathManager.GetNextTarget();
    }

    void OnCollisionEnter(Collision collision)
    {
        isWalking = false; 
    }
}
