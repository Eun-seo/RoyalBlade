using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    private int damage = 0;
    private int point = 500;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //���Ϳ� ���� �浹
        if(coll.CompareTag("Weapon") || coll.CompareTag("Bullet"))
        {
            //������ ���� ����
            damage = Random.Range(5000, 10000);
            #region ������ ǥ��
            if (coll.CompareTag("Bullet")) //Attack Skill�� ����Ʈ�� �浹�� ���
            {

                Vector3 v = coll.bounds.ClosestPoint(transform.position);
                ScoreManager.instance.ShowDamage(damage, this.transform,v.x,v.y);
            }
            else //���⿡ �浹�� ���
            {
                ScoreManager.instance.ShowDamage(damage, this.transform);

            }
            #endregion

            //�޺� ǥ��
            ScoreManager.instance.ShowCombo();

            //���� ȹ�� ǥ��
            ScoreManager.instance.ShowCoinEffect(damage/20);

            //���� ǥ��
            ScoreManager.instance.Score(point);

            Destroy(this.gameObject);

            PlayerCtrl _playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();

            _playerCtrl.AttackGauge();
        }

    }

    
}
