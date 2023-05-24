using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
  public void LoadGame()
    {
        SceneManager.LoadScene("main");
        GameManager.Instance.SaveData();
    }
  public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    GameManager.Instance.SaveData();
    }
  public void LoadMenu()
    {
        SceneManager.LoadScene("Menù");
        GameManager.Instance.SaveData();
    }
}
