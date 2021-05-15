using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class NameComputer : MonoBehaviour
{
    [SerializeField]
    private TextAsset databaseMale;

    [SerializeField]
    private TextAsset databaseFemale;
    public GameObject data_prefab;
    public GameObject data_content;
    public GameObject data_real;

    string real_name;

    void Start(){
        foreach(Transform child in data_content.transform){
            GameObject.Destroy(child.gameObject);
        }

        for(int i = 0; i < 50; i++){
            InfoRandomizer.DB_Male dbMale = JsonUtility.FromJson<InfoRandomizer.DB_Male>(databaseMale.text);
            InfoRandomizer.DB_Female dbFemale = JsonUtility.FromJson<InfoRandomizer.DB_Female>(databaseFemale.text);
            Data infoCharater = new Data(i, dbMale, dbFemale);
            GameObject data = Instantiate(data_prefab);
            data.GetComponent<DatabaseContent>().SetID(infoCharater.cardID);
            data.GetComponent<DatabaseContent>().SetNama(infoCharater.firstName + " " + infoCharater.middleName + " " + infoCharater.lastName);
            data.transform.SetParent(data_content.transform);
            data.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        }
    }
}