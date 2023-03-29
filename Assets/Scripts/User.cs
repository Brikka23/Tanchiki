using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class User : MonoBehaviour
{
    [SerializeField] private GameObject _tank1;
    [SerializeField] private GameObject _tank2;
    [SerializeField] private GameObject _grid;
    [SerializeField] private GameObject _gameUi;
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _endGameMenu;
    [SerializeField] private TextMeshProUGUI _nameWinner;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Transform _posCreatBullet;
    [SerializeField] private PlayMode2 _playMode;

    [SerializeField] private Color _teamColor;

    public Image hpBar;
    public float speed;
    public float rotationSpeed;
    public int hp;
    public int damage;
    public int sheld;
    public float reload;
    public Text scoreRed;
    public Text scoreBlue;
    public uint score1 = 0;
    public uint score2 = 0;

    public KeyCode up;
    public KeyCode down;
    public KeyCode right;
    public KeyCode left;
    public KeyCode shoot;

    private void Start()
    {
        Quaternion rotation = Quaternion.Euler(0, 30, 0);
        hpBar.color = _teamColor;
    }

    private void Update()
    {
        Move();
        Shoot();
        EndGame();
    }

    private void EndGame()
    {
        if (score1 >= 5 || score2 >= 5)
        {
            if(score1 > score2)
                _nameWinner.text = "<color=#0007F5>Игрок 1</color> одеражал победу!\r\nУра Ура Урааа!";
            else
                _nameWinner.text = "<color=#FF000A>Игрок 2</color> одеражал победу!\r\nУра Ура Урааа!";

            _endGameMenu.SetActive(true);
            score1 = 0;
            score2 = 0;
            scoreRed.text = "";
            scoreBlue.text = "";
            _tank1.SetActive(false);
            _tank2.SetActive(false);
            _grid.SetActive(false);
            _gameUi.SetActive(false);
            _endGameMenu.SetActive(true);
        }
    }

    private void Move()
    {
        if (Input.GetKey(up))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(down))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(left))
        {
            transform.rotation *= Quaternion.Euler(0, 0, 1 * rotationSpeed);
        }
        if (Input.GetKey(right))
        {
            transform.rotation *= Quaternion.Euler(0, 0, -1 * rotationSpeed);
        }
    }

    public void TakeDamage(int damage)
    {
        if (sheld > damage)
        {
            sheld -= damage;
            return;
        }
        else
        {
            damage -= sheld;
            sheld = 0;
            hp -= damage;

            hpBar.fillAmount = hp * 0.01f;
            if (hp <= 0f)
            {
                gameObject.SetActive(false);
                if (gameObject.tag == "Player")
                {
                    score1++;
                    scoreBlue.text = score1.ToString();
                }
                else
                {
                    score2++;
                    scoreRed.text = score2.ToString();
                }
                _playMode.StartGameMode2();
            }
        }
    }

    public void Restart(){
        hp = 100;
        sheld = 25;
        hpBar.fillAmount = 100;
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(shoot))
        {           
            Quaternion rotationBullet = transform.rotation;
            GameObject clone = Instantiate(_bulletPrefab, _posCreatBullet.position, transform.rotation * Quaternion.Euler(0, 0, -180));
            clone.AddComponent<Bullet>();
            clone.GetComponent<Bullet>().speed = _bulletSpeed;
            clone.GetComponent<Bullet>().damage = damage;
            clone.GetComponent<Bullet>().parent = gameObject;
            clone.GetComponent<SpriteRenderer>().color = _teamColor;
        }
    }
}
