using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float yOffset;
    [SerializeField] private float moveSpeed;
    private bool isMoving = false;


    private void OnEnable()
    {
        Actions.OnEnemyKilled += MoveCamera;
    }

    private void OnDisable()
    {
        Actions.OnEnemyKilled -= MoveCamera;
    }

    void DelayMoveCamera()
    {

        Invoke("MoveCamera", 1);

    }

    public void MoveCamera()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveCameraCoroutine());
        }
    }

    private IEnumerator MoveCameraCoroutine()
    {
        isMoving = true;

        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position + Vector3.up * yOffset;

        float startTime = Time.time;
        float journeyLength = Vector3.Distance(startPos, endPos);

        while (transform.position != endPos)
        {
            float distCovered = (Time.time - startTime) * moveSpeed;
            float journeyFraction = distCovered / journeyLength;

            transform.position = Vector3.Lerp(startPos, endPos, journeyFraction);

            yield return null;
        }

        isMoving = false;
    }
}

