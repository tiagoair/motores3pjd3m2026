using System;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;


		[SerializeField] private PlayerInput _playerInput;
		
		
		private void OnEnable()
		{
			_playerInput.actions.FindAction("Move").performed += context => move = context.ReadValue<Vector2>();
			_playerInput.actions.FindAction("Move").canceled += context => move = Vector2.zero;
			
			_playerInput.actions.FindAction("Look").performed += context => look = context.ReadValue<Vector2>();
			_playerInput.actions.FindAction("Look").canceled += context => look = Vector2.zero;
			
			_playerInput.actions.FindAction("Jump").performed += context => jump = true;
			
			_playerInput.actions.FindAction("Sprint").performed += context => sprint = true;
			_playerInput.actions.FindAction("Sprint").canceled += context => sprint = false;
			
			_playerInput.actions.FindAction("Interact").performed += context => InteractOM.Interact();
		}


#if ENABLE_INPUT_SYSTEM
		

		
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
		
		public void OnInteract(InputValue value)
		{
			if(value.isPressed) InteractOM.Interact();
		}
#endif

			private void Awake()
	{
		SetCursorState(cursorLocked);
		Cursor.visible = false;

		
	}

		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
			Cursor.visible = !newState;  
			

		}
	}
	
}