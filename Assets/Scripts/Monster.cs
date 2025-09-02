using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Monster : MonoBehaviour
{
    public float maxHP = 100;
    private float currentHP;
    public Image HPImage;

    public Sprite hitImage;
    public SpriteRenderer spriteRenderer;   // 몬스터 스프라이트
    public Sprite normalSprite;
    void Start()
    {
        currentHP = maxHP;

        if (HPImage != null)
            HPImage.fillAmount = 1f; // 시작시 풀 체력
    }

    public void Damaged(int power)
    {
        currentHP -= power;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        // 체력바 UI 갱신
        if (HPImage != null)
            HPImage.fillAmount = currentHP / maxHP;

        StartCoroutine(HitEffect());

        Debug.Log(currentHP);

        if (currentHP <= 0)
        {
            StartCoroutine(DieMonster());
        }

    }
    private IEnumerator DieMonster()
    {
        yield return new WaitForSeconds(2.7f); // 1초 대기

        GameObject.Find("GameManager").GetComponent<Request>().nextButton();

        Debug.Log($"{gameObject.name} 사망!");
        //Invoke("Destroy(gameObject)",1f);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(2);

    }

    private IEnumerator HitEffect()
    {
        if ( spriteRenderer != null && hitImage != null)
        {
            spriteRenderer.sprite = hitImage;   // 피격 스프라이트로 변경
            yield return new WaitForSeconds(0.5f); // 1초 대기
            spriteRenderer.sprite = normalSprite; // 원래 스프라이트로 복귀
        }
    }

}
