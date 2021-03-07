using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    enum BuffType{ MobSpeedDebuff, ShootingSpeed, MovementSpeed}

    [SerializeField]
    BuffType type;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            switch (type) {
                case BuffType.MobSpeedDebuff: 
                    {
                        Pisara.speedDebuff = true;
                        break;
                    }
                case BuffType.MovementSpeed: 
                    {
                        collision.gameObject.GetComponent<Liike>().ActivateMovementSpeed();
                        break; 
                    }
                case BuffType.ShootingSpeed:
                    {
                        collision.gameObject.GetComponent<Liike>().ActivateShootingSpeed();
                        break;
                    }
            }
            Destroy(gameObject);
        }
    }

}
