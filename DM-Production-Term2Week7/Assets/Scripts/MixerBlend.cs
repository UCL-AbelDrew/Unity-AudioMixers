using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerBlend : MonoBehaviour
{

    public AudioMixer m_mixer;
    public AudioMixerSnapshot[] m_snapshots;
    
    [Range(0f,1.0f)]
    public float m_blend;
    
    private float[] m_blendWeights = {0f,1f};
    public float m_transitionTime;

    private void SetWeights(float blendWeight)
    {
        m_blend = blendWeight;
        m_blendWeights[0] = 1.0f - m_blend;
        m_blendWeights[1] = m_blend;
    }

    public void BlendSnapshot(float blendWeight)
    {
        SetWeights(blendWeight);
        m_mixer.TransitionToSnapshots(m_snapshots, m_blendWeights, m_transitionTime);

    }



}
