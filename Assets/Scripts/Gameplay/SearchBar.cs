using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchBar : MonoBehaviour
{
    [SerializeField]
    private NameComputer nameComputer;
    public InputField searchBar;

    public void Search(){
        Debug.Log("Searching for " + searchBar.text + ".");
        nameComputer.SearchResult(searchBar.text);
    }
}
