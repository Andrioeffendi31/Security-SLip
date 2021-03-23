using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    private string gender;
    private int skin;
    private int rambut;
    private int modelBaju;
    private int modelCelana;

    private int rand;

    public GameObject[] generatedCharacter;

    private void Start()
    {
        RandomCharacter();
    }

    public void RandomCharacter()
    {
        rand = Random.Range(0, 2);

        if (rand == 1)
        {
            gender = "Male";
            RandomVariasiMale();
            RandomRambut();
            RandomCelana();
            RandomBaju();

            for (int i = 0; i < generatedCharacter[skin].transform.childCount; i++)
            {
                var child = generatedCharacter[skin].transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(false);
            }

            generatedCharacter[skin].transform.GetChild(4).gameObject.SetActive(true);
            generatedCharacter[skin].transform.GetChild(rambut).gameObject.SetActive(true);
            generatedCharacter[skin].transform.GetChild(modelCelana + 5).gameObject.SetActive(true);
            generatedCharacter[skin].transform.GetChild(0 + 7).gameObject.SetActive(true);
            Instantiate(generatedCharacter[skin], transform.position, transform.rotation);
        }
        else if(rand == 0)
        {
            gender = "Female";
            RandomVariasiFemale();
            RandomRambut();
            RandomCelana();
            RandomBaju();

            for (int i = 0; i < generatedCharacter[skin + 4].transform.childCount; i++)
            {
                var child = generatedCharacter[skin + 4].transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(false);
            }

            generatedCharacter[skin + 4].transform.GetChild(0).gameObject.SetActive(true);
            generatedCharacter[skin + 4].transform.GetChild(rambut + 1).gameObject.SetActive(true);
            generatedCharacter[skin + 4].transform.GetChild(modelCelana + 4).gameObject.SetActive(true);
            generatedCharacter[skin + 4].transform.GetChild(modelBaju + 6).gameObject.SetActive(true);
            Instantiate(generatedCharacter[skin + 4], transform.position, transform.rotation);
        }

        if (GameConfiguration.DebugMode)
        {
            Debug.Log("Gender : " + gender);
            Debug.Log("Skin : " + skin);
            Debug.Log("Rambut : " + rambut);
            Debug.Log("Baju : " + modelBaju);
        }
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
