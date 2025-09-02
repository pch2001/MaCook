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

    //Character Select Panel ��ȯ
    public GameObject SelectPanel;

    public Sprite[] chSprites;

    public GameObject fightButton;

    private Button currentTargetButton; //������ ��ư ����


    public CharacterOption[] allCharacters;     // ���� ������ ĳ���͵�
    public List<CharacterOption> selectedCharacters = new List<CharacterOption>();
    public Transform[] spawnPoints; // �������� ĳ���� ��ȯ ��ġ


    public void selectStart(Button clickedButton)
    {
        SelectPanel.SetActive(true);
        currentTargetButton = clickedButton;
    }

    public void selectEnd(int index)
    {
        selectedCharacters.Add(allCharacters[index]);
        currentTargetButton.GetComponent<Image>().sprite = chSprites[index];
        Debug.Log("����");
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
