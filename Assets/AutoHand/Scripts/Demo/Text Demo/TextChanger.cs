using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;
using UnityEngine.UI;

namespace Autohand.Demo{
    public class TextChanger : MonoBehaviour{
        public TMPro.TextMeshPro textMeshPro;
        [SerializeField] private Text _text;
        Coroutine changing;
        Coroutine hide;
        
        public void UpdateText(string newText, float upTime) {

        }

        public void LTR(string s)
        {
            // _text.text += s[0];
            // if(s.Length <= 1)
                // return;
            // _text.text = _text.text.Replace(_text.text, s[s.Length - 1] + _text.text);
            _text.text = "";
            Debug.Log(s.Length+" :" +s);
            for (int i =  s.Length-1 ; i >= 0; i--)
            {
                _text.text += s[i];
            }
        }
        
        
        
        public void UpdateText(string newText)
        {
            Debug.Log(newText);
            if(textMeshPro)
                textMeshPro.text = newText;
        }

        public void UpdateTextString(string newText)
        {
            Debug.Log(newText);
            if (textMeshPro)
                textMeshPro.text = newText + "";
        }

        public void UpdateTextint(float newText)
        {
            // Debug.Log(newText);
            if(textMeshPro)
                textMeshPro.text = ((int)newText+1)+"";
        }
        
        public void UpdateTextScore(float newText)
        {
            // Debug.Log(newText);
            if(textMeshPro)
                textMeshPro.text = ((int)newText)+"";
        }
        IEnumerator ChangeText(float seconds, string newText) {
            //float totalTime = 1f;
            //var timePassed = 0f;
            //text.text = newText;
            //text.alpha = 0;

            //while(timePassed <= totalTime) {
            //    text.alpha = (timePassed/totalTime);
            //    timePassed += Time.deltaTime;
            //    if(totalTime >= timePassed)
            //        text.alpha = 1;
            //    yield return new WaitForFixedUpdate();
            //}

            //yield return new WaitForSeconds(seconds);

            //totalTime = 2f;
            //timePassed = 0f;
            //while(timePassed <= totalTime) {
            //    text.alpha = 1-(timePassed/totalTime);
            //    timePassed += Time.deltaTime;
            //    if(totalTime >= timePassed)
            //        text.alpha = 0;
            //    yield return new WaitForFixedUpdate();
            //}

            yield return new WaitForFixedUpdate();
            textMeshPro.text = "";
        }

        private void OnDestroy() {
            // textMeshPro.text = "";
        }
    }
}
