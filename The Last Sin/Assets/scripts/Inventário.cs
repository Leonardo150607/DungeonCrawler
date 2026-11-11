using System.Collections.Generic;
using UnityEngine;

public class Inventário : MonoBehaviour
{
   public static Inventário Instance {  get; private set; }

    private List<string> itens = new List<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(string id)
    {
        if (itens.Contains(id))
            return;

        itens.Add(id);

        Debug.Log("ADD item" +  id);
    }

    public bool PossuiItem(string id)
    {
        return itens.Contains(id);
    }

    public void RemoverItem(string id)
    {
        if (itens.Contains(id))
        {
            itens.Remove(id);
        }
    }
}
