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
    public SpriteRenderer spriteRenderer;   // ���� ��������Ʈ
    public Sprite normalSprite;
    void Start()
    {
        currentHP = maxHP;

        if (HPImage != null)
            HPImage.fillAmount = 1f; // ���۽� Ǯ ü��
    }

    public void Damaged(int power)
    {
        currentHP -= power;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        // ü�¹� UI ����
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
        yield return new WaitForSeconds(2.7f); // 1�� ���

        GameObject.Find("GameManager").GetComponent<Request>().nextButton();

        Debug.Log($"{gameObject.name} ���!");
        //Invoke("Destroy(gameObject)",1f);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(2);

    }

    private IEnumerator HitEffect()
    {
        if ( spriteRenderer != null && hitImage != null)
        {
            spriteRenderer.sprite = hitImage;   // �ǰ� ��������Ʈ�� ����
            yield return new WaitForSeconds(0.5f); // 1�� ���
            spriteRenderer.sprite = normalSprite; // ���� ��������Ʈ�� ����
        }
    }

}
