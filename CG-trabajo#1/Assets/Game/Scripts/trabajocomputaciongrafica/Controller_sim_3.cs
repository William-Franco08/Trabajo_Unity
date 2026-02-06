using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Controller_sim_3 : MonoBehaviour
{
    List<Student> list_students = new List<Student>();
    public TMP_InputField tnameS;
    public TMP_InputField tmailS;
    public TMP_InputField tageS;
    public TMP_InputField tcourseS;
    public TMP_InputField tcodeS;
    public TextMeshProUGUI label;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddStudent()
    {
        Student student = new Student();

        student.CourseS = tcourseS.text;
        student.CodeS = tcodeS.text;
        student.NameP = tnameS.text;
        student.MailP = tmailS.text;
        student.AgeP = int.Parse(tageS.text);

        list_students.Add(student);

        Debug.Log(
            "Student added: " +
            student.NameP + ", " +
            student.MailP + ", " +
            student.AgeP + ", " +
            student.CourseS + ", " +
            student.CodeS
        );
    }


    public void SearchStudent()
    {   
        foreach (Student s in list_students)
        {

            Debug.Log("Nombre: " + s.NameP + ", Mail: " + s.MailP +", Edad: " +s.AgeP+", Curso: " + s.CourseS+" Codigo: "+s.CodeS);

        }
    }
    public void SearchPanel()
    {
        label.text = "";
        foreach (Student s in list_students)
        {
            label.text += "Nombre: " + s.NameP + "\n" +
            "Mail: " + s.MailP + "\n" +
            "Edad: " + s.AgeP + "\n" +
            "Curso: " + s.CourseS + "\n" +
            "Código: " + s.CodeS + "\n"+
            "------------------------------------";

        }
    }
    [System.Serializable]
    public class Student
    {
        public string CourseS;
        public string CodeS;
        public string NameP;
        public string MailP;
        public int AgeP;
    }
    [System.Serializable]
    public class StudentList
    {
        public List<Student> students;
    }


    public void SaveToJson()
    {
        string path = Application.persistentDataPath + "/students.json";

        StudentList wrapper = new StudentList();
        wrapper.students = list_students;

        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(path, json);

        Debug.Log("JSON:\n" + json);
    }


    public void LoadJson()
    {
        string path = Application.persistentDataPath + "/students.json";

        if (!File.Exists(path))
        {
            label.text = "No se encontró el archivo JSON.";
            return;
        }

        string json = File.ReadAllText(path);
        StudentList wrapper = JsonUtility.FromJson<StudentList>(json);

        if (wrapper == null || wrapper.students == null)
        {
            label.text = "Error al leer el archivo JSON.";
            return;
        }

        list_students = wrapper.students;

        label.text = "Datos cargados correctamente:\n\n";

        foreach (Student s in list_students)
        {
            label.text +=
                $"Nombre: {s.NameP}\n" +
                $"Mail: {s.MailP}\n" +
                $"Edad: {s.AgeP}\n" +
                $"Curso: {s.CourseS}\n" +
                $"Código: {s.CodeS}\n" +
                "----------------------\n";
        }
    }
}
