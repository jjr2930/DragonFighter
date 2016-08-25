using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

using UnityEditor;
using UnityEngine;


public class SaveConfigure 
{
    [MenuItem("Window/Save Configure")]
    static void Save()
    {
        string json = JsonUtility.ToJson(Configure.Instance,true);
        string filePath = @"Assets/Resources/Tables/Configure.txt";
        
        using (FileStream fs = File.Open(filePath, FileMode.OpenOrCreate))
        {
            Byte[] toByte = new UTF8Encoding(true).GetBytes(json);
            fs.Write(toByte, 0, toByte.Length);

            fs.Close();
        }        
    }
}