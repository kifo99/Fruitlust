using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EscMenue : MonoBehaviour
{

    private GameObject canvas;
    private bool paused = false;
    // Start is called before the first frame update
    private void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
   private void Update()
    {
        if (Input.GetKey("escape"))
        {
            if (paused == true)
            {
                canvas.gameObject.SetActive(false);

                paused = false;
            }
            else
            {
                canvas.gameObject.SetActive(true);

                paused = true;
            }
        }

    }
}
