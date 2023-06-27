using System.Collections.Generic;
using UnityEngine;

namespace Weelco.VRKeyboard {
    public class VRKeyboardFull : VRKeyboardBase {
        
        private VRKeyboardButton[] keys;
        private int index = 0;
        private bool areLettersActive = true;
        private bool isLowercase = true;        
        private bool isHebrew = false;

        void OnDestroy() {
            if (Initialized) {
                foreach (VRKeyboardButton key in keys) {
                    key.OnVRKeyboardBtnClick -= HandleClick;
                }
            }
        }

        public void Init() {
            if (!Initialized) {
                keys = transform.GetComponentsInChildren<VRKeyboardButton>();
                for (int i = 0; i < keys.Length; i++) {
                    keys[i].Init();
                    // keys[i].SetKeyText(allLettersLowercase[i]);
                    keys[i].SetKeyText(allLettersHebrew[i]);
                    keys[i].OnVRKeyboardBtnClick += HandleClick;
                }

                Initialized = true;
            }

            // index = 0;
            // ChangeSpecialLetters();
        }

        private void HandleClick(string value) {
            // Debug.Log("Handle Click : " + value);
            if (value.Equals(SYM) /*|| value.Equals(ABC) */ ||value.Equals(HEB)) {
                ChangeSpecialLetters();
            }
            else if (value.Equals(UP) || value.Equals(LOW)) {
                LowerUpperKeys();
            }            
            else {
                if (OnVRKeyboardBtnClick != null)
                    OnVRKeyboardBtnClick(value);
            }
        }

        private void ChangeSpecialLetters()
        {
            // string[] ToDisplay;
            // index++;
            // switch (index % 3)
            // {
            //     case 0:
            //         ToDisplay = isLowercase ? allLettersLowercase : allLettersUppercase;
            //         break;
            //     case 1:
            //         ToDisplay = allLettersHebrew;
            //         break;
            //     case 2:
            //         ToDisplay = allSpecials;
            //         break;
            //     default:
            //         ToDisplay = allLettersLowercase;
            //         break;
            // }

            areLettersActive = !areLettersActive;
            string[] ToDisplay = areLettersActive ? allLettersHebrew : allSpecialsHeb;
            // ToDisplay= areLettersActive
            //     ? (isHebrew ? allLettersHebrew : isLowercase ? allLettersLowercase : allLettersUppercase)
            //     : allSpecials;
            bool ignoreIcon = false;
            for (int i = 0; i < keys.Length; i++) {
                ignoreIcon = (!areLettersActive && (ToDisplay[i].Equals("№")));
                keys[i].SetKeyText(ToDisplay[i], ignoreIcon);
            }
        }

        private void LowerUpperKeys()
        {
            index = 0;
            isLowercase = !isLowercase;
            string[] ToDisplay = isLowercase ? allLettersLowercase : allLettersUppercase;
            for (int i = 0; i < keys.Length; i++) {
                keys[i].SetKeyText(ToDisplay[i]);
            }
        } 
         
// allSpecialsHebrew
        // allLettersHebrew;
    }
}
