using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControllerGame : MonoBehaviour
{
    List<PreguntasMultiples> PreguntasMultiples = new List<PreguntasMultiples>();
    public TextAsset Text;
    public TextMeshProUGUI pregunta;
    public TextMeshProUGUI opcion1;
    public TextMeshProUGUI opcion2;
    public TextMeshProUGUI opcion3;
    public TextMeshProUGUI opcion4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadPreguntasMultiples();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadPreguntasMultiples()
    {
        string texto = Text.text;
        string[] informacion = texto.Split("-");
        Debug.Log(informacion[0]);
        string pregunta = informacion[0];
        string opcion1 = informacion[1];
        string opcion2 = informacion[2];
        string opcion3 = informacion[3];
        string opcion4 = informacion[4];
    }
}
