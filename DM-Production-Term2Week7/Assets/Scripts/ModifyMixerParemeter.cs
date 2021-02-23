using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ModifyMixerParemeter : MonoBehaviour
{
    public AudioMixer m_mixer;
    public string m_parameterName;

    public void ModifyFloat(float value)
    {
        m_mixer.SetFloat(m_parameterName, value);
    }

    public void Clear()
    {
        m_mixer.ClearFloat(m_parameterName);
    }

}
