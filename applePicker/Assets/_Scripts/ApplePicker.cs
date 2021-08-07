using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    //velocidad de movimiento cada cuadro
    //cambio de direccion al llegar al borde de la escena
    //cambios de direccion de manera aleatoria
    //soltar una manzana cada cierto tiempo

    [Header("Set in Inspector")]
    
    public GameObject   applePrefab;   //prefab for instantiating apples
    public float        speed = 1f;
    public float        leftAndRightEdge = 10f;
    public float        chanceToChangeDirections = 0.1f;
    public float        secondsBetweenAppleDrops = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //initialization and start dropping apples
        Invoke("DropApple", 2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        //basic movement logic
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //change direction logic
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }

    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }

    void DropApple ()
    {
        GameObject apple = Instantiate <GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
}
