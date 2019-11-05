using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowScript : MonoBehaviour
{
    //[SerializeField] int CogType;

    [SerializeField] int cogType = 0;
    public float currentSpeed = 0;
    public bool spin = false;
    public float deacceleration;


    public bool stopSpin = false;

    public float result;
    bool resultIs = false;


    Vector3 anglesToRotate;
    public Vector3 currentRotation;

    public int RowOrder;




    // Start is called before the first frame update
    void Start()
    {
        currentRotation = new Vector3(currentRotation.x % 360, currentRotation.y % 360, currentRotation.z % 360);
        this.transform.eulerAngles = currentRotation;

    }

    void Update()
    {
        //if (/*!start && */Input.GetKeyDown(KeyCode.Space) && !spinning)
        //{
        //    currentSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
        //    spinning = true;
        //}
        //if(start)
        //{
        //    currentSpeed = Random.Range(200, 300);
        //    start = false;
        //}
        


        if (spin)
        {
            SpinRow();
            //anglesToRotate.x = -currentSpeed * Time.deltaTime;
            //currentRotation = currentRotation + anglesToRotate;
            //currentRotation = new Vector3(currentRotation.x % 360, currentRotation.y % 360, currentRotation.z % 360);
            //this.transform.eulerAngles = currentRotation;



            //if (stopSpin)
            //{
            //    Deaccelerate();
            //}
        }

    }

   

    void SpinRow()
    {
        anglesToRotate.x = -currentSpeed * Time.deltaTime;
        currentRotation = currentRotation + anglesToRotate;
        currentRotation = new Vector3(currentRotation.x % 360, currentRotation.y % 360, currentRotation.z % 360);
        this.transform.eulerAngles = currentRotation;



        if (stopSpin)
        {

            Deaccelerate();
        }
    }

    public void Deaccelerate()
    {
        Vector3 destination = transform.eulerAngles;
        float oldCurrent = currentSpeed;
        if (currentSpeed <= oldCurrent)
        {
            currentSpeed -= deacceleration * Time.deltaTime;

            if (cogType == 1)
                CogType1();
        }
    }

    void CogType1()
    {


        if (currentSpeed <= Random.Range(60, 100))
        {
            currentSpeed = 0;
            if (currentRotation.x < -36.0f && currentRotation.x >= -108.0f)
            {
                transform.rotation = Quaternion.Euler(-72, 0, 0);
                currentRotation.x = transform.rotation.x;
                //ResultChecker(1);
                result = 1;
                print(RowOrder + ": " + result);
            }
            else if (currentRotation.x < -108.0f && currentRotation.x >= -180.0f)
            {
                transform.rotation = Quaternion.Euler(-144, 0, 0);
                currentRotation.x = transform.rotation.x;
                result = 2;
                print(RowOrder + ": " + result);
            }
            else if (currentRotation.x < -180.0f && currentRotation.x >= -252.0f)
            {
                transform.rotation = Quaternion.Euler(-216, 0, 0);
                currentRotation.x = transform.rotation.x;
                result = 3;
                print(RowOrder + ": " + result);
            }
            else if (currentRotation.x < -252.0f && currentRotation.x >= -324.0f)
            {
                transform.rotation = Quaternion.Euler(-288, 0, 0);
                currentRotation.x = transform.rotation.x;
                result = 4;
                print(RowOrder + ": " + result);
            }
            else if ((currentRotation.x < -324.0f && currentRotation.x >= -360.0f) || (currentRotation.x <= 0.0f && currentRotation.x >= -36.0f))
            {
                transform.rotation = Quaternion.Euler(-360, 0, 0);
                currentRotation.x = transform.rotation.x;
                result = 5;
                print(RowOrder + ": " + result);
            }
            else
                print("fitta..");


            stopSpin = false;
            spin = false;
        }
    }

    //public void ResultChecker(float x)
    //{
    //    result = x;
    //}
}
