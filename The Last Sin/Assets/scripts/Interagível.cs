using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class Interagível : MonoBehaviour
{
    public UnityEvent interagir;

    private void OnMouseDown()
    {
        if (Pausa.jogoPausado)
            return;

        if (EventSystem.current != null &&
            EventSystem.current.IsPointerOverGameObject())
            return;

        interagir.Invoke();
    }
}
