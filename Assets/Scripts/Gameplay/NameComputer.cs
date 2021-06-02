using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameComputer : MonoBehaviour
{
    private readonly int TOTAL_DUMMY_DATA = 100;

    [SerializeField]
    private TextAsset databaseMale;

    [SerializeField]
    private TextAsset databaseFemale;

    private Animator searchAnimator;
    
    private SearchBar searchBar;

    private List<Data> database_data = new List<Data>();

    public GameObject data_prefab;

    public GameObject data_content;

    public GameObject pending;

    public int data_realIndex;

    public string data_realName;

    public string data_realID;

    private void Start()
    {
        GenerateDummyData();
    }

    private void GenerateDummyData()
    {
        InfoRandomizer.DB_Male dbMale = JsonUtility.FromJson<InfoRandomizer.DB_Male>(databaseMale.text);
        InfoRandomizer.DB_Female dbFemale = JsonUtility.FromJson<InfoRandomizer.DB_Female>(databaseFemale.text);

        pending.gameObject.SetActive(false);
        searchAnimator = pending.GetComponent<Animator>();

        foreach(Transform child in data_content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for(int i = 0; i < TOTAL_DUMMY_DATA; i++)
        {
            Data infoCharater = new Data(i, dbMale, dbFemale);
            database_data.Add(infoCharater);
            
            GameObject data = Instantiate(data_prefab);

            data.GetComponent<DatabaseContent>().SetID(infoCharater.cardID);
            data.GetComponent<DatabaseContent>().SetNama(infoCharater.firstName + " " + infoCharater.middleName + " " + infoCharater.lastName);
            data.transform.SetParent(data_content.transform);
            data.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        }
    }

    public void InjectData(Character character)
    {
        this.data_realID = character.GetCardID();
        this.data_realName = character.GetFullName();

        database_data.Add(new Data(0, character.GetCardID(), character.firstName, character.middleName, character.lastName));
    }

    public void ResetRealData()
    {
        data_realName = "";
        data_realID = "";
        data_realIndex = 0;

        database_data.Clear();
        GenerateDummyData();
    }

    public void SearchResult(string searchString)
    {
        pending.gameObject.SetActive(true);

        // Set animation level according to search time
        searchAnimator.SetFloat("speedMultiplier", ((float) 10 / GameConfiguration.databaseSearchTime));
        
        StartCoroutine(Pending(searchString));

        GameObject data = Instantiate(data_prefab);

        foreach(Transform child in data_content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void SearchDone(string searchString)
    {
        foreach(Transform child in data_content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach(Data data in database_data)
        {
            if (data.GetFullName().Contains(searchString) || data.GetCardID().Contains(searchString))
            {
                GameObject dataUI = Instantiate(data_prefab);

                dataUI.GetComponent<DatabaseContent>().SetID(data.GetCardID());
                dataUI.GetComponent<DatabaseContent>().SetNama(data.GetFullName());
                dataUI.transform.SetParent(data_content.transform);
                dataUI.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            }
        }
    }

    IEnumerator Pending(string searchForName)
    {
        Debug.Log("Courotine Start");
        Debug.Log(GameConfiguration.databaseSearchTime);

        yield return new WaitForSeconds(GameConfiguration.databaseSearchTime);

        pending.gameObject.SetActive(false);
        SearchDone(searchForName);
        Debug.Log("Courotine Done");
    }
}