using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;
    [SerializeField] Vector3 offset = new Vector3(5f, 5f, -10f); // y اولیه 5
    [SerializeField] float smoothSpeed = 5f;

    public bool isFollowing = true;

    private bool didYOffsetSequence = false;
    private float ySequenceTimer = 0f;
    private float yLerpDuration = 1f;

    void LateUpdate()
    {
        if (!isFollowing || targetToFollow == null) return;

        // اجرای فقط یک‌بار تغییر y
        if (!didYOffsetSequence)
        {
            StartCoroutine(DoYOffsetSequence());
            didYOffsetSequence = true;
        }

        // محاسبه موقعیت نهایی
        Vector3 desiredPosition = new Vector3(targetToFollow.position.x + offset.x, offset.y, offset.z);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }

    private IEnumerator DoYOffsetSequence()
    {
        float originalY = offset.y;

        // مرحله اول: کاهش به 3.2
        float timer = 0f;
        while (timer < yLerpDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / yLerpDuration);
            offset.y = Mathf.Lerp(originalY, 3.2f, t);
            yield return null;
        }

        offset.y = 3.2f;

        // توقف 1 ثانیه
        yield return new WaitForSeconds(1.5f);

        // مرحله دوم: برگشت به 5
        timer = 0f;
        while (timer < yLerpDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / yLerpDuration);
            offset.y = Mathf.Lerp(3.2f, originalY, t);
            yield return null;
        }

        offset.y = originalY;
    }
    public void StopFollowing()
    {
        isFollowing = false;
    }

    public void ResumeFollowing()
    {
        isFollowing = true;
    }
}
