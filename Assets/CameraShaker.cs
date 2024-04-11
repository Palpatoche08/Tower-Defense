using UnityEngine;
using Cinemachine;

public class CameraShaker : MonoBehaviour
{
    public float shakeIntensity = 1f;
    public float shakeDuration = 0.2f;

    private CinemachineImpulseSource impulseSource;

    private void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void ShakeCamera()
    {
        impulseSource.GenerateImpulse(Vector3.up * shakeIntensity);
    }
}
