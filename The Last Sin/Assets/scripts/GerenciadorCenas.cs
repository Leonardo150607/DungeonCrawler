
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GerenciadorCenas : MonoBehaviour
{
    public List<string> cenas = new List<string>();

    public bool possuiChave = false;

    public int finalPiorAinda = 0;

    public void TrocarCena(int numeroCena)
    {
        if (numeroCena >= 0 && numeroCena < cenas.Count)
        {
            SceneManager.LoadScene(cenas[numeroCena]);
        }
    }
}
