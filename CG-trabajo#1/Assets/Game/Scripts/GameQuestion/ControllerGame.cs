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
        pregunta.text = informacion[0];
        opcion1.text = informacion[1];
        opcion2.text = informacion[2];
        opcion3.text = informacion[3];
        opcion4.text = informacion[4];
    }
}
