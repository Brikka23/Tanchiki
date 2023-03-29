using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMode2 : MonoBehaviour
{
    [SerializeField] private GameObject[] _maps;
    [SerializeField] private GameObject _tank1;
    [SerializeField] private GameObject _tank2;
    [SerializeField] private GameObject _hpbar1;
    [SerializeField] private GameObject _hpbar2;
    [SerializeField] private GameObject _grid;
    [SerializeField] private User _user1;
    [SerializeField] private User _user2;


    public void StartGameMode2()
    {
        int rand = Random.Range(0,_maps.Length);
        _grid.SetActive(true);
        _tank1.SetActive(true);
        _tank2.SetActive(true);
        _hpbar1.SetActive(true);
        _hpbar2.SetActive(true);
        _user1.Restart();
        _user2.Restart();

        switch (rand.ToString())
        {
            case "0":
                _maps[1].SetActive(false);
                _maps[2].SetActive(false);
                _maps[3].SetActive(false);
                _maps[4].SetActive(false);
                _maps[0].SetActive(true);
                _tank1.transform.position = new Vector2(13f, -10f);
                _tank1.transform.Rotate(0f, 0f, 180f);
                _tank2.transform.position = new Vector2(-17.91f, 8.43f);
                _tank2.transform.Rotate(0f, 0f, 90f);
                break;

            case "1":
                _maps[0].SetActive(false);
                _maps[2].SetActive(false);
                _maps[3].SetActive(false);
                _maps[4].SetActive(false);
                _maps[1].SetActive(true);
                _tank1.transform.position = new Vector2(18f, 2f);
                _tank1.transform.Rotate(0f, 0f, -90f);
                _tank2.transform.position = new Vector2(-18f, 2f);
                _tank2.transform.Rotate(0f, 0f, 90f);
                break;

            case "2":
                _maps[1].SetActive(false);
                _maps[0].SetActive(false);
                _maps[3].SetActive(false);
                _maps[4].SetActive(false);
                _maps[2].SetActive(true);
                _tank1.transform.position = new Vector2(18.58f, 8.43f);
                _tank1.transform.Rotate(0f, 0f, 0f);
                _tank2.transform.position = new Vector2(-18.48f, 8.43f);
                _tank2.transform.Rotate(0f, 0f, 0f);
                break;

            case "3":
                _maps[1].SetActive(false);
                _maps[2].SetActive(false);
                _maps[0].SetActive(false);
                _maps[4].SetActive(false);
                _maps[3].SetActive(true);
                _tank1.transform.position = new Vector2(0f, -8f);
                _tank1.transform.Rotate(0f, 0f, 180f);
                _tank2.transform.position = new Vector2(0f, 8f);
                _tank2.transform.Rotate(0f, 0f, 0f);
                break;

            case "4":
                _maps[1].SetActive(false);
                _maps[2].SetActive(false);
                _maps[3].SetActive(false);
                _maps[0].SetActive(false);
                _maps[4].SetActive(true);
                _tank1.transform.position = new Vector2(10.6f, 4.26f);
                _tank1.transform.Rotate(0f, 0f, 0f);
                _tank2.transform.position = new Vector2(-0.5f, 8f);
                _tank2.transform.Rotate(0f, 0f, -90f);
                break;
        }
    }
}
