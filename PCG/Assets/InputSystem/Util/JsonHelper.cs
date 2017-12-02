using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class JsonHelper
{

    public static void WriteSaveData(string fileName, string jsonData)
    {
        string fullPath = Path.Combine(Application.dataPath, fileName);

        using (StreamWriter sw = new StreamWriter(fullPath))
        {
            sw.WriteLine(jsonData);
        }    
    }

    public static string LoadSaveData(string fileName)
    {
        string fullPath = Path.Combine(Application.dataPath, fileName);
        string result;

        if (!File.Exists(fullPath))
        {
            result = "none";
            return result;
        }

        using (StreamReader sr = new StreamReader(fullPath))
        {
           result = sr.ReadToEnd();
        }

        return result;
    }

}
