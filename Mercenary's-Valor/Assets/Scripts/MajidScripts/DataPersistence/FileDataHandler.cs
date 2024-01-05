using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";

    private string dataFileName = "";
    private bool useEncryption = false;

    private readonly string encryptionCodeWord = "Ingenesis";

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public  GameData Load()
    {
        // use path.combine to account to difrent OS's having difrent path seperators 
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                //load the serialized data from the file 

                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //decryp data if it is encrypted
                if(useEncryption) 
                { 
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }


                //deserialize data from Json back to C# Object
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

            }
            catch (Exception e)
            {
                Debug.Log("Error acoured while trying to load data from file : " + fullPath + "\n" + e);
            }
        }
        return loadedData;

    }
    public void Save(GameData data) 
    {
        // use path.combine to account to difrent OS's having difrent path seperators 
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            // create the directory the file will be writen to if the file doesn't exist yet 
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serialize the c# game data object to Json
            string dataToStore = JsonUtility.ToJson(data, true);


            //optionaly encript the data
            if(useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }


            //write the serialized data to the file 
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e) 
        { 
            Debug.Log("Error Acoured while trying to save data to file : " +  fullPath + "\n" + e);
        }
    }

    // Encryption Function with XOR
    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
}

