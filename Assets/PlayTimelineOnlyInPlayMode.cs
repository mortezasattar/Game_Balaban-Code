using UnityEngine;
using UnityEngine.Playables;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(PlayableDirector))]
public class PlayTimelineOnlyInPlayMode : MonoBehaviour
{
    private PlayableDirector director;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();

#if UNITY_EDITOR
        // اگر در Editor هستیم ولی Play Mode نیستیم → Timeline رو متوقف کن
        if (!Application.isPlaying)
        {
            director.time = 0;
            director.Stop();
        }
#endif
    }

    private void Start()
    {
        // فقط وقتی بازی اجرا شده → Timeline پخش بشه
        if (Application.isPlaying)
        {
            director.Play();
        }
    }
}
