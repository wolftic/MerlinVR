using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour {

    [SerializeField] private Text _text;

    public void WriteText(string firstText , float secondText)
    {
        _text.text = firstText + secondText;
    }

}
