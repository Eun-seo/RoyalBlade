using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour,IEndDragHandler,IDragHandler
{
    public GameObject jumpSkill;
    public GameObject attackSkill;
    public Animator playerAnim;
    public Rigidbody2D playerRigid;

    public Image jumpGauge;
    public Image attackGauge;

    private RectTransform rt;
    private float jumpPower = 20;

    private void Awake()
    {
        rt = this.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 curPos = rt.anchoredPosition;
        curPos.y = eventData.position.y;
        if(curPos.y >= 200 && curPos.y <= 700)
        {
            rt.anchoredPosition = curPos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //점프 스킬
        if (rt.anchoredPosition.y >= 650 && this.name == "Btn_JumpSkill")
        {
            playerAnim.SetTrigger("JumpSkill");
            jumpSkill.SetActive(false);
            jumpGauge.fillAmount = 0;
        }

        //공격 스킬
        if (rt.anchoredPosition.y >= 650 && this.name == "Btn_AttackSkill")
        {
            playerRigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            playerAnim.SetTrigger("AttackSkill");
            attackSkill.SetActive(false);
            attackGauge.fillAmount = 0;
        }

        //버튼 원위치
        Vector2 curPos = rt.anchoredPosition;
        curPos.y = 200;
        rt.anchoredPosition = curPos;
    }
}
