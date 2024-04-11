using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour
{

    public SceneFader fader;
    // Start is called before the first frame update

    public Button[] levelButtons;

    public GameObject[] panels;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);

        for(int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
                panels[i].SetActive(true);
            }
        }
    }
    
    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
