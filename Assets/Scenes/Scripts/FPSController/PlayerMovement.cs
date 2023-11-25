using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _Gravity;
    [SerializeField] private float speedRun;

    [SerializeField] private Slider staminaSlider;
    [SerializeField] private float staminaValue; 
    [SerializeField] private float minStaminaValue; 
    [SerializeField] private float maxStaminaValue;
    private Text textStamina;
    
    private CharacterController _characterController;
    private Vector3 _walkDirection;
    private Vector3 _velocity; 
    private float Speed;
    
    
    
    
    
    
    
    
    private void Start()
    {
        Speed = _speedWalk;
        _characterController = GetComponent<CharacterController>();
        textStamina = staminaSlider.transform.GetChild(3).GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        Sit(Input.GetKey(KeyCode.LeftControl));
        Run(Input.GetKey(KeyCode.LeftShift));
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
       _walkDirection = transform.right * X + transform.forward * Z;
        StaminaValueMove();
    }
    private void FixedUpdate()
    {
        Walk(_walkDirection);
        OnGravity(_characterController.isGrounded);
    }

    private void Walk(Vector3 direction)
    {
        _characterController.Move(direction * _speedWalk * Time.fixedDeltaTime);
    }
    private void OnGravity(bool isGrounded)
    {
        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = 1f;
        }
        _velocity.y -= _Gravity * Time.fixedDeltaTime;
        _characterController.Move(_velocity * Time.fixedDeltaTime);
    }

    private void Run(bool CanRun)
    {
        _speedWalk = CanRun ? speedRun : Speed;
    }
    private void Sit(bool CanSit)
    {
        _characterController.height = CanSit ? 1f : 2f;
    }

    private void StaminaValueMove()
    {
        if (maxStaminaValue > 100f) maxStaminaValue = 100f;
        staminaValue = staminaSlider.value;
        textStamina.text = staminaValue.ToString();
    }
     

            





}
