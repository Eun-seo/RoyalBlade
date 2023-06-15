using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public GameObject damageObj; //������ ����Ʈ
    public GameObject destroyEffect; //���� �ı� ����Ʈ
    public GameObject fireEffect; // Attack Skill ����Ʈ

    //�޺�
    public TextMeshProUGUI txtCombo;
    public int combo = 0;

    //���� ȹ�� ȿ��
    public Transform coinEffectPos;
    public GameObject coinEffect;
    public GameObject statusBar;

    //����
    public TextMeshProUGUI txtCoin;

    //����
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

    //������ ����Ʈ ǥ��
    public void ShowDamage(int damage, Transform t, float x = 0, float y = 0)
    {
        GameObject _damageObj = Instantiate(damageObj);
        GameObject _destroyEffect = Instantiate(destroyEffect);
        
        //AttackSkill�� ����Ʈ�� �浹�� ��ġ�� fireEffect ����
        if(x != 0 && y != 0)
        {
            GameObject _fireEffect = Instantiate(fireEffect);
            _fireEffect.transform.position = new Vector2(x, y);
        }

        _damageObj.transform.position = t.position;
        _destroyEffect.transform.position = t.position;
        damageText.text = damage.ToString();
    }

    //�޺� ����Ʈ ǥ��
    public void ShowCombo()
    {
        combo++;
        txtCombo.text = combo + " COMBO";
        txtCombo.gameObject.SetActive(true);
        comboAnim.SetTrigger("Combo");
    }

    //���� ȹ�� ����Ʈ ǥ��
    public void ShowCoinEffect(int coin)
    {
        GameObject _coinEffect = Instantiate(coinEffect);
        _coinEffect.transform.SetParent(statusBar.transform, false);
        _coinEffect.GetComponent<TextMeshProUGUI>().text = "+" + coin;

        StartCoroutine(Count(this.coin, this.coin + coin, txtCoin));
        this.coin += coin;
    }

    //���� ǥ��
    public void Score(int score)
    {
        StartCoroutine(Count(this.score, this.score + score,txtScore));
        this.score += score;
    }

    //���� ī���� �Լ�
    IEnumerator Count(float current, float target, TextMeshProUGUI text)
    {
        float duration = 0.3f; //���� �ö󰡴� �ð�
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
