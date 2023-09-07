using System.Collections;
using UnityEngine;

public class RandomColorGenerator : MonoBehaviour
{

    public Pin Pin;
    public Button Button;
    public GameObject sides;
    public int numberOfTimesToRepeat = 30;
    public GameObject[] SetactiveColor; // Increase the array size to 6
    public GameObject Blue;
    public GameObject Red;
    public GameObject Yellow;
    public GameObject Green;
    public GameObject Pink;
    public GameObject Purple;
    public int randomHolder;

    // Start is called before the first frame update
    void Start()
    {
        SetactiveColor = new GameObject[6]; // Initialize the array with a size of 6
        SetactiveColor[0] = Blue;
        SetactiveColor[1] = Red;
        SetactiveColor[2] = Yellow;
        SetactiveColor[3] = Green;
        SetactiveColor[4] = Pink;
        SetactiveColor[5] = Purple;
    }

    // Update is called once per frame
    void Update()
    {
        if (Button.buttonPressed)
        {
            Button.buttonPressed = false;
            Button.gameObject.SetActive(false);
            //DisplayRandomColor();
        }

    }
}