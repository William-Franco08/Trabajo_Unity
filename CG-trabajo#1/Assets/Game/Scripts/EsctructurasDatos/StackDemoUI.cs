using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class StackDemoUI : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField IdVehiculo;
    public TMP_InputField Marca;
    public TMP_InputField Modelo;
    public TMP_InputField placa;
    public TMP_InputField NumeroPuertas;
    public TextMeshProUGUI stackView;
    public TextMeshProUGUI topView;
    

    private Stack<Carro> stack = new Stack<Carro>();

    public void Push()
    {
        int puertas = int.Parse(NumeroPuertas.text);
        stack.Push(new Carro(IdVehiculo.text, Marca.text, Modelo.text, placa.text, puertas));

        ShowStack();
    }

    public void Pop()
    {
        if (stack.Count == 0) return;
        stack.Pop();
        ShowStack();
    }

    public void Clear()
    {
        stack.Clear();
        ShowStack();
    }

    private void ShowStack()
    {
        Carro top = stack.Peek();
        topView.text = stack.Count > 0 ? $"TOP: {top.idVehiculo} - {top.marca} - {top.modelo} - {top.placa} - {top.numeroPuertas}" : "TOP: (vacío)";

        var sb = new StringBuilder();
        sb.AppendLine("PILA (Top → Bottom)");

        foreach (var item in stack)
            sb.AppendLine("ID: " + item.idVehiculo + ", Marca: "+item.marca+", Modelo: "+item.modelo+", Placa: "+item.placa+", Puertas: "+item.numeroPuertas);

        stackView.text = sb.ToString();
    }
}
