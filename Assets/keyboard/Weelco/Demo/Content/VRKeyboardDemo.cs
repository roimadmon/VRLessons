using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Weelco.VRKeyboard;

namespace Weelco {

    public class VRKeyboardDemo : MonoBehaviour {

        public int maxOutputChars = 30;

        public Text inputFieldLabel;
        public TextMeshPro inputFieldLabelPro;
        public VRKeyboardFull keyboard;
        private bool initKey = true;
        [SerializeField] private UnityEvent onClickKey;
        void Start() {
            if (keyboard) {
                keyboard.OnVRKeyboardBtnClick += HandleClick;
                keyboard.Init();
            }
        }

        void OnDestroy() {
            if (keyboard) {
                keyboard.OnVRKeyboardBtnClick -= HandleClick;
            }
        }
        
        private void HandleClick(string value) {
            if (initKey && inputFieldLabel)
            {
                initKey = false;
                inputFieldLabel.text = "";
            }
            else if (initKey && inputFieldLabelPro)
            {
                initKey = false;
                inputFieldLabelPro.text = "";
            }

                
            if (value.Equals(VRKeyboardData.BACK)) {
                BackspaceKey();
            }
            else if (value.Equals(VRKeyboardData.ENTER)) {
                EnterKey();
            }
            else {
                TypeKey(value);
            }
        }

        private void BackspaceKey()
        {
            if (inputFieldLabel && inputFieldLabel.text.Length >= 1)
            {
                inputFieldLabel.text = inputFieldLabel.text.Remove(inputFieldLabel.text.Length - 1, 1);
            }
            else if (inputFieldLabelPro && inputFieldLabelPro.text.Length >= 1)
            {
                inputFieldLabelPro.text = inputFieldLabelPro.text.Remove(inputFieldLabelPro.text.Length - 1, 1);
            }
        }

        private void EnterKey() {
            // Add enter key handler
        }

        private void TypeKey(string value) {
            char[] letters = value.ToCharArray();
            for (int i = 0; i < letters.Length; i++) {
                TypeKey(letters[i]);
            }
        }

        private void TypeKey(char key) {
            if (inputFieldLabel && inputFieldLabel.text.Length < maxOutputChars) {
                inputFieldLabel.text += key.ToString();
            }
            else  if (inputFieldLabelPro && inputFieldLabelPro.text.Length < maxOutputChars) {
                inputFieldLabelPro.text += key.ToString();
            }
        }    
    }
}