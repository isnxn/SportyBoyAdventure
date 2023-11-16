using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject WinPanel;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            WinPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("dead");
    }

    private void RLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
