using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{

    [System.Serializable]
    public class CharacterOption
    {
        public string name;
        public GameObject prefab;
    }
    public GameObject Monsterfab;

    //Character Select Panel 소환
    public GameObject SelectPanel;

    public Sprite[] chSprites;

    public GameObject fightButton;

    private Button currentTargetButton; //변경할 버튼 저장


    public CharacterOption[] allCharacters;     // 선택 가능한 캐릭터들
    public List<CharacterOption> selectedCharacters = new List<CharacterOption>();
    public Transform[] spawnPoints; // 전투에서 캐릭터 소환 위치


    public void selectStart(Button clickedButton)
    {
        SelectPanel.SetActive(true);
        currentTargetButton = clickedButton;
    }

    public void selectEnd(int index)
    {
        selectedCharacters.Add(allCharacters[index]);
        currentTargetButton.GetComponent<Image>().sprite = chSprites[index];
        Debug.Log("설정");
        SelectPanel.SetActive(false);

        if (selectedCharacters.Count >= 2)
        {
            fightButton.SetActive(true);
        }
    }

    public void fightStart()
    {
        for (int i = 0; i < selectedCharacters.Count && i < spawnPoints.Length; i++)
        {
            Instantiate(selectedCharacters[i].prefab, spawnPoints[i].position, Quaternion.identity);

        }

        GameObject.Find("GameManager").GetComponent<Request>().nextButton();

        
        Instantiate(Monsterfab, spawnPoints[4].position, Quaternion.identity);

    }
}
