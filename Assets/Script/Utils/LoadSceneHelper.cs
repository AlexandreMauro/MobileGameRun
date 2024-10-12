using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{
   public void load(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void load(string s)
    {
        SceneManager.LoadScene(s);
    }
}
