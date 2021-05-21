using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterGenerator : MonoBehaviour
{
    private InfoRandomizer infoRandomizer;
    
    [SerializeField]
    private GameplayController gameplayController;

    [SerializeField]
    private CardController cardController;

    [SerializeField]
    private DoorController doorController;

    [SerializeField]
    private TextAsset databaseMale;

    [SerializeField]
    private TextAsset databaseFemale;

    [SerializeField]
    private GameObject[] characterPrefabs;

    [SerializeField]
    private Camera mainCamera;

    private GameObject character;

    private string gender;
    
    private int skin;

    private int rambut;

    private int modelBaju;

    private int modelCelana;

    private int rand;

    // Basic character info
    private Character characterInfo;

    private string firstName, middleName, lastName;

    private int genderType;

    private Info info;

    public void Create()
    {
        // Load names from database
        InfoRandomizer.DB_Male dbMale = JsonUtility.FromJson<InfoRandomizer.DB_Male>(databaseMale.text);
        InfoRandomizer.DB_Female dbFemale = JsonUtility.FromJson<InfoRandomizer.DB_Female>(databaseFemale.text);
        infoRandomizer = new InfoRandomizer(dbMale, dbFemale);

        genderType = infoRandomizer.GetRandomizeGender();
        firstName = infoRandomizer.GetRandomizeFirstName(genderType);
        middleName = infoRandomizer.GetRandomizeMiddleName(genderType);
        lastName = infoRandomizer.GetRandomizeLastName(genderType);
        
        info = CreateInfo();
        
        characterInfo = new Character(firstName, middleName, lastName, genderType, info);

        character = InstantiateCharacter();
        SetupCharacter(character, characterInfo);

        if (GameConfiguration.DebugMode)
        {
            Debug.Log("GenderType : " + genderType);
            Debug.Log("Gender : " + gender);
            Debug.Log("Skin : " + skin);
            Debug.Log("Rambut : " + rambut);
            Debug.Log("Baju : " + modelBaju);
        }
    }

    private Info CreateInfo()
    {
        Info info = new Info();
        // Inject generated character info into card
        // Also generate new card info
        info.card = GenerateCard();

        return info;
    }

    private Card GenerateCard()
    {
        // Generate card info
        int generatedPrimaryKey = infoRandomizer.RandomNumber(100, 500);
        string cardID = $"{infoRandomizer.GetRandomizeCardID(GameConfiguration.minCardID, GameConfiguration.maxCardID)}{generatedPrimaryKey}";

        DateTime dateTimeFrom = GameConfiguration.gameTime.AddDays(-GameConfiguration.generatedRangeCardDate);
        DateTime dateTimeTo = GameConfiguration.gameTime.AddDays(GameConfiguration.generatedRangeCardDate);

        // HARDCODED CREATED CARD DATE TIME
        DateTime dateCreated = GameConfiguration.gameTime.AddDays(-3);
        DateTime dateExpired = infoRandomizer.GetRandomDate(dateTimeFrom, dateTimeTo);

        return new Card(firstName, middleName, lastName, genderType, cardID, dateCreated, dateExpired);
    }

    private GameObject InstantiateCharacter()
    {
        GameObject spawnedCharacter;

        if (genderType == 0)
        {
            gender = "Male";
            RandomVariasiMale();
            RandomRambut();
            RandomCelana();
            RandomBaju();

            for (int i = 0; i < characterPrefabs[skin].transform.childCount; i++)
            {
                var child = characterPrefabs[skin].transform.GetChild(i).gameObject;
                if (child != null && child.name != "Canvas")
                    child.SetActive(false);
            }

            characterPrefabs[skin].transform.GetChild(4).gameObject.SetActive(true);
            characterPrefabs[skin].transform.GetChild(rambut).gameObject.SetActive(true);
            characterPrefabs[skin].transform.GetChild(modelCelana + 5).gameObject.SetActive(true);
            characterPrefabs[skin].transform.GetChild(0 + 7).gameObject.SetActive(true);

            spawnedCharacter = Instantiate(characterPrefabs[skin], transform.position, transform.rotation);
            return spawnedCharacter;
        }
        else if(genderType == 1)
        {
            gender = "Female";
            RandomVariasiFemale();
            RandomRambut();
            RandomCelana();
            RandomBaju();

            for (int i = 0; i < characterPrefabs[skin + 4].transform.childCount; i++)
            {
                var child = characterPrefabs[skin + 4].transform.GetChild(i).gameObject;
                if (child != null && child.name != "Canvas")
                    child.SetActive(false);
            }

            characterPrefabs[skin + 4].transform.GetChild(0).gameObject.SetActive(true);
            characterPrefabs[skin + 4].transform.GetChild(rambut + 1).gameObject.SetActive(true);
            characterPrefabs[skin + 4].transform.GetChild(modelCelana + 4).gameObject.SetActive(true);
            characterPrefabs[skin + 4].transform.GetChild(modelBaju + 6).gameObject.SetActive(true);

            spawnedCharacter = Instantiate(characterPrefabs[skin + 4], transform.position, transform.rotation);
            return spawnedCharacter;
        }

        return null;
    }

    private void SetupCharacter(GameObject character, Character characterInfo)
    {
        CharacterLogic characterLogic = character.GetComponent<CharacterLogic>();
        characterLogic.Attach(gameplayController, cardController, doorController, mainCamera);
        characterLogic.ApplyInfo(characterInfo);

        // Start character
        characterLogic.Init(infoRandomizer.RandomNumber(GameConfiguration.minPatientLevel, GameConfiguration.maxPatientLevel));

        // Send Object to Gameplay Controller
        gameplayController.SetInfo(character);
    }

    private void RandomVariasiMale()
    {
        rand = Random.Range(0, 4);
        skin = rand;
    }

    private void RandomVariasiFemale()
    {
        rand = Random.Range(0, 4);
        skin = rand;
    }

    private void RandomRambut()
    {
        if (gender == "Male")
        {
            rand = Random.Range(0, 4);
        }
        else
        {
            rand = Random.Range(0, 3);
        }
        
        rambut = rand;
    }

    private void RandomCelana()
    {
        rand = Random.Range(0, 2);
        modelCelana = rand;
    }

    private void RandomBaju()
    {
        rand = Random.Range(0, 2);
        modelBaju = rand;    
    }
}