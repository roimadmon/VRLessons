using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UiStation : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    

    private List<string> _names = new List<string>()
    {
        "גיל","רונן","איתי","סתיו","אדיר",
        "גיא","רועי","לב","מיתר","שמואל",
        "נופר","אביתר","נועה","לירון","אוראל",
        "נועם","יפת","מנחם","שיר","עוזי",
        "רביד","גפן","כפיר","ים","עידו",
        "צביקה","עלמה","יניב","שיר","לירן",
    }; 
    private List<string> _stations = new List<string>()
    {
        "ירושלים","כפר סבא","תל אביב","חדרה","חיפה",
        "בית שמש","באר שבע","אילת","דימונה","בנימינה",
    }; 
    // Start is called before the first frame update
    

    void Start()
    {
        int i = 1;
        int scoure = 9999;
        int count = _stations.Count;
       
        foreach (var namePlayer in _names)
        {
            GameObject g =  Instantiate(_ui, transform);
            scoure -= Random.Range(10, 300);
            g.GetComponent<UiPlayer>().setUi(i++,namePlayer,_stations[Random.Range(0, count)],scoure);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
