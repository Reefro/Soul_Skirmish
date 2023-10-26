using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace MasayaScripts.InputSystem
{
    public class MultiplayerUIInputs : MonoBehaviour
    {
        public int playerIndex;
        MultiplayerEventSystem multiplayerEventSystem;
        bool playerJoined;

        private void Awake()
        {
            multiplayerEventSystem = GetComponent<MultiplayerEventSystem>();
        }

        private void Start()
        {
            PlayerJoined();
        }

        public void PlayerJoined()
        {
            playerJoined = true;
            ControlMaster controls = InputManager.current.players[playerIndex].controlMaster;
            controls.BaseControls.South.performed += SouthButton_performed;
            controls.BaseControls.East.performed += EastButton_performed;
            controls.BaseControls.Up.performed += Up_performed;
            controls.BaseControls.Down.performed += Down_performed;
            controls.BaseControls.Right.performed += Right_performed;
            controls.BaseControls.Left.performed += Left_performed;
        }

        private void OnDisable()
        {
            playerJoined = false;
            ControlMaster controls = InputManager.current.players[playerIndex].controlMaster;
            controls.BaseControls.South.performed -= SouthButton_performed;
            controls.BaseControls.East.performed -= EastButton_performed;
            controls.BaseControls.Up.performed -= Up_performed;
            controls.BaseControls.Down.performed -= Down_performed;
            controls.BaseControls.Right.performed -= Right_performed;
            controls.BaseControls.Left.performed -= Left_performed;
        }

        void MoveUI(MoveDirection moveDirection)
        {

            AxisEventData data = new AxisEventData(multiplayerEventSystem);
            data.moveDir = moveDirection;
            data.selectedObject = multiplayerEventSystem.currentSelectedGameObject;
            ExecuteEvents.Execute(data.selectedObject, data, ExecuteEvents.moveHandler);
        }
        void SelectUI()
        {
            ExecuteEvents.Execute(multiplayerEventSystem.currentSelectedGameObject, null, ExecuteEvents.submitHandler);
        }
        void CancelUI()
        {
            ExecuteEvents.Execute(multiplayerEventSystem.currentSelectedGameObject, null, ExecuteEvents.cancelHandler);
        }
        private void SouthButton_performed(InputAction.CallbackContext obj)
        {
            SelectUI();
        }
        private void EastButton_performed(InputAction.CallbackContext obj)
        {
            CancelUI();
        }
        private void Up_performed(InputAction.CallbackContext obj)
        {
            MoveUI(MoveDirection.Up);
        }
        private void Down_performed(InputAction.CallbackContext obj)
        {
            MoveUI(MoveDirection.Down);
        }
        private void Right_performed(InputAction.CallbackContext obj)
        {
            MoveUI(MoveDirection.Right);
        }
        private void Left_performed(InputAction.CallbackContext obj)
        {
            MoveUI(MoveDirection.Left);
        }
    }
}