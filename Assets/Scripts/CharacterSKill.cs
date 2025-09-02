using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSKill : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject skill1;
    public GameObject skill2;
    //public GameObject skillon;
    public Camera mainCamera;

    public GameObject skillEffect;
    void Start()
    {
       // Debug.Log("스폰");
        mainCamera = Camera.main;
    }

    public void fightStartIcon()
    {
       Debug.Log("공격 시작");
        skill1.SetActive(true);
        skill2.SetActive(true);
    }

    public void fightfirstSkill()
    {
        skillStart();
    }

    public void fightsecondSkill()
    {
        skillStart();
    }

    private void skillStart()
    {
        skill1.SetActive(false);
        skill2.SetActive(false);
        //skillon.SetActive(false);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Monster hp = enemy.GetComponent<Monster>();
            if (hp != null)
            {
                hp.Damaged(30);
            }
        }
        
        GameObject eft = Instantiate(skillEffect,  this.transform.position, Quaternion.identity);
        Destroy(eft, 0.9f);
        StartCoroutine(CameraShake(0.3f, 0.5f));

    }

    private System.Collections.IEnumerator CameraShake(float duration, float magnitude)
    {
        Vector3 originalPos = mainCamera.transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;

            mainCamera.transform.localPosition = originalPos + new Vector3(offsetX, offsetY, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.localPosition = originalPos;

        this.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f);

        yield return new WaitForSeconds(5f);
        this.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
        //skillon.SetActive(true);

    }
}
