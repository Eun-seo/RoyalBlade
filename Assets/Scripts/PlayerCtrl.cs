using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public Animator anim;
    public float jumpPower = 15;
    public Image jumpGauge;
    public Image shieldGauge;
    public Image attackGauge;
    public GameObject jumpSkill;
    public GameObject attackSkill;
    public GameObject shieldEffect;

    private Rigidbody2D rigid;
    private bool isJump = false;
    private bool isShield = false;
    private int attackType = 0;
    
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    //���� ��ư
    public void Jump()
    {
        Debug.Log("Jump : " + isJump);
        if (!isJump)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpGauge.fillAmount += 0.34f;
            isJump = true;
           
        }
        if (jumpGauge.fillAmount == 1)
        {
            jumpSkill.SetActive(true);
        }
    }

    //���� ��ư
    public void Attack()
    {
        if (attackType == 0 || attackType == 1) // �������� ����
        {
            anim.SetInteger("AttackType", 2);
            attackType = 2;
        }
        else if (attackType == 2) // ���������� ����
        {
            anim.SetInteger("AttackType", 1);
            attackType = 1;
        }
    }

    //���� ��ư ������
    public void AttackGauge()
    {
        attackGauge.fillAmount += 0.1f;
        if(attackGauge.fillAmount == 1)
        {
            attackSkill.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //���Ϳ� �÷��̾� �浹
        if (coll.collider.CompareTag("Monster"))
        {
            //�ǰݽ� �޺� �ʱ�ȭ
            ScoreManager.instance.combo = 0;

            //���� ��� ��
            if (!isShield)
            {
                isShield = true;
                StartCoroutine(ShieldGauge());
                ContactPoint2D cp =  coll.contacts[0];

                //ȿ��
                GameObject _shieldEffect =  Instantiate(shieldEffect);
                _shieldEffect.transform.position = cp.point;
                if (isJump)
                {
                    rigid.gravityScale = 10;
                }
            }
            else //��� ��
            {
                Debug.Log("Damaged");
            }
            
        }

        //�÷��̾� �ٴڿ� ���� ��
        if ((coll.collider.CompareTag("Floor")))
        {
            isJump = false;
            Debug.Log("Jump : " + isJump);

            rigid.gravityScale = 1;

            //Idle �ִϸ��̼�
            anim.SetInteger("AttackType", 0);
            attackType = 0;
        }
    }

    IEnumerator ShieldGauge()
    {
        while(true)
        {
            if (shieldGauge.fillAmount < 1)
            {
                shieldGauge.fillAmount += 0.05f;
                yield return new WaitForSeconds(0.05f);
            }
            else
            {
                shieldGauge.fillAmount = 0;
                isShield = false;
                yield  break;
            }

            
        }
        
    }
}
