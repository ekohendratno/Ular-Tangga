using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    public static int whosTurn = 1;
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private bool coroutineAllowed = true;
	private int diceCount = 0;    

	// Use this for initialization
	private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
	}

    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
            GetComponent<AudioSource>().Play();
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
		
		diceCount = randomDiceSide + 1;
		
        GameControl.diceSideThrown = diceCount;
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);			
			
        } else if (whosTurn == -1)
        {
            GameControl.MovePlayer(2);
        }
        whosTurn *= -1;
		
			
        coroutineAllowed = true;
		
		//Debug.Log(whosTurn+":"+diceCount);
    }
}
