using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// © 2017 TheFlyingKeyboard 
// theflyingkeyboard.net

public class FlashInMorseCode : MonoBehaviour {
    [SerializeField] private float dotTime;
    [SerializeField] private GameObject objectToUse;
    [SerializeField] private bool flashOnStart = false;
    [SerializeField] private bool repeat = false;

    [TextAreaAttribute(4, 15)]
    [SerializeField] private string textToShow;

    private float dashTime;

    private char[] letters = { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
    private string[] morseLetters = { "    ", ". _", "_ . . .", "_ . _ .", "_ . .", ".", ". . _ .", "_ _ .", ". . . .", ". .", ". _ _ _", "_ . _", ". _ . .", "_ _", "_ .", "_ _ _", ". _ _ .", "_ _ . _", ". _ .", ". . .", "_", ". . _", ". . . _", ". _ _", "_ . . _", "_ . _ _", "_ _ . .", ". _ _ _ _", ". . _ _ _", ". . . _ _", ". . . . _", ". . . . .", "_ . . . .", "_ _ . . .", "_ _ _ . .", "_ _ _ _ .", "_ _ _ _ _" };

    private void Start()
    {
        if (flashOnStart)
        {
            StartCoroutine(Flash(objectToUse, textToShow, dotTime));
        }
    }

    private IEnumerator Flash(GameObject objectToFlash, string textToConvert, float timeOfDot)
    {
        string textInMorse = "";

        ConvertTextToMorseCode(textToConvert, out textInMorse);

        Debug.Log(textInMorse);

        for (int i = 0; i < textInMorse.Length; i++)
        {
            if (textInMorse[i] == ' ')
            {
                objectToFlash.SetActive(false);

                yield return 0;
                yield return new WaitForSeconds(timeOfDot);
            }
            else if (textInMorse[i] == '.')
            {
                objectToFlash.SetActive(true);

                yield return 0;
                yield return new WaitForSeconds(timeOfDot);
            }
            else if(textInMorse[i] == '_')
            {
                objectToFlash.SetActive(true);

                yield return 0;
                yield return new WaitForSeconds(timeOfDot*3); // Dash changed to 3x dotTime
            }

            if (repeat)
            {
                if(i == textInMorse.Length - 1)
                {
                    i = 0;
                }
            }
        }
    }   

    private void ConvertTextToMorseCode(string textToConvert, out string convertedText)
    {
        convertedText = "";

        textToConvert = textToConvert.ToLower();

        for (int i = 0; i < textToConvert.Length; i++)
        {
            for (short j = 0; j < 37; j++)
            {
                if (textToConvert[i] == letters[j])
                {
                    convertedText += morseLetters[j];
                    convertedText += "   ";

                    break;
                }
            }
        }
    }

    public void WriteText(GameObject newObject = null, string newTextToShow = null, float newDotTime = -1.0f)
    {
        if (newObject != null && newTextToShow != null && newDotTime > 0.0f)
        {
            StartCoroutine(Flash(newObject, newTextToShow, newDotTime));
            return;
        }

        if (newObject != null && newTextToShow != null)
        {
            StartCoroutine(Flash(newObject, newTextToShow, dotTime));
            return;
        }

        if (newObject != null && newDotTime > 0.0f)
        {
            StartCoroutine(Flash(newObject, textToShow, newDotTime));
            return;
        }

        if (newTextToShow != null && newDotTime > 0.0f)
        {
            StartCoroutine(Flash(objectToUse, newTextToShow, newDotTime));
            return;
        }

        if (newTextToShow != null)
        {
            StartCoroutine(Flash(objectToUse, newTextToShow, dotTime));
            return;
        }

        if (newDotTime > 0.0f)
        {
            StartCoroutine(Flash(newObject, textToShow, newDotTime));
            return;
        }
    }
}