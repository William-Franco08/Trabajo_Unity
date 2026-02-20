using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class QueueDemoUI : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField IdVehiculo;
    public TMP_InputField Marca;
    public TMP_InputField Modelo;
    public TMP_InputField placa;
    public TMP_InputField NumeroPuertas;
    public TextMeshProUGUI queueView;
    public TextMeshProUGUI frontView;

    private Queue<Carro> queue = new Queue<Carro>();

    public void Enqueue()
    {
        int puertas = int.Parse(NumeroPuertas.text);

        queue.Enqueue(new Carro(IdVehiculo.text, Marca.text, Modelo.text, placa.text, puertas));
        ShowQueue();
    }

    public void Dequeue()
    {
        if (queue.Count == 0) return;

        queue.Dequeue();
        ShowQueue();
    }

    public void Clear()
    {
        queue.Clear();
        ShowQueue();
    }

    private void ShowQueue()
    {
        Carro top =queue.Peek();
        frontView.text = queue.Count > 0 ? $"FRENTE: {top.idVehiculo} - {top.marca} - {top.modelo} - {top.placa} - {top.numeroPuertas}" : "FRENTE: (vacío)";

        var sb = new StringBuilder();
        sb.AppendLine("COLA (Frente → Final)");

        foreach (var item in queue)
            sb.AppendLine("ID: " + item.idVehiculo + ", Marca: " + item.marca + ", Modelo: " + item.modelo + ", Placa: " + item.placa + ", Puertas: " + item.numeroPuertas);

        queueView.text = sb.ToString();
    }
}