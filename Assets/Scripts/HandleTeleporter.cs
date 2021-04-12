
using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
	public class HandleTeleporter : MonoBehaviour
	{
		private Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand;

		private Interactable interactable;

		private Animator anim;

		public GameObject player;
		public GameObject projectorRoomLocation;
		public string animationToPlay;

		private AudioSource audioSource;
		void Awake()
		{
			anim = GetComponent<Animator>();
			interactable = this.GetComponent<Interactable>();
			audioSource = this.GetComponent<AudioSource>();
		}


		private void OnHandHoverBegin(Hand hand)
		{

		}


		private void OnHandHoverEnd(Hand hand)
		{

		}



		private void HandHoverUpdate(Hand hand)
		{
			GrabTypes startingGrabType = hand.GetGrabStarting();
			bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

			if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
			{
				hand.HoverLock(interactable);
				hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
			}
			else if (isGrabEnding)
			{
				
				hand.DetachObject(gameObject);
				player.transform.position = projectorRoomLocation.transform.position;
				hand.HoverUnlock(interactable);
			}
		}

		private void OnAttachedToHand(Hand hand)
		{
			audioSource.Play();
			anim.SetBool("playAnim", true);
			anim.Play(animationToPlay);
			anim.SetBool("playAnim", false);
	
			
		}

		private void HandAttachedUpdate(Hand hand)
		{
			
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
