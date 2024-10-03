using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineTransition : MonoBehaviour
{
    private SplineAnimate splAnim;
    [SerializeField] SplineContainer[] splines;
    [SerializeField] GameObject[] splRef;
    int splIndex = 0;
    int prevIndex = -1;

    public bool transActive = false;

    Vector3 startPosition;
    float transProgress = 0f;

    void Awake() {
        splAnim = GetComponent<SplineAnimate>();
        splAnim.Container = splines[0];
    }

    void Start() {
        prevIndex = splines.Length - 1;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !transActive) {
            CycleContainer();
        }

        if (transActive) {
            DoSplineTransition();
        }
    }

    void CycleContainer() {
        prevIndex = splIndex;

        splIndex++;
        if (splIndex >= splines.Length) {
            splIndex = 0;
        }

        transActive = true;
        transProgress = 0f;
        splAnim.Pause();
    }

    void DoSplineTransition() {
        transProgress += Time.deltaTime;


        Vector3 startPosition = splRef[prevIndex].transform.position;
        Vector3 endPosition = splRef[splIndex].transform.position;
        transform.position = Vector3.Lerp(startPosition, endPosition, transProgress);

        if (transProgress >= 1f)
        {
            splAnim.Container = splines[splIndex];
            transActive = false; 

            splAnim.NormalizedTime = splRef[splIndex].GetComponent<SplineAnimate>().NormalizedTime;
            splAnim.Play();
        }
    }
}
