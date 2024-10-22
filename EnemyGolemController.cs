using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyGolemController : MonoBehaviour
{

    private GameObject PlayerObj; // プレイヤー
    public EnemySearchManager SearchManager;

    public float m_EnemySpeed;
    Animator m_Animator;
    private int m_Attack2 = 0;
    
    private float m_Speed; // エネミーのスピードを保存する変数
    public int hp;

    private float m_DizzyTime = 0;

    bool m_Invincibility = false; //無敵フラグ
    float m_InvincibilityTime = 0; //無敵時間

    //エネミーのAttackColliderを取得
    public SphereCollider AttackCollider;

    private bool m_Found; //条件を満たしたら一回だけ発動するように制御するフラグs

    AudioSource m_AudioSource;
    public AudioClip a_Damage; //攻撃によるダメージSE
    public AudioClip a_Attack; //攻撃SE
    public AudioClip a_Surprise; //発見SE
    public AudioClip a_Die; //死亡SE

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
        
        // PlayerObjectを取得
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
            //指定した距離まで近づいたらEnemyのスピードを0にする
            if (distance <= 5)
            {
                m_EnemySpeed = 0;
                //Attackアニメーションの再生を止める
                if (PlayerObj.CompareTag("Player"))　//プレイヤーが死んでいたら攻撃の対象としないための条件文
                {
                    m_Animator.SetBool("Attack", true);
                    
                }
                else
                {
                    m_Animator.SetBool("Attack", false);
                }
            }
            else
            //範囲外ならスピードを戻す
            //Attackアニメーションの再生を止める
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

    //エネミーが攻撃したら判定を出す関数
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
