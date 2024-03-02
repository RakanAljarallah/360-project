using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LOADSCENE : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SceneLoader",3);
    }

   private void SceneLoader()
   {
        SceneManager.LoadSceneAsync(1);
   }
}
