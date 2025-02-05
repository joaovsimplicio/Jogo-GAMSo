using UnityEngine;

public class Trajetoria : MonoBehaviour
{
    public Transform player; // O objeto do jogador
    public LineRenderer lineRenderer; // O componente LineRenderer para desenhar a linha
    public int segments = 10; // Número de segmentos na linha (pontos)

    void Start()
    {
        lineRenderer.positionCount = segments;
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = (mousePosition - player.position).normalized;

        for (int i = 0; i < segments; i++)
        {
            float t = i / (float)(segments - 1);
            lineRenderer.SetPosition(i, player.position + t * direction * 10f);
        }
    }
}