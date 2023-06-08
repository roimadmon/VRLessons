// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.IO;
// using UnityEditor;
//
// public class CSVtoSO
// {
//
//     private static string pathCSVFile = Application.dataPath+"/file.csv";
//     // Start is called before the first frame update
//     [MenuItem("Utilities/Generate Questions")]
//     public static void GenerateQuestions()
//     {
//         string[] allData = File.ReadAllLines(pathCSVFile);
//         foreach (string data in allData)
//         {
//             string[] splitData = data.Split(',');
//
//             questionScript question = new questionScript();
//             question._q = splitData[0];
//             question._q = splitData[0];
//             
//         } 
//         
//         
//     }
// }
