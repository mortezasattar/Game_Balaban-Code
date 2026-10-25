//using AptabaseSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class CharacterController : MonoBehaviour
{

    [SerializeField] float forwardSpeed = 5f; // Speed moving forward (Z-axis)
    [SerializeField] float sideSpeed = 5f; // Speed moving left/right (X-axis)
    [SerializeField] float minZ = -7f; // Left limit on Z-axis
    [SerializeField] float maxZ = -1f;  // Right limit on Z-axis

    public float smoothTime = 0.1f;   // زمان مورد نیاز برای صاف کردن حرکت
    
    

    private Rigidbody rb;

    private Vector2 touchStartPos;
    private bool isTouching = false;
    private float targetZ = 0f;  // مقدار هدف برای Z
    private float currentZ = 0f; // مقدار فعلی Z
    private float velocityZ = 0f; // متغیر کمکی برای SmoothDamp


    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody>(); // Get Rigidbody for movement
        
        //Aptabase.TrackEvent("app_level1");
      
    }

   

    void Update()
    {
        if(!GameManager.Instance.isEnd)
        {
            if(!GameManager.Instance.isWaiting)
            {

                float moveZ = 0f;

                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                    targetZ = sideSpeed;
                else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                    targetZ = -sideSpeed;
                else
                    targetZ = 0f; // برگرداندن به وسط در صورت عدم فشردن دکمه


                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        touchStartPos = touch.position;
                        isTouching = true;
                    }


                    else if (touch.phase == TouchPhase.Moved)
                    {
                        float swipeDistance = touchStartPos.x - touch.position.x;
                        targetZ = (swipeDistance / Screen.width) * sideSpeed * 2; // حرکت نرم با توجه به لمس
                    }

                    else if (touch.phase == TouchPhase.Ended)
                    {
                        targetZ = 0f; // رها کردن انگشت، بازگشت به صفر
                        isTouching = false;
                    }

                }



                currentZ = Mathf.SmoothDamp(currentZ, targetZ, ref velocityZ, smoothTime);


                Vector3 newPosition = transform.position + new Vector3(forwardSpeed * Time.deltaTime, 0, currentZ * Time.deltaTime);


                newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);


                rb.MovePosition(newPosition);


                // Set running animation
                AnimationController.instance.PlayAnimation("Run", true);
            }

        }
        
    }

   
    


   
}
