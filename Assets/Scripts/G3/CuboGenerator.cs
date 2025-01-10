using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboGenerator : MonoBehaviour
{
    public GameObject cuboPrefab;
    public Vector2 rangoPosicionX = new Vector2(-8f, 8f);
    public Vector2 rangoPosicionY = new Vector2(-4f, 4f);
    public float tiempoVidaCubo = 1.5f;

    private Color[] coloresCubos = { Color.red, Color.blue, Color.yellow };

    public void GenerarCubo(GameManagerCubos gameManager)
    {
        GameObject cubo = Instantiate(cuboPrefab);
        cubo.transform.position = new Vector3(
            Random.Range(rangoPosicionX.x, rangoPosicionX.y),
            Random.Range(rangoPosicionY.x, rangoPosicionY.y),
            0f);

        Color colorSeleccionado = coloresCubos[Random.Range(0, coloresCubos.Length)];
        cubo.GetComponent<Renderer>().material.color = colorSeleccionado;
        cubo.AddComponent<BoxCollider2D>();

        CuboControlador controlador = cubo.AddComponent<CuboControlador>();
        controlador.Inicializar(gameManager, colorSeleccionado);

        Destroy(cubo, tiempoVidaCubo);
    }
}
