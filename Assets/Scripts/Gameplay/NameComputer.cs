using System.Collections;
using UnityEngine;

public class NameComputer : MonoBehaviour
{
    [SerializeField]
    private TextAsset databaseMale;

    [SerializeField]
    private TextAsset databaseFemale;
    private SearchBar searchBar;
    public GameObject data_prefab;
    public GameObject data_content;
    public GameObject pending;

    public string data_realName;
    public string data_realID;
    int counter_name = 50;

    void Start(){
        pending.gameObject.SetActive (false);

        foreach(Transform child in data_content.transform){
            GameObject.Destroy(child.gameObject);
        }

        for(int i = 0; i < counter_name; i++){
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

    public bool CheckRealData(){
        if(data_realName == ""){ return false; }
        return true;
    }

    void ResetRealData(){
        data_realName = "";
    }

    public void SearchResult(string searchForName){
        //For Testing
        data_realID = "69420";
        data_realName = "nemo ded";
        //////////////////////////////////////////

        pending.gameObject.SetActive (true);
        StartCoroutine(Pending(searchForName));

        GameObject data = Instantiate(data_prefab);

        foreach(Transform child in data_content.transform){
            GameObject.Destroy(child.gameObject);
        }
    }

    public void SearchDone(string searchForName){
        GameObject data = Instantiate(data_prefab);

        if(searchForName == data_realName){
            foreach(Transform child in data_content.transform){
                GameObject.Destroy(child.gameObject);
            }
            data.GetComponent<DatabaseContent>().SetID(data_realID);
            data.GetComponent<DatabaseContent>().SetNama(data_realName);
            data.transform.SetParent(data_content.transform);
            data.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        }
    }

    IEnumerator Pending(string searchForName){
        Debug.Log("Courotine Start");

        yield return new WaitForSeconds(10);

        pending.gameObject.SetActive (false);
        SearchDone(searchForName);
        Debug.Log("Courotine Done");
    }
}