using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{

    const string SCORE = "score";
    const string VOLUME = "volume";
    const string CHARACTER = "character";
    const string DIFFICULTY = "difficulty";


    public static void SetScore(float score)
    {

        if (score > 0)
        {
            PlayerPrefs.SetFloat(SCORE, score);
        }
        else
        {
            Debug.LogError("score menor que 0");
        }
    }

    public static float GetScore()
    {
        return PlayerPrefs.GetFloat(SCORE);
    }

    public static void SetVolume(float volumen)
    {

        if (volumen >= 0 && volumen <= 3)
        {
            PlayerPrefs.SetFloat(VOLUME, volumen);
        }
        else
        {
            Debug.LogError("volume out of bounds");
        }

    }

    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME);
    }

    public static void SetCharacter(int pj)
    {
        if (pj >= 0 && pj <= 2)
        {
            PlayerPrefs.SetInt(CHARACTER, pj);
        }
        else
        {
            Debug.LogError("Pj out of bounds");
        }
    }

    public static int GetCharacter()
    {
        return PlayerPrefs.GetInt(CHARACTER);
    }

    public static void SetDifficulty(int dif)
    {
        if (dif >= 0 && dif < 2)
        {
            PlayerPrefs.SetInt(DIFFICULTY, dif);
        }
        else
        {
            Debug.LogError("Dif out of bounds");
        }
    }

    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY);
    }
}
