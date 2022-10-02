using Cinemachine;
using UnityEngine;

// All dis so it doesn't shake like its an earthquake my man...
public class CineShake : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCam;
    private float shakeDuration;
    // Start is called before the first frame update
    private void Awake()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
    }

    // Equation to be called
    public void ShakeCam(float intensity, float duration)
    {

        // What is CinemachineBasicMultiChannelPerlin?
        CinemachineBasicMultiChannelPerlin come = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        come.m_AmplitudeGain = intensity;
        shakeDuration = duration;
    }

    //How the equation operates
    private void Update()
    {
        if (shakeDuration > 0) 
        {
            shakeDuration -= Time.deltaTime;

            if (shakeDuration <= 0f)
            {
                CinemachineBasicMultiChannelPerlin come = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                come.m_AmplitudeGain = 0f;
            }
        }
    }
}
