using System;
using UnityEngine;
using System.Collections.Generic;

public class ChangeMagaz : MonoBehaviour
{
    private ButtontoBY _button;
    public GameObject sport;
    public GameObject pets;
    public GameObject fish;
    public GameObject baker;
    public GameObject jewelery;
    public GameObject pomoyka;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            _button = other.gameObject.GetComponent<ButtontoBY>();
        }
    }


    public void Sportshop()
    {
        for (int i = 0; i < _button.magazinetype.Count; i++)
        {
            if (_button.magazinetype[i].CompareTag("spawn sport"))
            {
                Instantiate(sport,_button.magazinetype[i].transform.position,Quaternion.identity);
            }
            if (_button.magazinetype[i].CompareTag("sapwn pet shop"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn fish"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn baker"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn jewelery"))
            {
                Destroy(_button.magazinetype[i]);
            }
            if (_button.magazinetype[i].CompareTag("sapwn pomoyka"))
            {
                Destroy(_button.magazinetype[i]);
            }
        }

        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
        }
    }

    public void Petshop()
    {
        for (int i = 0; i < _button.magazinetype.Count; i++)
        {
            if (_button.magazinetype[i].CompareTag("sapwn pet shop"))
            {
                Instantiate(pets,_button.magazinetype[i].transform.position,Quaternion.identity);
            }
            if (_button.magazinetype[i].CompareTag("spawn sport"))
            {
                Destroy(_button.magazinetype[i]);
            }
            if (_button.magazinetype[i].CompareTag("sapwn fish"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn baker"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn jewelery"))
            {
                Destroy(_button.magazinetype[i]);
            }
            if (_button.magazinetype[i].CompareTag("sapwn pomoyka"))
            {
                Destroy(_button.magazinetype[i]);
            }
        }
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
        }
    }

    public void Fishshop()
    {
        for (int i = 0; i < _button.magazinetype.Count; i++)
        {
            if (_button.magazinetype[i].CompareTag("sapwn fish"))
            {
                Instantiate(fish,_button.magazinetype[i].transform.position,Quaternion.identity);
            }
            if (_button.magazinetype[i].CompareTag("spawn sport"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn pet shop"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn baker"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn jewelery"))
            {
                Destroy(_button.magazinetype[i]);
            }
            if (_button.magazinetype[i].CompareTag("sapwn pomoyka"))
            {
                Destroy(_button.magazinetype[i]);
            }
        }
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
        }
    }

    public void Bakershop()
    {
        for (int i = 0; i < _button.magazinetype.Count; i++)
        {
            if (_button.magazinetype[i].CompareTag("sapwn baker"))
            {
                Instantiate(baker,_button.magazinetype[i].transform.position,Quaternion.identity);
            }
            if (_button.magazinetype[i].CompareTag("spawn sport"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn pet shop"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn fish"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn jewelery"))
            {
                Destroy(_button.magazinetype[i]);
            }
            if (_button.magazinetype[i].CompareTag("sapwn pomoyka"))
            {
                Destroy(_button.magazinetype[i]);
            }
        }
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
        }
    }

    public void Jeweleryshop()
    {
        for (int i = 0; i < _button.magazinetype.Count; i++)
        {
            if (_button.magazinetype[i].CompareTag("sapwn jewelery"))
            {
                Instantiate(jewelery,_button.magazinetype[i].transform.position,Quaternion.identity);
            }
            if (_button.magazinetype[i].CompareTag("spawn sport"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn pet shop"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn fish"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn baker"))
            {
                Destroy(_button.magazinetype[i]);
            }
            
            if (_button.magazinetype[i].CompareTag("sapwn pomoyka"))
            {
                Destroy(_button.magazinetype[i]);
            }
        }
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
        }
    }

    public void Pomoykashop()
    {
        for (int i = 0; i < _button.magazinetype.Count; i++)
        {
            if (_button.magazinetype[i].CompareTag("sapwn pomoyka"))
            {
                Instantiate(pomoyka,_button.magazinetype[i].transform.position,Quaternion.identity);
            }
            if (_button.magazinetype[i].CompareTag("spawn sport"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn pet shop"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn fish"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn baker"))
            {
                Destroy(_button.magazinetype[i]);
            }

            if (_button.magazinetype[i].CompareTag("sapwn jewelery"))
            {
                Destroy(_button.magazinetype[i]);
            }
        } 
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
        }
    }
}
