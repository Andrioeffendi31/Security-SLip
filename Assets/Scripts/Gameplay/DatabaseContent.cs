using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseContent : MonoBehaviour
{
    public Text lbl_id, lbl_nama;

    public void SetID(string id){
        lbl_id.text = id;
    }

    public void SetNama(string nama){
        lbl_nama.text = nama;
    }

    public string GetID(){
        return lbl_id.text;
    }

    public string GetNama(){
        return lbl_nama.text;
    }
}