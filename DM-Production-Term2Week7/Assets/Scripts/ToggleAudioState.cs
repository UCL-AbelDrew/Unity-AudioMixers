using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ToggleAudioState : MonoBehaviour
{
    public AudioMixerSnapshot m_snapShotOne;
    public AudioMixerSnapshot m_snapShotTwo;
    public float m_transitionTime;

    private bool m_playOne = true;

    public void ToggleStates()
    {
        m_playOne = !m_playOne;
        if (m_playOne)
        {
            m_snapShotOne.TransitionTo(m_transitionTime);
        }
        else
        {
            m_snapShotTwo.TransitionTo(m_transitionTime);
        }

    }
}
