using UnityEngine;

public class Gavetas : MonoBehaviour
{
    public Animator animator;

    private bool aberta = false;

    public void Interagir()
    {
        aberta = !aberta;

        animator.SetBool("Aberta", aberta);
    }
}
