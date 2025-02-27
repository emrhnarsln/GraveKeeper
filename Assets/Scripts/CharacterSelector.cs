using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{

    private GameObject[] heroList;
    private int index;
    public string[] heroNames;
    public Text heroNameText;
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");;
        
       

        heroList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            heroList[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject go in heroList)
        {
            go.SetActive(false);
        }
        if (heroList[index])
        {
            heroList[index].SetActive(true);
        }
        UpdateHeroName();
    }

    void UpdateHeroName()
    {
        if(heroNameText != null && heroNames.Length > index)
        {
            heroNameText.text  = heroNames[index];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleLeft()
    {
        heroList[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = heroList.Length - 1;

        }
        heroList[index].SetActive(true);
        UpdateHeroName();
    }

    public void ToggleRight()
    {
        heroList[index].SetActive(false);
        index++;
        if (index == heroList.Length)
        {
            index = 0;

        }
        heroList[index].SetActive(true);
        UpdateHeroName();
    }

    public void StartGame()
    {   
        
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("GameScene");
        
    }
}
