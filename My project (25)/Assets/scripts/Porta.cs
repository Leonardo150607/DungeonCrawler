
using UnityEngine;

public class Porta : MonoBehaviour
{
    public int proximaSala;


    [Header("Precisa Chave")]
    public bool precisaChave;

    [Header("Tranca")]
    [TextArea(2, 4)]
    public string mensagemTrancada = "Esta porta está trancada!";

    [Header("O Quão perto tá")]
    public float distanciaInteracao = 1.2f;

    [Header("Desvio de passagem")]
    public int itensChaves;
    public int salaFinalPA;

    void OnMouseDown()
    {
        Interagir();
    }

    public void Interagir()
    {
        if (Pausa.jogoPausado)
            return;
        MovimentoPlayer player =
            FindAnyObjectByType<MovimentoPlayer>();

        if (player == null)
            return;

        if (!player.EstaPerto(transform, distanciaInteracao))
        {
            player.MoverParaPorta(transform, distanciaInteracao);
            return;
        }

        GerenciadorCenas gerenciador =
            FindAnyObjectByType<GerenciadorCenas>();

        if (gerenciador == null)
            return;

        if (precisaChave && !gerenciador.possuiChave)
        {
            Debug.Log(mensagemTrancada);
            return;
        }
        if (gerenciador.finalPiorAinda == itensChaves)
        {
            gerenciador.TrocarCena(salaFinalPA);
        }
        else
        {
            gerenciador.TrocarCena(proximaSala);
            gerenciador.possuiChave = false;
        }

        gerenciador.TrocarCena(proximaSala);
    }
}


