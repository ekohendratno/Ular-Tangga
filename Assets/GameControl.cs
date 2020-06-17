using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;

    private static GameObject player1, player2;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;
    public static int player1Waypoint = 0;
    public static int player2Waypoint = 0;

    public static bool gameOver = false;
    public static bool player1Turn = false;
    public static bool player2Turn = false;
	
	
    public static int posisiLebih = 0;

    void Awake(){
        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }
    // Use this for initialization
    void Start () {

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        whoWinsTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
        
		
    }

    // Update is called once per frame
    void Update()
    {
        

		cekPlayer1();
		cekPlayer2();
	
    }

    private static int poin1 = 0;
    private static int poin2 = 0;
    void cekPlayer1(){
        
        poin1 = player1.GetComponent<FollowThePath>().waypointIndex-1;
        poin2 = player2.GetComponent<FollowThePath>().waypointIndex-1;

        //jika player berada di titik 99 dan point mulai + dice == 99
        if (poin1 == 99 && (player1StartWaypoint + diceSideThrown) == 99  && player1Turn == true)
        {

            //hentikan player
            player1.GetComponent<FollowThePath>().moveAllowed = false;

            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";

            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            gameOver = true;

            Debug.Log("finish1");
            Debug.Log("p1:"+player1StartWaypoint+", p2:"+poin2);
        }
        
        //jika player berada di titik 99 dan point mulai + dice == 99
        if (poin1 == 99 && (player1StartWaypoint + diceSideThrown) > 99  && player1Turn == true)
        {
            //hentikan player
            player1.GetComponent<FollowThePath>().moveAllowed = false;

            int posisi = 99 - ((player1StartWaypoint + diceSideThrown) - 99);                             
                
            player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[posisi].transform.position;
            player1.GetComponent<FollowThePath>().waypointIndex = posisi;
            player1StartWaypoint = posisi;
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex-1;

            if(player1StartWaypoint == player2StartWaypoint)
            {
                player2.GetComponent<FollowThePath>().waypointIndex = 0;
                player2.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[0].transform.position;
                player2StartWaypoint = 0;
            }

            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);

            Debug.Log("mundur1");
            Debug.Log("p1:"+player1StartWaypoint+", p2:"+player2StartWaypoint);
        }

        //jika point posisi player lebih dari point mulai + dice dan posisi player != 99
        if ( poin1 == (player1StartWaypoint + diceSideThrown) 
        && (player1StartWaypoint + diceSideThrown) != 99 
        && player1Turn == true)
        {
            //hentikan player
            player1.GetComponent<FollowThePath>().moveAllowed = false;

            //update nilai point awal selanjutnya di kurangi 1
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex-1;
            //jika dadu == 6 player gulirkan dadu lagi
            if(diceSideThrown == 6){
                Dice.whosTurn = 1;
					
				player1MoveText.GetComponent<Text>().text = "Player 1 Lagi";
				player1MoveText.gameObject.SetActive(true);
				player2MoveText.gameObject.SetActive(false);
                
            //jika tidak ya gantian gulir dadu ke player lain
            }else{
				player2MoveText.GetComponent<Text>().text = "Giliran Player 2";
				player1MoveText.GetComponent<Text>().text = "Giliran Player 1";
                player1MoveText.gameObject.SetActive(false);
                player2MoveText.gameObject.SetActive(true);
            }

            
            if(player1StartWaypoint == poin2)
            {
                player2.GetComponent<FollowThePath>().waypointIndex = 0;
                player2.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[0].transform.position;
                player2StartWaypoint = 0;
            }
            
            //NAIK
            player1NaikTurun(player1StartWaypoint,3,13,1);
            player1NaikTurun(player1StartWaypoint,8,30,1);
            player1NaikTurun(player1StartWaypoint,20,41,1);
            player1NaikTurun(player1StartWaypoint,27,83,1);
            player1NaikTurun(player1StartWaypoint,35,43,1);
            player1NaikTurun(player1StartWaypoint,50,66,1);
            player1NaikTurun(player1StartWaypoint,70,90,1);
            player1NaikTurun(player1StartWaypoint,79,99,1);

            //TURUN
            player1NaikTurun(player1StartWaypoint,16,5,2);
            player1NaikTurun(player1StartWaypoint,46,25,2);
            player1NaikTurun(player1StartWaypoint,48,29,2);
            player1NaikTurun(player1StartWaypoint,55,52,2);
            player1NaikTurun(player1StartWaypoint,61,18,2);
            player1NaikTurun(player1StartWaypoint,62,60,2);
            player1NaikTurun(player1StartWaypoint,86,23,2);
            player1NaikTurun(player1StartWaypoint,92,72,2);
            player1NaikTurun(player1StartWaypoint,94,74,2);
            player1NaikTurun(player1StartWaypoint,97,77,2);

            //jika tidak ya mundur
            Debug.Log("p1:"+player1StartWaypoint+", p2:"+poin2);
        }
    }

    

    void cekPlayer2(){
        
        poin1 = player1.GetComponent<FollowThePath>().waypointIndex-1;
        poin2 = player2.GetComponent<FollowThePath>().waypointIndex-1;

        //jika player berada di titik 99 dan point mulai + dice == 99
        if (poin2 == 99 && (player2StartWaypoint + diceSideThrown) == 99  && player2Turn == true)
        {

            //hentikan player
            player2.GetComponent<FollowThePath>().moveAllowed = false;

            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";

            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            gameOver = true;

            Debug.Log("finish2");
            Debug.Log("p1:"+poin1+", p2:"+player2StartWaypoint);
        }
        
        //jika player berada di titik 99 dan point mulai + dice == 99
        if (poin2 == 99 && (player2StartWaypoint + diceSideThrown) > 99  && player2Turn == true)
        {

            //hentikan player
            player2.GetComponent<FollowThePath>().moveAllowed = false;

            int posisi = 99 - ((player2StartWaypoint + diceSideThrown) - 99);                             
                
            player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[posisi].transform.position;
            player2.GetComponent<FollowThePath>().waypointIndex = posisi;
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex-1;
            player2StartWaypoint = posisi;

            if(player1StartWaypoint == player2StartWaypoint)
            {
                player1.GetComponent<FollowThePath>().waypointIndex = 0;
				player1.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[0].transform.position;
				player1StartWaypoint = 0;

            }

            player1MoveText.gameObject.SetActive(true);
            player2MoveText.gameObject.SetActive(false);

            Debug.Log("mundur2");
            Debug.Log("p1:"+player1StartWaypoint+", p2:"+player2StartWaypoint);
        }

        //jika point posisi player lebih dari point_awal+dice dan posisi player != 99
        if ( poin2 == (player2StartWaypoint + diceSideThrown) 
        && (player2StartWaypoint + diceSideThrown) != 99 
        && player2Turn == true)
        {
            //hentikan player
            player2.GetComponent<FollowThePath>().moveAllowed = false;

            //update nilai point awal selanjutnya di kurangi 1
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex-1;
            //jika dadu == 6 player gulirkan dadu lagi
            if(diceSideThrown == 6){
				Dice.whosTurn *= -1;
					
				player2MoveText.GetComponent<Text>().text = "Player 2 Lagi";
				player2MoveText.gameObject.SetActive(true);
				player1MoveText.gameObject.SetActive(false);
                
            //jika tidak ya gantian gulir dadu ke player lain
            }else{
				player1MoveText.GetComponent<Text>().text = "Giliran Player 1";
				player2MoveText.GetComponent<Text>().text = "Giliran Player 2";
                player2MoveText.gameObject.SetActive(false);
                player1MoveText.gameObject.SetActive(true);
            }


            if(player2StartWaypoint == poin1)
            {
                player1.GetComponent<FollowThePath>().waypointIndex = 0;
				player1.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[0].transform.position;
				player1StartWaypoint = 0;
                //player1NaikTurun(player2StartWaypoint,poin1,0);

            }
            
            //NAIK
            player2NaikTurun(player2StartWaypoint,3,13,1);
            player2NaikTurun(player2StartWaypoint,8,30,1);
            player2NaikTurun(player2StartWaypoint,20,41,1);
            player2NaikTurun(player2StartWaypoint,27,83,1);
            player2NaikTurun(player2StartWaypoint,35,43,1);
            player2NaikTurun(player2StartWaypoint,50,66,1);
            player2NaikTurun(player2StartWaypoint,70,90,1);
            player2NaikTurun(player2StartWaypoint,79,99,1);

            //TURUN
            player2NaikTurun(player2StartWaypoint,16,5,2);
            player2NaikTurun(player2StartWaypoint,46,25,2);
            player2NaikTurun(player2StartWaypoint,48,29,2);
            player2NaikTurun(player2StartWaypoint,55,52,2);
            player2NaikTurun(player2StartWaypoint,61,18,2);
            player2NaikTurun(player2StartWaypoint,62,60,2);
            player2NaikTurun(player2StartWaypoint,86,23,2);
            player2NaikTurun(player2StartWaypoint,92,72,2);
            player2NaikTurun(player2StartWaypoint,94,74,2);
            player2NaikTurun(player2StartWaypoint,97,77,2);

            //jika tidak ya mundur
            Debug.Log("p1:"+poin1+", p2:"+player2StartWaypoint);
        }

    }

    void player1NaikTurun(int start_dice, int tangga_naik, int poin, int naik)
    {
        if(start_dice == tangga_naik){
            //hentikan player
            player1.GetComponent<FollowThePath>().moveAllowed = false;

            player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[poin].transform.position;
            player1.GetComponent<FollowThePath>().waypointIndex = poin;
            player1.GetComponent<FollowThePath>().waypointIndex +=1;
            player1StartWaypoint = poin;

            if(player1StartWaypoint == poin2)
            {
                player2.GetComponent<FollowThePath>().waypointIndex = 0;
                player2.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[0].transform.position;
                player2StartWaypoint = 0;
            }

            //AudioManager.playSound("trap");
            
        }
    }

    void player2NaikTurun(int start_dice, int tangga_naik, int poin, int naik)
    {
        if(start_dice == tangga_naik){
            //hentikan player
            player2.GetComponent<FollowThePath>().moveAllowed = false;

            player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[poin].transform.position;
            player2.GetComponent<FollowThePath>().waypointIndex = poin;
            player2.GetComponent<FollowThePath>().waypointIndex +=1;
            player2StartWaypoint = poin;

            if(player2StartWaypoint == poin1)
            {
                player1.GetComponent<FollowThePath>().waypointIndex = 0;
				player1.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[0].transform.position;
				player1StartWaypoint = 0;
                //player1NaikTurun(player2StartWaypoint,poin1,0);

            }

            //AudioManager.playSound("trap");
        }

    }


    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { 
            case 1:
			
				player1Turn = true;
				player2Turn = false;
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 2:
			
				player1Turn = false;
				player2Turn = true;
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }
}
