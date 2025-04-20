using UnityEngine;
using System.Collections.Generic;

public class ChangeMagaz : MonoBehaviour
{
    private ButtontoBY _button = new ButtontoBY();
    private List<GameObject> sport = new List<GameObject>();
    private List<GameObject> pets = new List<GameObject>();
    private List<GameObject> fish = new List<GameObject>();
    private List<GameObject> baker = new List<GameObject>();
    private List<GameObject> jewelery = new List<GameObject>();
    private List<GameObject> pomoyka = new List<GameObject>();


    
    public void Sportshop()
    {
        for (int i = 0; i < _button.CubeorDecor.Count; i++)
        {
            if (_button.CubeorDecor[i].CompareTag("spawn sport"))
            {
                sport.Add(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn pet shop"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn fish"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn baker"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn jewelery"))
            {
                Destroy(_button.CubeorDecor[i]);
            }
            if (_button.CubeorDecor[i].CompareTag("sapwn pomoyka"))
            {
                Destroy(_button.CubeorDecor[i]);
            }
        }

        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
        }
    }

    public void Petshop()
    {
        for (int i = 0; i < _button.CubeorDecor.Count; i++)
        {
            if (_button.CubeorDecor[i].CompareTag("spawn sport"))
            {
                Destroy(_button.CubeorDecor[i]);
            }
            if (_button.CubeorDecor[i].CompareTag("sapwn fish"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn baker"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn jewelery"))
            {
                Destroy(_button.CubeorDecor[i]);
            }
            if (_button.CubeorDecor[i].CompareTag("sapwn pomoyka"))
            {
                Destroy(_button.CubeorDecor[i]);
            }
        }
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
        }
    }

    public void Fishshop()
    {
        for (int i = 0; i < _button.CubeorDecor.Count; i++)
        {
            if (_button.CubeorDecor[i].CompareTag("spawn sport"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn pet shop"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn baker"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn jewelery"))
            {
                Destroy(_button.CubeorDecor[i]);
            }
            if (_button.CubeorDecor[i].CompareTag("sapwn pomoyka"))
            {
                Destroy(_button.CubeorDecor[i]);
            }
        }
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
        }
    }

    public void Bakershop()
    {
        for (int i = 0; i < _button.CubeorDecor.Count; i++)
        {
            if (_button.CubeorDecor[i].CompareTag("spawn sport"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn pet shop"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn fish"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn jewelery"))
            {
                Destroy(_button.CubeorDecor[i]);
            }
            if (_button.CubeorDecor[i].CompareTag("sapwn pomoyka"))
            {
                Destroy(_button.CubeorDecor[i]);
            }
        }
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
        }
    }

    public void Jeweleryshop()
    {
        for (int i = 0; i < _button.CubeorDecor.Count; i++)
        {
            if (_button.CubeorDecor[i].CompareTag("spawn sport"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn pet shop"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn fish"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn baker"))
            {
                Destroy(_button.CubeorDecor[i]);
            }
            
            if (_button.CubeorDecor[i].CompareTag("sapwn pomoyka"))
            {
                Destroy(_button.CubeorDecor[i]);
            }
        }
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
        }
    }

    public void Pomoykashop()
    {
        for (int i = 0; i < _button.CubeorDecor.Count; i++)
        {
            if (_button.CubeorDecor[i].CompareTag("spawn sport"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn pet shop"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn fish"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn baker"))
            {
                Destroy(_button.CubeorDecor[i]);
            }

            if (_button.CubeorDecor[i].CompareTag("sapwn jewelery"))
            {
                Destroy(_button.CubeorDecor[i]);
            }
        } 
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
        }
    }
}
