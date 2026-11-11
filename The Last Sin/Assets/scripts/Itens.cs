using UnityEngine;

public class Itens : MonoBehaviour
{
    [Header("Id do Item")]
    public string idItem;

    public void Coletar()
    {
        Inventário.Instance.AddItem(idItem);

        Destroy(gameObject);
    }
}
