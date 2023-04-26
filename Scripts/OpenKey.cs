using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKey : MonoBehaviour
{

		public Animator openandclose;

		public bool open;

		public Transform Player;

		public GameObject rkey;
		public GameObject Hand;
		
		public AudioSource doorSound;
		public AudioSource closedDoor;

		void Start()
		{
			open = false;
		}

		void OnMouseOver()
		{
			{
				if (Player)
				{
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < 3 && rkey.activeInHierarchy == true)
					{
						Hand.SetActive(true);
						if (open == false)
						{
							if (Input.GetButtonDown("Action"))
							{
								StartCoroutine(opening());
								doorSound.Play();
								Hand.SetActive(false);  
							}
						}
						else
						{
							if (open == true)
							{
								if (Input.GetButtonDown("Action"))
								{
									StartCoroutine(closing());
									doorSound.Play();
									Hand.SetActive(false);  
								}
							}

						}

					}else{
						closedDoor.Play();
					}
				}

			}

		}

		IEnumerator opening()
		{
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}

		void OnMouseExit(){
        Hand.SetActive(false);        
    	}

}
