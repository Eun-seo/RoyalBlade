using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    private int damage = 0;
    private int point = 500;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //몬스터와 무기 충돌
        if(coll.CompareTag("Weapon") || coll.CompareTag("Bullet"))
        {
            //데미지 난수 지정
            damage = Random.Range(5000, 10000);
            #region 데미지 표시
            if (coll.CompareTag("Bullet")) //Attack Skill의 이펙트와 충돌한 경우
            {

                Vector3 v = coll.bounds.ClosestPoint(transform.position);
                ScoreManager.instance.ShowDamage(damage, this.transform,v.x,v.y);
            }
            else //무기에 충돌한 경우
            {
                ScoreManager.instance.ShowDamage(damage, this.transform);

            }
            #endregion

            //콤보 표시
            ScoreManager.instance.ShowCombo();

            //코인 획득 표시
            ScoreManager.instance.ShowCoinEffect(damage/20);

            //점수 표시
            ScoreManager.instance.Score(point);

            Destroy(this.gameObject);

            PlayerCtrl _playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();

            _playerCtrl.AttackGauge();
        }

    }

    
}
