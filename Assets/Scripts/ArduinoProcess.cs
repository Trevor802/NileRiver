using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ArduinoProcess : MonoBehaviour
{
    public static ArduinoProcess instance = null;

    SerialPort sp = new SerialPort("COM3", 9600);
    private float degreeA = 0f;
    private float degreeB = 0f;
    private float degreeC = 0f;
    private float degreeD = 0f;
    private float degreeE = 0f;
    private float degreeF = 0f;
    private float prevA;
    private float prevB;
    private float prevC;
    private float prevD;
    private float prevE;
    private float prevF;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!sp.IsOpen)
            sp.Open();
        sp.ReadTimeout = 5;
    }

    // Update is called once per frame
    void Update()
    {
        prevA = degreeA;
        prevB = degreeB;
        prevC = degreeC;
        prevD = degreeD;
        prevE = degreeE;
        prevF = degreeF;
        try
        {
            string inputStr = sp.ReadLine();
            if (inputStr[0] == 'A')
            {
                degreeA = float.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
            else if (inputStr[0] == 'B')
            {
                degreeB = float.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
            else if (inputStr[0] == 'C')
            {
                degreeC = float.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
            else if (inputStr[0] == 'D')
            {
                degreeD = float.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
            else if (inputStr[0] == 'E')
            {
                degreeE = float.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
            else if (inputStr[0] == 'F')
            {
                degreeF = float.Parse(inputStr.Substring(1, inputStr.Length - 1));
            }
        }
        catch (System.TimeoutException)
        {

        }
    }

    public float GetDegree(char angle)
    {
        switch (angle)
        {
            case 'A':
                return degreeA;
            case 'B':
                return degreeB;
            case 'C':
                return degreeC;
            case 'D':
                return degreeD;
            case 'E':
                return degreeE;
            case 'F':
                return degreeF;
        }
        return 0;
    }

    public bool InputAChange() { return degreeA != prevA; }
    public bool InputBChange() { return degreeB != prevB; }
    public bool InputCChange() { return degreeC != prevC; }
    public bool InputDChange() { return degreeD != prevD; }
    public bool InputEChange() { return degreeE != prevE; }
    public bool InputFChange() { return degreeF != prevF; }
}
