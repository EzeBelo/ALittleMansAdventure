using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMov : MonoBehaviour
{

    public GameObject Player;
   [SerializeField] private Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float cameraYpos;
        float camMax = 34.8f;
        float camMin = 0;

        if (Player.transform.position.y > -4)
        {
            cameraYpos = 0;
            Camera.main.backgroundColor = colors[0];
        }
        else if (Player.transform.position.y < -4.01 && Player.transform.position.y > -15)
        {
            cameraYpos = -10.13f;
            Camera.main.backgroundColor = colors[1];
        }
        else
        {
            cameraYpos = -19.19f;
            Camera.main.backgroundColor = colors[2];
                };

        Vector3 camPosition = transform.position;
        camPosition.y = cameraYpos;
        camPosition.x = Mathf.Clamp(Player.transform.position.x, camMin, camMax);
        transform.position = camPosition;
    }
}
