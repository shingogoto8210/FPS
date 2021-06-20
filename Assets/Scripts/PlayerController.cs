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

        [Range(0.1f, 10f)]
        public float gravity = 9.8f;
        [Range(1f, 15f)]
        public float jumpPower = 10f;

        [Range(0.1f, 2f)]
        public float crouchHeight = 1f;
        [Range(0.1f, 5f)]
        public float normalHeight = 2f;

        [HideInInspector]
        public PlayerState currentPlayerState;
        [HideInInspector]
        public bool isWalking = false;
        [HideInInspector]
        public bool isRunning = false;
        [HideInInspector]
        public bool isCrouching = false;

        public AudioClip walkSound;
        public AudioClip runSound;
        private AudioSource footStepSource;
        [HideInInspector]
        public float footSoundDelay;

        void Start()
        {
            FPSCamera = GameObject.Find("FPSCamera");
            charaController = GetComponent<CharacterController>();
            footStepSource = GetComponent<AudioSource>();
            StartCoroutine(PlayerFootSound());//コルーチンの起動
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            Crouch();
            PlayerStateManager();
            print(currentPlayerState);
            Debug.Log(charaController.velocity.sqrMagnitude);
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
            //Debug.Log(FPSCamera.transform.forward);
            //Debug.Log("movement" + movement);
            //Debug.Log("movement.sqrMagnitude" + movement.sqrMagnitude);
            //Debug.Log("desiredMove" + desiredMove);
            //Debug.Log("moveDir" + moveDir);

            if(Input.GetKey(KeyCode.LeftShift))
            {
                charaController.Move(moveDir * Time.fixedDeltaTime * runSpeed);
                isWalking = false;
                isRunning = true;
            }
            else
            {
                charaController.Move(moveDir * Time.fixedDeltaTime * walkSpeed);
                isWalking = true;
                isRunning = false;

            }

            moveDir.y -= gravity * Time.deltaTime;//重力の発生

            if(charaController.isGrounded)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    moveDir.y = jumpPower;//ジャンプ
                }
            }
        }

        void Crouch()
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                charaController.height = crouchHeight;
                isCrouching = true;
            }
            else
            {
                charaController.height = normalHeight;
                isCrouching = false;
            }
        }

        void PlayerStateManager()
        {
            if (charaController.isGrounded)
            {
                if (charaController.velocity.sqrMagnitude < 0.01f)
                {
                    currentPlayerState = PlayerState.Idle;
                }
                else if (isWalking == true && isRunning == false)
                {
                    currentPlayerState = PlayerState.Walking;
                }
                else if (charaController.velocity.sqrMagnitude > 0.01f && isWalking == false && isRunning == true)
                {
                    currentPlayerState = PlayerState.Running;
                }
            }
            else
            {
                currentPlayerState = PlayerState.Jumping;
            }
        }

        //移動時の足音
        public IEnumerator PlayerFootSound()
        {
            while (true)
            {
                if (currentPlayerState != PlayerState.Idle)
                {
                    if (currentPlayerState == PlayerState.Walking)
                    {
                        footStepSource.PlayOneShot(walkSound, 0.9f);
                        footStepSource.pitch = Random.Range(1f, 1.2f);
                        footSoundDelay = 1 / walkSpeed;
                    }
                    if (currentPlayerState == PlayerState.Running)
                    {
                        footStepSource.PlayOneShot(runSound, 0.9f);
                        footStepSource.pitch = Random.Range(1f, 1.2f);
                        footSoundDelay = 1 / runSpeed;
                    }
                }
                yield return new WaitForSeconds(footSoundDelay * 2);
                footStepSource.Stop();
            }
        }
    }
}
