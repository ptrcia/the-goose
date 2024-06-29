using System.Collections;
using System.Data;
using UnityEngine;

public class ThrowDice : MonoBehaviour
{
    new Rigidbody rigidbody;
    public bool canRoll = true;
    public bool hasRolled = false;
    bool clickedOn = false;
    DiceRaycast[] diceFaces;

    [SerializeField]
    Vector3 vectorTorque;

    bool diceResultUpdated = false;
    int diceResult = 0;

    [Header("Material")]
    public Material translucentMaterial;
    public Material opaqueMaterial;

    //private int[] values = new int[5] {2,2,3,6,1};
    //private int counter = 0;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity = 100f;
        rigidbody.angularDrag = 0.5f;

        diceFaces = GetComponentsInChildren<DiceRaycast>();
    }

    private void Start()
    {
        ChangeMaterial(gameObject, translucentMaterial);
    }

    void FixedUpdate()
    {
        
        if (rigidbody.velocity.magnitude != 0 && clickedOn) 
        {
            hasRolled = true;
        } else if (hasRolled && rigidbody.velocity.magnitude < 0.5f)
        {
            clickedOn = false;
            int result = 0;
            foreach (DiceRaycast face in diceFaces)
            {
                result = face.CheckForColliders();
                if (result != 0)
                {
                    break; 
                }
            }
            hasRolled = false;
            canRoll = true;
            this.diceResult = result;
            //this.diceResult = values[counter];
            //counter++;
            diceResultUpdated = true;
            Debug.Log("RESULTADO = " + result);
            Debug.Log(diceResultUpdated);
            ChangeMaterial(gameObject, translucentMaterial);    
        }else if(hasRolled == false)
        {
            ChangeMaterial(gameObject, translucentMaterial);
        }
    }

    #region Physics: Force && Torque
    private void OnMouseDown()
    {
        if (canRoll)
        {
            int resultRandomForce = RandomForce();
            int resultRandomNumberofAxis = RandomNumberOfAxis();
            int x, y,z;
            x = RandomVector();
            y = RandomVector();
            z = RandomVector();

            rigidbody.AddForce(Vector3.up * resultRandomForce, ForceMode.Impulse);

            //Debug.Log("Numero random de chances: "+resultRandomNumberofAxis);
            if (resultRandomNumberofAxis >= 1 && resultRandomNumberofAxis <= 5) //0.4% chances  5
            {
                int resultValue = Random1Axis();
                if (resultValue == 1)
                {
                    vectorTorque = new Vector3(x, 0, 0);
                }
                else if (resultValue == 2)
                {
                    vectorTorque = new Vector3(0, y, 0);
                }
                else if (resultValue == 3)
                {
                    vectorTorque = new Vector3(0, 0, z);
                }
            }
            else if (resultRandomNumberofAxis >= 6 && resultRandomNumberofAxis <= 100) //0.6% chances 100
            {
                int resultValue = Random1Axis();
                if (resultValue == 1)
                {
                    vectorTorque = new Vector3(x, 0, z);
                }
                else if (resultValue == 2)
                {
                    vectorTorque = new Vector3(x, y, 0);
                }
                else if (resultValue == 3)
                {
                    vectorTorque = new Vector3(0, y, z);
                }
            }
            else if (resultRandomNumberofAxis >= 100 && resultRandomNumberofAxis <= 1000) //90% chances 1000
            {
                vectorTorque = new Vector3(x, y, z);
            }
   
            rigidbody.AddTorque(vectorTorque * resultRandomForce, ForceMode.Impulse);
            clickedOn = true;
        }
    }
    private void OnMouseOver()
    {
        ChangeMaterial(gameObject, opaqueMaterial);
    }
    private void OnMouseExit()
    {
        //ChangeMaterial(gameObject, translucentMaterial);       
    }
    #endregion

    public int getDiceResult()
    {
        if (diceResultUpdated)
        {
            diceResultUpdated = false;
            return this.diceResult;
        }
        else
        {
            return 0;
        }
    }

    #region Random Methods
    int Random1Axis()
    {
        int randomnumber;
        randomnumber = Random.Range(1, 4);
        return randomnumber;
    }
    int RandomNumberOfAxis()
    {
        int randomnumber;
        randomnumber = Random.Range(1, 1001);
        return randomnumber;
    }
    int RandomForce()
    {
        int randomnumber;
        randomnumber = Random.Range(150, 200);
        return randomnumber;
    }
    int RandomVector()
    {
        int randomnumber;
        randomnumber = Random.Range(-1, 2);
        return randomnumber;
    }
    #endregion

    #region Opacity
    void ChangeMaterial(GameObject obj, Material material)
    {
        
        Renderer renderer = obj.GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material = material;
        }
        else
        {
            Debug.LogWarning("The object does not have a Renderer component.");
        }
    }
    #endregion
}