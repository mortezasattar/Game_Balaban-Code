using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offset_texture : MonoBehaviour
{
    // Start is called before the first frame update
    public int materialIndex = 0; // ایندکس متریال هدف
    public float scrollSpeedX = 0.1f;
    public float scrollSpeedY = 0.0f;

    private Renderer rend;
    private Material targetMaterial;
    private Vector2 currentOffset;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // بررسی اینکه تعداد متریال‌ها کافی هست
        if (rend.materials.Length > materialIndex)
        {
            targetMaterial = rend.materials[materialIndex];
            currentOffset = targetMaterial.mainTextureOffset;
        }
        else
        {
            Debug.LogError("ایندکس متریال اشتباه است! تعداد متریال‌ها: " + rend.materials.Length);
        }
    }

    void Update()
    {
        if (targetMaterial == null)
            return;

        // افزایش افست با زمان
        float x = currentOffset.x + Time.deltaTime * scrollSpeedX;
        float y = currentOffset.y + Time.deltaTime * scrollSpeedY;

        currentOffset = new Vector2(x, y);
        targetMaterial.mainTextureOffset = currentOffset;
    }
}
