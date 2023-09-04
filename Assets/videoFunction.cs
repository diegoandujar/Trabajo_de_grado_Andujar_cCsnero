using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoFunction : MonoBehaviour
{

    public VideoPlayer video;
    private PlayerMovement player;
    [SerializeField] public GameObject cross;
    private Weapon weapon;
    private bool weaponState;

    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        weapon = GameObject.Find("Player").GetComponent<Weapon>();
    }

    private void Start()
    {
        gameObject.SetActive(false);
        cross.SetActive(false);
    }

    public void playVideo()
    {
        Time.timeScale = 0f;
        weaponState = weapon.canShoot;
        player.mover = false;
        weapon.canShoot = false;
        gameObject.SetActive(true);
        cross.SetActive(true);
        video.Play();
        video.loopPointReached += stopVideo;
    }
    
    public void stopVideo(VideoPlayer vp)
    {
        Time.timeScale = 1f;
        cross.SetActive(false);
        gameObject.SetActive(false);
        player.mover = true;
        weapon.canShoot = weaponState;
    }

}
