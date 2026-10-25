using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip moneyCollect;
    [SerializeField] AudioClip wallExplosion;
    //[SerializeField] AudioClip lose;
    [SerializeField] AudioClip obstacleColider;
    [SerializeField] AudioClip powerUpWall;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }
    public void PlayCollectableSound()
    {
        audioSource.PlayOneShot(moneyCollect);
    }
    public void PlayWallExplosion()
    {
        audioSource.PlayOneShot(wallExplosion);
    }
    //public void PlayLoseSound()
    //{
    //    audioSource.PlayOneShot(lose);
    //}

    public void PlayObstacleSound()
    {
        audioSource.PlayOneShot(obstacleColider);
    }
    public void PlayPowerUpWall()
    {
        audioSource.PlayOneShot(powerUpWall);
    }

    public void StopPlay()
    {
        audioSource.Stop();
    }
}
