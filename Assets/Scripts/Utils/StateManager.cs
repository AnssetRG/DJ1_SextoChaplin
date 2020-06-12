using UnityEngine;
using UnityEngine.SceneManagement;

public static class StateManager
{
    public static void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}