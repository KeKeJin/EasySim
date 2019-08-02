//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: UIElement that responds to VR hands and generates UnityEvents
//
//=============================================================================

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	[RequireComponent( typeof( Interactable ) )]
	public class UIElement : MonoBehaviour
	{
		public CustomEvents.UnityEventHand onHandClick;
        public SteamVR_Action_Boolean m_Pinch = null;
        protected Hand currentHand;

		//-------------------------------------------------
		protected virtual void Awake()
		{
			Button button = GetComponent<Button>();
			if ( button )
			{
                button.onClick.AddListener( OnButtonClick );
			}
            
		}


		//-------------------------------------------------
		protected virtual void OnHandHoverBegin( Hand hand )
		{
            Debug.Log("hand hover begin");
			currentHand = hand;
			InputModule.instance.HoverBegin( gameObject );
			ControllerButtonHints.ShowButtonHint( hand, hand.uiInteractAction);
		}


        //-------------------------------------------------
        protected virtual void OnHandHoverEnd( Hand hand )
		{
            Debug.Log("hand hover end");
			InputModule.instance.HoverEnd( gameObject );
			ControllerButtonHints.HideButtonHint( hand, hand.uiInteractAction);
			currentHand = null;
		}


        //-------------------------------------------------
        protected virtual void HandHoverUpdate( Hand hand )
		{
            Debug.Log("hand hover update");
            if (m_Pinch.GetStateUp(SteamVR_Input_Sources.Any))
            {
                OnButtonClick();
            }
            if ( hand.uiInteractAction != null && hand.uiInteractAction.GetStateDown(hand.handType) )
			{
				InputModule.instance.Submit( gameObject );
                ControllerButtonHints.HideButtonHint(hand, hand.uiInteractAction);
			}
		}


        //-------------------------------------------------
        protected virtual void OnButtonClick()
		{
            Debug.Log("on button clicked");
			onHandClick.Invoke( currentHand );
           
		}
	}

#if UNITY_EDITOR
	//-------------------------------------------------------------------------
	[UnityEditor.CustomEditor( typeof( UIElement ) )]
	public class UIElementEditor : UnityEditor.Editor
	{
		//-------------------------------------------------
		// Custom Inspector GUI allows us to click from within the UI
		//-------------------------------------------------
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			UIElement uiElement = (UIElement)target;
			if ( GUILayout.Button( "Click" ) )
			{
                Debug.Log("clicked anyway");
				InputModule.instance.Submit( uiElement.gameObject );
			}
		}
	}
#endif
}
