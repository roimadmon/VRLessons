using TMPro;
using UnityEngine;

public class UiPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numbertxt;
    [SerializeField] private TextMeshProUGUI _nametxt;
    [SerializeField] private TextMeshProUGUI _stationtxt;
    [SerializeField] private TextMeshProUGUI _scoretxt;
    
    // Start is called before the first frame update
    public void setUi(int number, string namePlayer, string station, int score)
    {
        _numbertxt.text = number + "";
        _stationtxt.text = station;
        _scoretxt.text = score + "";
        if(_nametxt)
            _nametxt.text = namePlayer;
    }
}
