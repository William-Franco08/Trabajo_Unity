using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class DictionaryDemoUI : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField inputKey;
    public TMP_InputField IdVehiculo;
    public TMP_InputField Marca;
    public TMP_InputField Modelo;
    public TMP_InputField placa;
    public TMP_InputField NumeroPuertas;
    public TextMeshProUGUI resultView;
    public TextMeshProUGUI dictView;
    public GameObject panelDirectorio;
    public GameObject panelStack;
    public GameObject panelQueue;

    private Dictionary<string, Carro> dict = new Dictionary<string, Carro>();

    public void mostrarDirectorio()
    {
        panelDirectorio.SetActive(true);
        panelQueue.SetActive(false);
        panelStack.SetActive(false);
    }

    public void mostrarStack()
    {
        panelDirectorio.SetActive(false);
        panelQueue.SetActive(false);
        panelStack.SetActive(true);
    }

    public void mostrarQueue()
    {
        panelDirectorio.SetActive(false);
        panelQueue.SetActive(true);
        panelStack.SetActive(false);
    }

    public void AddOrUpdate()
    {
        string k = inputKey.text.Trim();

        if (string.IsNullOrEmpty(k))
        {
            resultView.text = "La clave está vacía";
            return;
        }

        int puertas = int.Parse(NumeroPuertas.text);

        Carro carro = new Carro(
            IdVehiculo.text,
            Marca.text,
            Modelo.text,
            placa.text,
            puertas
        );

        dict[k] = carro;

        resultView.text = $"Guardado:\nClave: {k}\nID: {carro.idVehiculo}, Marca: {carro.marca}, Modelo: {carro.modelo}, Placa: {carro.placa}, Puertas: {carro.numeroPuertas}";

        ShowDictionary();
    }

    public void Get()
    {
        string k = inputKey.text.Trim();

        if (string.IsNullOrEmpty(k))
        {
            resultView.text = "La clave está vacía";
            return;
        }

        if (dict.TryGetValue(k, out Carro carro))
        {
            resultView.text =
                $"Encontrado:\nClave: {k}\nID: {carro.idVehiculo}, Marca: {carro.marca}, Modelo: {carro.modelo}, Placa: {carro.placa}, Puertas: {carro.numeroPuertas}";
        }
        else
        {
            resultView.text = $"No existe la clave: {k}";
        }
    }

    public void Remove()
    {
        string k = inputKey.text.Trim();

        if (string.IsNullOrEmpty(k))
        {
            resultView.text = "La clave está vacía";
            return;
        }

        bool removed = dict.Remove(k);

        resultView.text = removed
            ? $"Eliminado: {k}"
            : $"No se pudo eliminar (no existe): {k}";

        ShowDictionary();
    }

    public void Clear()
    {
        dict.Clear();
        resultView.text = "Diccionario limpiado";
        ShowDictionary();
    }

    private void ShowDictionary()
    {
        var sb = new StringBuilder();
        sb.AppendLine("DICCIONARIO (Clave → Valor)");

        foreach (var kv in dict)
        {
            Carro c = kv.Value;

            sb.AppendLine(
                $"• {kv.Key} → ID: {c.idVehiculo}, Marca: {c.marca}, Modelo: {c.modelo}, Placa: {c.placa}, Puertas: {c.numeroPuertas}"
            );
        }

        dictView.text = sb.ToString();
    }
}