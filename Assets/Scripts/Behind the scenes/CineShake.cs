using Cinemachine;
using UnityEngine;

// All dis so it doesn't shake like its an earthquake my man...
public class CineShake : MonoBehaviour
{
    private CinemachineVirtualCamera cum;
    private float shook;
    // Start is called before the first frame update
    private void Awake()
    {
        cum = GetComponent<CinemachineVirtualCamera>();
    }

    //Equation to be called
    public void ShakeCam(float intense, float time)
    {
        CinemachineBasicMultiChannelPerlin come = cum.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        come.m_AmplitudeGain = intense;
        shook = time;
    }

    //How the equation operates
    private void Update()
    {
        if (shook > 0) 
        {
            shook -= Time.deltaTime;

            if (shook <= 0f)
            {
                CinemachineBasicMultiChannelPerlin come = cum.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                come.m_AmplitudeGain = 0f;
            }
        }
    }
}
