using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour
{
    private Button button;
    [SerializeField]
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => GoLevel());
    }

    void GoLevel()
    {
        PlayerPrefs.SetInt("level", level);
        StateManager.changeScene("Game");
    }
}