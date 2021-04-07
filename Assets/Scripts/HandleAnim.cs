
using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
	public class HandleAnim : MonoBehaviour
	{

		private Vector3 oldPosition;
		private Quaternion oldRotation;

		private Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand;

		private Interactable interactable;

		private Animator anim;
		void Awake()
		{
			var textMeshs = GetComponentsInChildren<TextMesh>();
			anim = GetComponent<Animator>();

			interactable = this.GetComponent<Interactable>();
		}


		private void OnHandHoverBegin(Hand hand)
		{

		}


		private void OnHandHoverEnd(Hand hand)
		{

		}


		//-------------------------------------------------
		// Called every Update() while a Hand is hovering over this object
		//-------------------------------------------------
		private void HandHoverUpdate(Hand hand)
		{
			GrabTypes startingGrabType = hand.GetGrabStarting();
			bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

			if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
			{
				// Save our position/rotation so that we can restore it when we detach
				oldPosition = transform.position;
				oldRotation = transform.rotation;

				// Call this to continue receiving HandHoverUpdate messages,
				// and prevent the hand from hovering over anything else
				hand.HoverLock(interactable);
				// Attach this object to the hand
				hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
			}
			else if (isGrabEnding)
			{
				// Detach this object from the hand
				hand.DetachObject(gameObject);

				// Call this to undo HoverLock
				hand.HoverUnlock(interactable);

				// Restore position/rotation
				transform.position = oldPosition;
				transform.rotation = oldRotation;
			}
		}

		private void OnAttachedToHand(Hand hand)
		{
			transform.position = oldPosition;
			transform.rotation = oldRotation;
			anim.SetBool("playAnim", true);
			anim.Play("ProjectdoorAnim");
			anim.SetBool("playAnim", false);
		}

		private void HandAttachedUpdate(Hand hand)
		{
			transform.position = oldPosition;
			transform.rotation = oldRotation;
		}

		private bool lastHovering = false;
		private void Update()
		{
			if (interactable.isHovering != lastHovering) //save on the .tostrings a bit
			{

				lastHovering = interactable.isHovering;
			}
		}

	}
}
