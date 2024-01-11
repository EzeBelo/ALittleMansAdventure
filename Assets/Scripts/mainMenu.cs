using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField] GameObject keySelect;
    private int selectPosition = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 selectPos = keySelect.transform.position;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectPosition = selectPosition - 1;
        }



        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectPosition = selectPosition + 1;
;
        }


        if (selectPosition == 1)
        {
            selectPos.y = -0.5f;
        } else if (selectPosition == 2)
        {
            selectPos.y = -1.55f;
        } else if (selectPosition == 3)
        {
            selectPos.y = -2.6f;
        } else if(selectPosition > 3)
        {
            selectPosition = 1;
        } else if(selectPosition < 1)
        {
            selectPosition = 3;
        }

        keySelect.transform.position = selectPos;

        if(selectPosition == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level");
        } else if (selectPosition == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("opciones");
        } else if(selectPosition == 3 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("creditos");
        }
    }
}
