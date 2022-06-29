using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        int level2 = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(level2);
    }
}
