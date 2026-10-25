using UnityEngine;

public class ParticleToNode : MonoBehaviour
{
    public ParticleSystem targetParticleSystem;
    public string targetObjectName = "T-Pose";  // اسم گیم‌اوبجکت هدف
    public float speed = 5f;

    private ParticleSystem.Particle[] particles;
    private Transform target;
    private ParticleSystem.MainModule main;

    void Start()
    {
        main = targetParticleSystem.main;

        GameObject foundTarget = GameObject.Find(targetObjectName);
        if (foundTarget != null)
        {
            target = foundTarget.transform;
        }
        else
        {
            Debug.LogWarning("Target GameObject not found: " + targetObjectName);
        }
    }

    void LateUpdate()
    {
        if (targetParticleSystem == null || target == null)
            return;

        if (particles == null )
            particles = new ParticleSystem.Particle[targetParticleSystem.main.maxParticles];

        int numParticlesAlive = targetParticleSystem.GetParticles(particles);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            Vector3 direction = (target.position - particles[i].position).normalized;
            float distance = Vector3.Distance(particles[i].position, target.position);
            float timeToTarget = distance / speed;

            particles[i].velocity = direction * speed;

            if (distance < 0.1f)
            {
                // میتونی اینجا صدای ضربه یا انیمیشن رو اجرا کنی

                particles[i].remainingLifetime = 0f; // حذف ذره
            }
            else
            {
                particles[i].remainingLifetime = timeToTarget;
            }
        }

        targetParticleSystem.SetParticles(particles, numParticlesAlive);
    }
}
