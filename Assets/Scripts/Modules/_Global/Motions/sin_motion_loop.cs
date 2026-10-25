using UnityEngine;

public class sin_motion_loop : MonoBehaviour
{


    [Header("General Settings")]
    public float speed = 1f; // سرعت حرکت سینوسی
    public float frequency = 1f; // فرکانس حرکت سینوسی
    public float delayBetweenEachLoop = 0f; // تاخیر بین هر چرخه
    public float power = 1f; // قدرت (دامنه حرکت یا چرخش)

    [Header("Rotation Axes")]
    public float rotationX = 0f; // چرخش حول محور X
    public float rotationY = 0f; // چرخش حول محور Y
    public float rotationZ = 0f; // چرخش حول محور Z

    [Header("Translation Ranges")]
    public float positionX = 0f; // محدوده حرکت روی محور X
    public float positionY = 0f; // محدوده حرکت روی محور Y
    public float positionZ = 0f; // محدوده حرکت روی محور Z

    private Vector3 initialPosition; // موقعیت اولیه شی‌ء
    private Quaternion initialRotation; // چرخش اولیه شی‌ء
    private float timer = 0f; // تایمر برای تاخیر بین چرخه‌ها
    private bool isLooping = false; // آیا در حال اجرای یک چرخه هستیم

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!isLooping && timer < delayBetweenEachLoop) return;

        float sineValue = Mathf.Sin(Time.time * frequency * speed) * power;

      
            if(rotationX>0||rotationX>0||rotationX>0){
            Vector3 rotation = Vector3.zero;

             rotation.x = sineValue*rotationX;
             rotation.y = sineValue*rotationY;
             rotation.z = sineValue*rotationZ;


            transform.rotation = initialRotation * Quaternion.Euler(rotation);
            }

            float posX = positionX != 0f ? initialPosition.x + sineValue * positionX : initialPosition.x;
            float posY = positionY != 0f ? initialPosition.y + sineValue * positionY : initialPosition.y;
            float posZ = positionZ != 0f ? initialPosition.z + sineValue * positionZ : initialPosition.z;

            transform.position = new Vector3(posX, posY, posZ);
        

        if (Mathf.Sin(Time.time * frequency * speed) >= 0.999f) // پایان یک چرخه کامل
        {
            isLooping = false;
            timer = 0f;
        }
        else
        {
            isLooping = true;
        }
    }
}
