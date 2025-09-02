using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Request : MonoBehaviour
{
    bool isstart;

    [SerializeField]

    public GameObject StageUI;

    public GameObject SuccessImage;

    //===============================
    public GameObject[] questWindow;
    public GameObject nxtbtn;

    private int currentIdex;
    void Start()
    {
        isstart = false;
        currentIdex = 0;
    }

    void Update()
    {

    }

    public void nextButton()
    {
        //Debug.Log(currentIdex);

        if(currentIdex < questWindow.Length-1)
        {
            questWindow[currentIdex++].SetActive(false);
            questWindow[currentIdex].SetActive(true);
        }
        if(currentIdex == 2)
        {
            nxtbtn.SetActive(false);
            //StageUI.SetActive(false);
        }

    }


    //==========================================

    public void QusetStart()
    {
        if (isstart) return;
        //미션 진행하기
        //StoryImage.SetActive(false);
        nextButton();
        //questWindow[0].SetActive(true);
        StageUI.SetActive(true);
        isstart = true;

    }

    public void SuccesQuest()
    {
        Debug.Log("미션 성공");
        isstart = false;
        StartCoroutine(ShowAndHide(SuccessImage));
        SceneManager.LoadScene(1);

    }


    private IEnumerator ShowAndHide(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(1f);
        obj.SetActive(false);
    }
}
