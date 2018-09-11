using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puzzle : MonoBehaviour {

	public GameObject Camera;
	public GameObject Piece_easy;
	public GameObject Piece_nomal;
	public GameObject Piece_hard;
	public GameObject[] pieceEasy;
	public GameObject[] pieceNomal;
	public GameObject[] pieceHard;
	public GameObject PutPos_easy;
	public GameObject PutPos_nomal;
	public GameObject PutPos_hard;
	public GameObject[] putPosEasy;
	public GameObject[] putPosNomal;
	public GameObject[] putPosHard;
	public GameObject Panel_easy;
	public GameObject Panel_nomal;
	public GameObject Panel_hard;

	public Text timeLimitText;

	public int timeLimit = 300;

	int count;
	int difficulty;
	bool[] movePossble;

	Vector3 startPos;

	Camera cam;
	GameObject MovingPiece;
	Renderer MovingPieceRen;
	AudioSource[] audioSource;

	void Start () {
		StartCoroutine(countDown());
		cam = Camera.GetComponent<Camera>();
		audioSource = gameObject.GetComponents<AudioSource>();
		difficulty = Mathf.FloorToInt(GameMainCtrl.ceNum / 9);
		switch(difficulty){
			case 0:
				movePossble = new bool[20];
				for(int i = 0; i < movePossble.Length; i++){
					movePossble[i] = true;
				}
				Piece_easy.SetActive(true);
				PutPos_easy.SetActive(true);
				Panel_easy.SetActive(true);
				count = 20;
				break;
			case 1:
				movePossble = new bool[35];
				for(int i = 0; i < movePossble.Length; i++){
					movePossble[i] = true;
				}
				Piece_nomal.SetActive(true);
				PutPos_nomal.SetActive(true);
				Panel_nomal.SetActive(true);
				count = 35;
				break;
			default:
				movePossble = new bool[48];
				for(int i = 0; i < movePossble.Length; i++){
					movePossble[i] = true;
				}
				Piece_hard.SetActive(true);
				PutPos_hard.SetActive(true);
				Panel_hard.SetActive(true);
				count = 48;
				break;
		}
	}
	
	void FixedUpdate () {
		if(Input.touchCount != 1){return;}
		Touch t = Input.GetTouch(0);
		transform.position = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, -Camera.transform.position.z));
		if(t.phase == TouchPhase.Began){
			touchStart();
		}
		if(MovingPiece == null){return;}
		MovingPiece.transform.position = transform.position;
		if(t.phase == TouchPhase.Ended){
			touchEnd();
			MovingPiece = null;
			MovingPieceRen = null;
			if(count == 0){
				SceneManager.LoadScene("GameClear");
			}
		}

	}

	void touchStart(){
		switch(difficulty){
			case 0:
				for(int i = 0; i < pieceEasy.Length; i++){
					float dist = Vector3.Distance(pieceEasy[i].transform.position, transform.position);
					if(dist < 1.5f && movePossble[i]){
						audioSource[0].Play();
						MovingPiece = pieceEasy[i];
						startPos = MovingPiece.transform.position;
						MovingPieceRen = pieceEasy[i].GetComponent<Renderer>();
						MovingPieceRen.sortingOrder++;
					}
				}
				break;
			case 1:
				for(int i = 0; i < pieceNomal.Length; i++){
					float dist = Vector3.Distance(pieceNomal[i].transform.position, transform.position);
					if(dist < 1.2f && movePossble[i]){
						audioSource[0].Play();
						MovingPiece = pieceNomal[i];
						startPos = MovingPiece.transform.position;
						MovingPieceRen = pieceNomal[i].GetComponent<Renderer>();
						MovingPieceRen.sortingOrder++;
					}
				}
				break;
			default:
				for(int i = 0; i < pieceHard.Length; i++){
					float dist = Vector3.Distance(pieceHard[i].transform.position, transform.position);
					if(dist < 0.75f && movePossble[i]){
						audioSource[0].Play();
						MovingPiece = pieceHard[i];
						startPos = MovingPiece.transform.position;
						MovingPieceRen = pieceHard[i].GetComponent<Renderer>();
						MovingPieceRen.sortingOrder++;
					}
				}
				break;
		}
	}
	void touchEnd(){
		switch(difficulty){
			case 0:
				for(int i = 0; i < putPosEasy.Length; i++){
					float dist = Vector3.Distance(putPosEasy[i].transform.position, transform.position);
					if(MovingPiece.name.Substring(9) == putPosEasy[i].name.Substring(0) && dist < 1.5f){
						audioSource[1].Play();
						movePossble[i] = false;
						MovingPiece.transform.position = putPosEasy[i].transform.position;
						MovingPieceRen.sortingOrder--;
						count--;
						return;
					}
				}
				audioSource[2].Play();
				MovingPiece.transform.position = startPos;
				break;
			case 1:
				for(int i = 0; i < putPosNomal.Length; i++){
					float dist = Vector3.Distance(putPosNomal[i].transform.position, transform.position);
					if(MovingPiece.name.Substring(9) == putPosNomal[i].name.Substring(0) && dist < 1.2f){
						audioSource[1].Play();
						movePossble[i] = false;
						MovingPiece.transform.position = putPosNomal[i].transform.position;
						MovingPieceRen.sortingOrder--;
						count--;
						return;
					}
				}
				audioSource[2].Play();
				MovingPiece.transform.position = startPos;
				break;
			default:
				for(int i = 0; i < putPosHard.Length; i++){
					float dist = Vector3.Distance(putPosHard[i].transform.position, transform.position);
					if(MovingPiece.name.Substring(9) == putPosHard[i].name.Substring(0) && dist < 0.75f){
						audioSource[1].Play();
						movePossble[i] = false;
						MovingPiece.transform.position = putPosHard[i].transform.position;
						MovingPieceRen.sortingOrder--;
						count--;
						return;
					}
				}
				audioSource[2].Play();
				MovingPiece.transform.position = startPos;
				break;
		}
	}

	IEnumerator countDown(){
		while(timeLimit > 0){
			yield return new WaitForSeconds(1.0f);
			timeLimit--;
			timeLimitText.text = timeLimit.ToString();
		}
		SceneManager.LoadScene("GameOver");
	}
}
