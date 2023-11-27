using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput UserInput;

    public Vector2 Movement { get; private set; }
    public Vector2 Look { get; private set; }

    public bool Shoot { get; private set; }
    public bool Aim { get; private set; }
    public bool Pause { get; private set; }
    public bool Jump { get; private set; }
    public bool Run { get; private set; }
    public bool Reload { get; private set; }

    private InputActionMap _currentMap;

    private InputAction _MoveAct;
    private InputAction _LookAct;
    private InputAction _ShootAct;
    private InputAction _AimAct;
    private InputAction _PauseAct;
    private InputAction _JumpAct;
    private InputAction _RunAct;
    private InputAction _ReloadAct;

    private void Awake()
    {
        UserInput = GetComponent<PlayerInput>();
        _currentMap = UserInput.currentActionMap;

        _MoveAct = _currentMap.FindAction("Move");
        _LookAct = _currentMap.FindAction("Look");
        _ShootAct = _currentMap.FindAction("Shoot");
        _AimAct = _currentMap.FindAction("Aim");
        _PauseAct = _currentMap.FindAction("Pause");
        _JumpAct = _currentMap.FindAction("Jump");
        _RunAct = _currentMap.FindAction("Run");
        _ReloadAct = _currentMap.FindAction("Reload");

        _MoveAct.performed += OnMove;
        _LookAct.performed += OnLook;
        _ShootAct.performed += OnShoot;
        _AimAct.performed += OnAim;
        _PauseAct.performed += OnPause;
        _JumpAct.performed += OnJump;
        _RunAct.performed += OnRun;
        _ReloadAct.performed += OnReload;


        _MoveAct.canceled += OnMove;
        _LookAct.canceled += OnLook;
        _ShootAct.canceled += OnShoot;
        _AimAct.canceled += OnAim;
        _PauseAct.canceled += OnPause;
        _JumpAct.canceled += OnJump;
        _RunAct.canceled += OnRun;
        _ReloadAct.canceled += OnReload;

    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }
    private void OnLook(InputAction.CallbackContext context)
    {
        Look = context.ReadValue<Vector2>();
    }
    private void OnShoot(InputAction.CallbackContext context)
    {
        Shoot = context.ReadValueAsButton();
    }
    private void OnAim(InputAction.CallbackContext context)
    {
        Aim = context.ReadValueAsButton();
    }
   
    private void OnPause(InputAction.CallbackContext context)
    {
        Pause = context.ReadValueAsButton();
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        Jump = context.ReadValueAsButton();
    }
    private void OnRun(InputAction.CallbackContext context)
    {
        Run = context.ReadValueAsButton();
    }
    private void OnReload(InputAction.CallbackContext context)
    {
        Reload = context.ReadValueAsButton();
    }

    private void OnEnable()
    {
        _currentMap.Enable();
    }

    private void OnDisable()
    {
        _currentMap.Disable();
    }

}
