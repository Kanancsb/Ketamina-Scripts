using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBreakerBox : MonoBehaviour
{
        public Animator bk01;
        public Animator bk02;
        public Animator padlock;

		public Transform Player;

		public GameObject rkey;
		public GameObject Hand;
		public GameObject padlockOB;
		
		public AudioSource doorSound;

		void OnMouseOver()
		{
			{
				if (Player)
				{
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < 3 && rkey.activeInHierarchy == true)
					{
						Hand.SetActive(true);
						if (Input.GetButtonDown("Action"))
						{
							StartCoroutine(opening());
							doorSound.Play();
							Hand.SetActive(false);  
							rkey.SetActive(false);
						}

					}
				}

			}

		}

		IEnumerator opening(){
			padlock.Play("padlockunlock");
			yield return new WaitForSeconds(1);
			Destroy(padlockOB);
            bk01.Play("breakerbox01");
            yield return new WaitForSeconds(1);
            bk02.Play("breakerbox02");

		}

		void OnMouseExit(){
        Hand.SetActive(false);        
    	}
}
