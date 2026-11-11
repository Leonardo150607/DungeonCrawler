using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject PanelPause;
    public static bool jogoPausado { get; private set; } = false;
    public void PausarJogo()
    {
        jogoPausado = true;
        PanelPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinuarJogo()
    {
        jogoPausado = false;
        PanelPause.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
        jogoPausado = false;
    }

}
