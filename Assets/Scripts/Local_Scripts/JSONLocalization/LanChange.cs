using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanChange : MonoBehaviour
{
    public JSON_Reader reader;
    public void ChangeLanguage()
    {
        reader.SetLanguage();
    }
}