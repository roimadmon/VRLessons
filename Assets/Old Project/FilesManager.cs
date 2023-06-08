using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class FilesManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro notFoundFileLocation;
    public static FilesManager instance;
    public bool _init = true;
    private string pathCSVFile;
    [SerializeField] private Transform parentQuestions;
    [SerializeField] private GameObject prefabQuestion;
    [SerializeField] private List<questionScript> questions;

    private int index;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        
        instance = this;
        
    }

    void Start()
    {
        // LoadGame();
        Debug.Log( Application.persistentDataPath + "/questions.csv");
        Debug.Log( Application.dataPath + "/police/Questions/questions.csv");
    }
    public void LoadGame()
    {
        index = 0;
        // Debug.Log( Application.persistentDataPath + "/questions.csv");
        // pathCSVFile = Application.persistentDataPath + "/questions.csv";
        pathCSVFile = Application.dataPath + "/police/Questions/questions.csv";
        if (File.Exists(pathCSVFile))
        {

            
            // questionScript question = new questionScript();
            string[] allData = File.ReadAllLines(pathCSVFile);
            allData[0] = "";
            
            //
            int index = 0;
            foreach (string data in allData)
            {
                if (data.Length>0)
                {

                    questionScript question = new questionScript();
                    string[] splitData = data.Split(',');
                    question.numberQuestion = index++;
                    question._question = splitData[0];
                    question.time = float.Parse(splitData[1]);
                    question.currectAnswersNumber = int.Parse(splitData[2]);
                    question.shuffel = bool.Parse(splitData[3]);
                    for (int i = 4; i < splitData.Length; i++)
                    {
                        if(splitData[i].Length > 0)
                            question._answers.Add(splitData[i]);
                    }
                    
                    questions.Add(question);

                    StartCoroutine(CreateQuestion(question));
                }
            }

            _init = false;
            ManagerQuestions.instance.init();
        }
        else
        {
            Debug.Log("not found file");
            notFoundFileLocation.gameObject.SetActive(true);
            notFoundFileLocation.text = "move file to directory \n" + Application.persistentDataPath + "/questions.csv";
        }
    }

    // Update is called once per frame
    

    IEnumerator CreateQuestion(questionScript question)
    {   
        GameObject q = Instantiate(prefabQuestion, parentQuestions);
        q.name = q.name + " "+index++;
        yield return new WaitUntil(() => q.activeSelf);
        q.GetComponent<Question>().init(question);
        q.SetActive(false);

    }

    public void ResetGame()
    {
        questions.Clear();
        LoadGame();
    }
}
