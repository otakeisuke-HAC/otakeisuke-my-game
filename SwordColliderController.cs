using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordColliderController : MonoBehaviour
{
    
    private GameObject SwrodObject;
    private BoxCollider SwordCollider;
    private GameObject SwrodSkillObject;
    private BoxCollider SwordSkillCollider;
    AudioSource m_AudioSource;
    public AudioClip a_Skill; //�X�L����SE
    public AudioClip a_AttackVoice; //�A�^�b�N�{�C�X(�����I)SE
    public AudioClip a_AttackVoice2; //�A�^�b�N�{�C�X(�������I)SE

    Animator m_Animator;

    private void Start()
    {
        //SwordObject��BoxCollider���擾
        SwrodObject = GameObject.FindGameObjectWithTag("Sword");
        SwordCollider = SwrodObject.GetComponent<BoxCollider>();
        //SwordSkillObject��BoxCollider���擾
        SwrodSkillObject = GameObject.FindGameObjectWithTag("Skill");
        SwordSkillCollider = SwrodSkillObject.GetComponent<BoxCollider>();
        m_AudioSource = GetComponent<AudioSource>();
        m_Animator = GetComponent<Animator>();
    }
    public void SwordColliderOn()
    {
        SwordCollider.enabled = true;
        if(m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            m_AudioSource.PlayOneShot(a_AttackVoice);
        }
        else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack4"))
        {
            m_AudioSource.PlayOneShot(a_AttackVoice2);
        }       
    }

    public void SwordColliderOff()
    {
        SwordCollider.enabled = false;
    }
    public void SwordSkillColliderOn()
    {
        SwordSkillCollider.enabled = true;
        m_AudioSource.PlayOneShot(a_Skill);
        
    }

    public void SwordSkillColliderOff()
    {
        SwordSkillCollider.enabled = false;
    }
}
