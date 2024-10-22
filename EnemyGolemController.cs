using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyGolemController : MonoBehaviour
{

    private GameObject PlayerObj; // �v���C���[
    public EnemySearchManager SearchManager;

    public float m_EnemySpeed;
    Animator m_Animator;
    private int m_Attack2 = 0;
    
    private float m_Speed; // �G�l�~�[�̃X�s�[�h��ۑ�����ϐ�
    public int hp;

    private float m_DizzyTime = 0;

    bool m_Invincibility = false; //���G�t���O
    float m_InvincibilityTime = 0; //���G����

    //�G�l�~�[��AttackCollider���擾
    public SphereCollider AttackCollider;

    private bool m_Found; //�����𖞂��������񂾂���������悤�ɐ��䂷��t���Os

    AudioSource m_AudioSource;
    public AudioClip a_Damage; //�U���ɂ��_���[�WSE
    public AudioClip a_Attack; //�U��SE
    public AudioClip a_Surprise; //����SE
    public AudioClip a_Die; //���SSE

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        AttackCollider = transform.GetChild(0).GetComponent<SphereCollider>();
        m_Speed = m_EnemySpeed;
        m_Found = false;
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 speed = Vector3.zero;
        speed.z = m_EnemySpeed;
        
        // PlayerObject���擾
        PlayerObj = SearchManager.GetComponent<EnemySearchManager>().s_PlayerObj;

        if (PlayerObj != null && hp > 0)
        {

            if (m_Found == false)
            {
                Found();
                m_Found = true;
            }
            transform.LookAt(PlayerObj.transform.position);

            float distance = Vector3.Distance(PlayerObj.transform.position, transform.position);
            //�w�肵�������܂ŋ߂Â�����Enemy�̃X�s�[�h��0�ɂ���
            if (distance <= 5)
            {
                m_EnemySpeed = 0;
                //Attack�A�j���[�V�����̍Đ����~�߂�
                if (PlayerObj.CompareTag("Player"))�@//�v���C���[������ł�����U���̑ΏۂƂ��Ȃ����߂̏�����
                {
                    m_Animator.SetBool("Attack", true);
                    
                }
                else
                {
                    m_Animator.SetBool("Attack", false);
                }
            }
            else
            //�͈͊O�Ȃ�X�s�[�h��߂�
            //Attack�A�j���[�V�����̍Đ����~�߂�
            {
                m_EnemySpeed = m_Speed;
                m_Animator.SetBool("Attack", false);
            }
            this.transform.Translate(speed);
        }
        else
        {
            m_Found = false;
        }
        EnemyinvincibilityTime();

        m_DizzyTime -= Time.deltaTime;
        Debug.Log(m_DizzyTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Sword") && m_Invincibility == false)
        {
            hp--;
            m_Invincibility = true;
            m_AudioSource.PlayOneShot(a_Damage);
            if (hp > 0)
            {
               
            }
            else if (hp <= 0)
            {
                m_Animator.SetTrigger("Die");
                m_AudioSource.PlayOneShot(a_Die);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                //gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            }
            m_InvincibilityTime = 0.1f;
        }
        else if(other.gameObject.CompareTag("Skill") && m_Invincibility == false)
        {
            m_Animator.SetTrigger("Dizzy");
        }
    }

    void EnemyinvincibilityTime()
    {
        if (m_InvincibilityTime >= 0)
        {
            m_InvincibilityTime -= Time.deltaTime;

        }
        else if (m_InvincibilityTime <= 0)
        {
            m_Invincibility = false;
        }
    }

    //�G�l�~�[���U�������画����o���֐�
    void GolemAttack()
    {
        AttackCollider.enabled = !AttackCollider.enabled;
        m_AudioSource.PlayOneShot(a_Attack);
    }

    void Attack2()
    {
        if(m_Attack2 == 3)
        {
            m_Animator.SetTrigger("Attack2");
            m_Attack2 = 0;
        }
        else
        {
            m_Attack2 += 1;
        }
    }

    void Found()
    {
        m_Animator.SetTrigger("Found");
        m_AudioSource.PlayOneShot(a_Surprise);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
