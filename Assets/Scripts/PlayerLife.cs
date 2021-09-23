using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Animator anim;

    [SerializeField] private AudioSource dethSound;
    
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();   
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            
            Die();
        }
    }

    private void Die() 
    {
        dethSound.Play();
        rbody.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("deth");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
