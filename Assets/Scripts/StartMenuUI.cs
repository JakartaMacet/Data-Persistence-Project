using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenuUI : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScoreText.text = $"Best Score : {GameManager.Instance.savedUserName} : {GameManager.Instance.savedHighScore}";
    }

    public void LoadStart()
    {
        if (nameInputField.text == "")
        {
            Debug.Log("Must Input Name");
        }
        else
        {
            GameManager.Instance.userName = nameInputField.text;
            SceneManager.LoadScene(1);
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
