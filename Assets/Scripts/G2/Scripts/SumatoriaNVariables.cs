using UnityEngine;
using TMPro;
using System.Text;

public class SumatoriaNVariables : MonoBehaviour
{
    [Header("Referencias UI")]
    public TMP_InputField cantidadNumerosInput;
    public TMP_Text numerosGeneradosText;
    public TMP_Text sumaTotalText;
    public UnityEngine.UI.Button generarButton;

    void Start()
    {
        generarButton.onClick.AddListener(GenerarNumeros);
    }

    void GenerarNumeros()
    {
        int cantidad;
        if (int.TryParse(cantidadNumerosInput.text, out cantidad) && cantidad >= 1 && cantidad <= 20)
        {
            int sumaTotal = 0;
            StringBuilder numerosTexto = new StringBuilder();

            for (int i = 0; i < cantidad; i++)
            {
                int numeroAleatorio = Random.Range(1, 101);
                sumaTotal += numeroAleatorio;
                numerosTexto.Append(numeroAleatorio + (i < cantidad - 1 ? ", " : ""));
            }

            numerosGeneradosText.text = "Números generados: " + numerosTexto.ToString();
            sumaTotalText.text = "Suma total: " + sumaTotal;
        }
        else
        {
            numerosGeneradosText.text = "Por favor, ingresa un número entre 1 y 20.";
            sumaTotalText.text = "";
        }
    }
}
