using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameScript : MonoBehaviour
{
    public void ExitGame() {
        Debug.Log("Exit Button Clicked");
        Application.Quit();
    }

}
