using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CalcularDirecto : MonoBehaviour
{
    [Header("Valores Aleatorios")]
    private float materiaPrima;
    private float manoDeObra;
    private float cif;
    private float utilidad;

    [Header("Referencias UI")]
    public TMP_Text materiaPrimaText;
    public TMP_Text manoDeObraText;
    public TMP_Text cifText;
    public TMP_Text utilidadText;

    public TMP_InputField inputCostoTotal;
    public TMP_InputField inputUtilidadEsperada;
    public TMP_InputField inputPrecioVenta;

    public TMP_Text resultadoText_CTU;
    public TMP_Text resultadoText_UEU;
    public TMP_Text resultadoText_PV;
    public Button comprobarButton;

    void Start()
    {
        GenerarValoresAleatorios();
        comprobarButton.onClick.AddListener(ComprobarResultados);
    }

    void GenerarValoresAleatorios()
    {
        materiaPrima = Random.Range(100000f, 500001f);
        manoDeObra = Random.Range(100000f, 500001f);
        cif = Random.Range(100000f, 500001f);
        utilidad = Random.Range(50f, 121f);

        materiaPrimaText.text = "$" + materiaPrima.ToString("F2");
        manoDeObraText.text = "$" + manoDeObra.ToString("F2");
        cifText.text = "$" + cif.ToString("F2");
        utilidadText.text = utilidad.ToString("F2") + "%";
    }

    void ComprobarResultados()
    {
        float costoTotalCorrecto = materiaPrima + manoDeObra + cif;
        float utilidadEsperadaCorrecta = (utilidad/100)  * (costoTotalCorrecto/100);
        float precioVentaCorrecto = costoTotalCorrecto + utilidadEsperadaCorrecta;

        float costoTotalIngresado = float.Parse(inputCostoTotal.text);
        float utilidadEsperadaIngresada = float.Parse(inputUtilidadEsperada.text);
        float precioVentaIngresado = float.Parse(inputPrecioVenta.text);

        string resultadoCTU = "";
        string resultadoUEU = "";
        string resultadoPV = "";

        resultadoCTU += CompararValores("Costo Total", costoTotalIngresado, costoTotalCorrecto);
        resultadoUEU += CompararValores("Utilidad Esperada", utilidadEsperadaIngresada, utilidadEsperadaCorrecta);
        resultadoPV += CompararValores("Precio de Venta", precioVentaIngresado, precioVentaCorrecto);

        resultadoText_CTU.text = resultadoCTU;
        resultadoText_UEU.text = resultadoUEU;
        resultadoText_PV.text = resultadoPV;
    }

    string CompararValores(string nombre, float ingresado, float correcto)
    {
        if (Mathf.Approximately(ingresado, correcto))
        {
            return nombre + ": Correcto\n";
        }
        else
        {
            return nombre + ": Incorrecto. Valor correcto: $" + correcto.ToString("F2") + "\n";
        }
    }
}
