using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MovimentoPlayer : MonoBehaviour
{
    public float velocidade = 5f;
    private float destinoX;
    private SpriteRenderer spriteRenderer;
    public Camera cameraPrincipal;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destinoX = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (cameraPrincipal == null)
            cameraPrincipal = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Pausa.jogoPausado)
                return;

            if (EventSystem.current.IsPointerOverGameObject())
                return;
            DetectarClique();
            MovimentarPersonagem();
            VirarPersonagem();

        }

        void DetectarClique()
        {
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector2 posMouse = Mouse.current.position.ReadValue();

                Vector3 posMundo = cameraPrincipal.ScreenToWorldPoint(
                    new Vector3(posMouse.x, posMouse.y, -cameraPrincipal.transform.position.z)
                );

                destinoX = posMundo.x;
            }
        }

        void MovimentarPersonagem()
        {
            Vector3 posicao = transform.position;

            posicao.x = Mathf.MoveTowards(
                posicao.x,
                destinoX,
                velocidade * Time.deltaTime
            );

            transform.position = posicao;
        }

        void VirarPersonagem()
        {
            if (Mathf.Abs(destinoX - transform.position.x) > 0.01f)
            {
                spriteRenderer.flipX = destinoX < transform.position.x;
            }
        }
    }

    public void MoverParaPorta(Transform porta, float distancia)
    {
        float direcao = Mathf.Sign(transform.position.x - porta.position.x);

        if (direcao == 0)
            direcao = -1;

        destinoX = porta.position.x + (direcao * distancia);
    }

    public bool EstaPerto(Transform porta, float distancia)
    {
        return Mathf.Abs(transform.position.x - porta.position.x) <= distancia;
    }

}