using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DirectionalAudio : MonoBehaviour
{
    private Transform listener;
    public float innerAngle = 30f;   // full volume within this cone (degrees)
    public float outerAngle = 120f;  // outer cone where attenuation reaches minVolume (degrees)
    [Range(0f, 1f)] public float minVolume = 0.2f; // volume when facing away
    public float smoothTime = 0.05f; // smoothing for volume changes

    private AudioSource audioSource;
    private float baseVolume;
    private float currentVolumeVel;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        baseVolume = audioSource.volume;
        // ensure 3D spatialization
        audioSource.spatialBlend = 1f;

        if (listener == null)
        {
            var al = FindFirstObjectByType<AudioListener>();
            if (al != null) this.listener = al.transform;
        }
    }

    void Update()
    {
        if (listener == null) return;

        Vector3 toListener = (listener.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, toListener); // 1 when facing listener, -1 when opposite
        float angle = Mathf.Acos(Mathf.Clamp(dot, -1f, 1f)) * Mathf.Rad2Deg;

        float targetFactor;
        if (angle <= innerAngle)
        {
            targetFactor = 1f;
        }
        else if (angle >= outerAngle)
        {
            targetFactor = minVolume;
        }
        else
        {
            float t = (angle - innerAngle) / (outerAngle - innerAngle);
            targetFactor = Mathf.Lerp(1f, minVolume, t);
        }

        float targetVolume = baseVolume * targetFactor;
        audioSource.volume = Mathf.SmoothDamp(audioSource.volume, targetVolume, ref currentVolumeVel, smoothTime);
       
    }
}