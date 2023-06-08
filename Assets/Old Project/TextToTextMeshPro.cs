using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TextToTextMeshPro : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMeshPro;
    private Text _text;
    private string saveText;
    const string playerNamePrefKey = "PlayerName";
    private string nikeName;
    // Start is called before the first frame update
    private void Start()
    {
        _text = transform.GetComponent<Text>();
        saveText = "";
        _text.text = "";
        nikeName = "Player "+Random.Range(0,9999);
        Debug.Log("Create "+ nikeName);
        PhotonNetwork.NickName = nikeName;
        PlayerPrefs.SetString(playerNamePrefKey, nikeName);
    }

    private void Update()
    {
        if (saveText!=_text.text)
        {
            saveText = _text.text;
            OnChangeText();
        }
    }



    void OnChangeText()
    {
        _textMeshPro.text = saveText;
        _textMeshPro.isRightToLeftText = false;
        // _textMeshPro.fontSize = 300;
    }
}
