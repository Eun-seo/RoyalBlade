using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public GameObject damageObj; //데미지 이펙트
    public GameObject destroyEffect; //몬스터 파괴 이펙트
    public GameObject fireEffect; // Attack Skill 이펙트

    //콤보
    public TextMeshProUGUI txtCombo;
    public int combo = 0;

    //코인 획득 효과
    public Transform coinEffectPos;
    public GameObject coinEffect;
    public GameObject statusBar;

    //코인
    public TextMeshProUGUI txtCoin;

    //점수
    public TextMeshProUGUI txtScore;

    private TextMeshProUGUI damageText;
    private Animator comboAnim;

    private int coin = 0;
    private int score = 0;

    void Awake()
    {
        if(ScoreManager.instance == null)
        {
            ScoreManager.instance = this;
        }

        damageText = damageObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        comboAnim = txtCombo.gameObject.GetComponent<Animator>();

        txtCoin.text = coin.ToString();
        txtScore.text = score.ToString();
    }

    //데미지 이펙트 표시
    public void ShowDamage(int damage, Transform t, float x = 0, float y = 0)
    {
        GameObject _damageObj = Instantiate(damageObj);
        GameObject _destroyEffect = Instantiate(destroyEffect);
        
        //AttackSkill의 이펙트와 충돌한 위치에 fireEffect 생성
        if(x != 0 && y != 0)
        {
            GameObject _fireEffect = Instantiate(fireEffect);
            _fireEffect.transform.position = new Vector2(x, y);
        }

        _damageObj.transform.position = t.position;
        _destroyEffect.transform.position = t.position;
        damageText.text = damage.ToString();
    }

    //콤보 이펙트 표시
    public void ShowCombo()
    {
        combo++;
        txtCombo.text = combo + " COMBO";
        txtCombo.gameObject.SetActive(true);
        comboAnim.SetTrigger("Combo");
    }

    //코인 획득 이펙트 표시
    public void ShowCoinEffect(int coin)
    {
        GameObject _coinEffect = Instantiate(coinEffect);
        _coinEffect.transform.SetParent(statusBar.transform, false);
        _coinEffect.GetComponent<TextMeshProUGUI>().text = "+" + coin;

        StartCoroutine(Count(this.coin, this.coin + coin, txtCoin));
        this.coin += coin;
    }

    //점수 표시
    public void Score(int score)
    {
        StartCoroutine(Count(this.score, this.score + score,txtScore));
        this.score += score;
    }

    //숫자 카운팅 함수
    IEnumerator Count(float current, float target, TextMeshProUGUI text)
    {
        float duration = 0.3f; //숫자 올라가는 시간
        float offset = (target - current) / duration;

        while (current < target)
        {
            current += offset * Time.deltaTime;
            text.text = ((int)current).ToString();

            yield return null;
        }

        current = target;
        text.text = ((int)current).ToString();
    }
}
