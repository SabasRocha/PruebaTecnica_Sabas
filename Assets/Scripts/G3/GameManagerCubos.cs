using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameManagerCubos : MonoBehaviour
{
    [Header("Configuración del Juego")]
    public CuboGenerator cuboGenerator;
    public float tiempoJuego = 30f;
    public float intervaloAparicion = 0.5f;

    [Header("UI")]
    public TMP_Text tiempoRestanteText;
    public TMP_Text puntajeTotalText;
    public TMP_Text puntajeRojoText;
    public TMP_Text puntajeAzulText;
    public TMP_Text puntajeAmarilloText;
    public UnityEngine.UI.Button iniciarButton;

    private float tiempoRestante;
    private int puntajeTotal;
    private Dictionary<string, int> puntajePorColor;
    private bool juegoActivo = false;

    void Start()
    {
        iniciarButton.onClick.AddListener(IniciarJuego);
        puntajePorColor = new Dictionary<string, int>
        {
            {"Rojo", 0},
            {"Azul", 0},
            {"Amarillo", 0}
        };
        ActualizarUI();
    }

    void IniciarJuego()
    {
        juegoActivo = true;
        tiempoRestante = tiempoJuego;
        puntajeTotal = 0;
        puntajePorColor["Rojo"] = 0;
        puntajePorColor["Azul"] = 0;
        puntajePorColor["Amarillo"] = 0;
        ActualizarUI();
        InvokeRepeating("GenerarCubo", 0f, intervaloAparicion);
    }

    void Update()
    {
        if (!juegoActivo) return;

        tiempoRestante -= Time.deltaTime;
        tiempoRestanteText.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante).ToString();

        if (tiempoRestante <= 0)
        {
            juegoActivo = false;
            CancelInvoke("GenerarCubo");
        }
    }

    void GenerarCubo()
    {
        cuboGenerator.GenerarCubo(this);
    }

    public void SumarPuntaje(Color color)
    {
        puntajeTotal++;
        if (color == Color.red) puntajePorColor["Rojo"]++;
        else if (color == Color.blue) puntajePorColor["Azul"]++;
        else if (color == Color.yellow) puntajePorColor["Amarillo"]++;

        ActualizarUI();
    }

    void ActualizarUI()
    {
        puntajeTotalText.text = "Puntaje Total: " + puntajeTotal;
        puntajeRojoText.text = "Rojos: " + puntajePorColor["Rojo"];
        puntajeAzulText.text = "Azules: " + puntajePorColor["Azul"];
        puntajeAmarilloText.text = "Amarillos: " + puntajePorColor["Amarillo"];
    }
}

public class CuboControlador : MonoBehaviour
{
    private GameManagerCubos juego;
    private Color colorCubo;

    public void Inicializar(GameManagerCubos juego, Color color)
    {
        this.juego = juego;
        this.colorCubo = color;
    }

    void OnMouseDown()
    {
        juego.SumarPuntaje(colorCubo);
        Destroy(gameObject);
    }
}
