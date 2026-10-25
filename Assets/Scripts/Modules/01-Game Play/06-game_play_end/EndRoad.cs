using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class EndRoad : MonoBehaviour
{
    [SerializeField] private float moveDuration = 2f;
    [SerializeField] private Transform goalTransform; // نقطه مقصد دوربین

    private float moveTimer = 0f;
    private bool isMoving = false;
    private Transform playerTransform;
    private Vector3 cameraStartPos;

    void Update()
    {
        if (isMoving && playerTransform != null)
        {
            moveTimer += Time.deltaTime;
            float t = Mathf.Clamp01(moveTimer / moveDuration);

            
            if (goalTransform != null && Camera.main != null)
            {
                Camera.main.transform.position = Vector3.Lerp(cameraStartPos, goalTransform.position, t);
               // Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, goalTransform.rotation, t);
            }
            
            if (t >= 1f)
            {
                Debug.Log(t);
                isMoving = false;
               StartCoroutine( EndGame());
            }
                
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            cameraStartPos = Camera.main.transform.position; // ذخیره مکان اولیه دوربین

            StopPlayer();
        }
    }

    private void StopPlayer()
    {
        if (AnimationController.instance != null)
        {
            AnimationController.instance.ResetAnimator();
            //AnimationController.instance = null;
        }

        GameManager.Instance.isEnd = true;
        moveTimer = 0f;
        isMoving = true;
        Camera.main.GetComponent<CameraFollow>().StopFollowing();
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.CheckWinCondition();
    }

}
