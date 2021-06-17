using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    //列挙型の宣言
    public enum PlayerState
    {
        Idle,Walking,Running,Jumping
    }

    [RequireComponent(typeof(CharacterController), typeof(AudioSource))]

    public class PlayerController : MonoBehaviour
    {
        [Range(0.1f, 2f)]
        public float walkSpeed = 1.5f;
        [Range(0.1f, 10f)]
        public float runSpeed = 3.5f;

        private CharacterController charaController;

        private GameObject FPSCamera;
        private Vector3 moveDir = Vector3.zero;

        // Start is called before the first frame update
        void Start()
        {
            FPSCamera = GameObject.Find("FPSCamera");
            charaController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        private void Move()
        {
            float moveH = Input.GetAxis("Horizontal");
            float moveV = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveH, 0, moveV);

            if(movement.sqrMagnitude > 1)
            {
                //向きはそのまま長さが１になる
                movement.Normalize();
            }

            
            Vector3 desiredMove = FPSCamera.transform.forward * movement.z + FPSCamera.transform.right * movement.x;
            moveDir.x = desiredMove.x * 5f;
            moveDir.z = desiredMove.z * 5f;

            //Debug.Log("movement" + movement);
            //Debug.Log("movement.sqrMagnitude" + movement.sqrMagnitude);
            Debug.Log("desiredMove" + desiredMove);
            //Debug.Log("moveDir" + moveDir);

            if(Input.GetKey(KeyCode.LeftShift))
            {
                charaController.Move(moveDir * Time.fixedDeltaTime * runSpeed);
            }
            else
            {
                charaController.Move(moveDir * Time.fixedDeltaTime * walkSpeed);

            }
        }
    }
}
