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
            } else
            {
                Debug.Log("pox");
            }
            if (_button.magazinetype[i].CompareTag("spawn pet shop"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn fish"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn baker"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn jewelery"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }
            if (_button.magazinetype[i].CompareTag("SpawnTilet"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }
        }

        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
            Destroy(_button.magazinetype[i]);
        }
    }

    public void Petshop()
    {
        for (int i = 0; i < _button.magazinetype.Count; i++)
        {
            if (_button.magazinetype[i].CompareTag("spawn pet shop"))
            {
                Instantiate(pets,_button.magazinetype[i].transform.position,Quaternion.identity);
            } else
            {
                Debug.Log("pox");
            }
            if (_button.magazinetype[i].CompareTag("spawn sport"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }
            if (_button.magazinetype[i].CompareTag("spawn fish"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn baker"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn jewelery"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }
            if (_button.magazinetype[i].CompareTag("SpawnTilet"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }
        }
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
            Destroy(_button.magazinetype[i]);
        }
    }

    public void Fishshop()
    {
        for (int i = 0; i < _button.magazinetype.Count; i++)
        {
            if (_button.magazinetype[i].CompareTag("spawn fish"))
            {
                Instantiate(fish,_button.magazinetype[i].transform.position,Quaternion.identity);
            } else
            {
                Debug.Log("pox");
            }
            if (_button.magazinetype[i].CompareTag("spawn sport"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn pet shop"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn baker"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn jewelery"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }
            if (_button.magazinetype[i].CompareTag("SpawnTilet"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }
        }
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
            Destroy(_button.magazinetype[i]);
        }
    }

    public void Bakershop()
    {
        for (int i = 0; i < _button.magazinetype.Count; i++)
        {
            if (_button.magazinetype[i].CompareTag("spawn baker"))
            {
                Instantiate(baker,_button.magazinetype[i].transform.position,_button.magazinetype[i].transform.rotation);
            } else
            {
                Debug.Log("pox");
            }
            if (_button.magazinetype[i].CompareTag("spawn sport"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn pet shop"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn fish"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn jewelery"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }
            if (_button.magazinetype[i].CompareTag("SpawnTilet"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }
        }
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
            Destroy(_button.magazinetype[i]);
        }
    }

    public void Jeweleryshop()
    {
        for (int i = 0; i < _button.magazinetype.Count; i++)
        {
            if (_button.magazinetype[i].CompareTag("spawn jewelery"))
            {
                Instantiate(jewelery,_button.magazinetype[i].transform.position,_button.magazinetype[i].transform.rotation);
            } else
            {
                Debug.Log("pox");
            }
            if (_button.magazinetype[i].CompareTag("spawn sport"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn pet shop"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn fish"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn baker"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }
            
            if (_button.magazinetype[i].CompareTag("SpawnTilet"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }
        }
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
            Destroy(_button.magazinetype[i]);
        }
    }

    public void Pomoykashop()
    {
        for (int i = 0; i < _button.magazinetype.Count; i++)
        {
            if (_button.magazinetype[i].CompareTag("SpawnTilet"))
            {
                Instantiate(pomoyka,_button.magazinetype[i].transform.position,Quaternion.identity);
            } else
            {
                Debug.Log("pox");
            }
            if (_button.magazinetype[i].CompareTag("spawn sport"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn pet shop"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn fish"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn baker"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }

            if (_button.magazinetype[i].CompareTag("spawn jewelery"))
            {
                Destroy(_button.magazinetype[i]);
            } else
            {
                Debug.Log("pox");
            }
        } 
        for (int i = 0; i < _button.Visitmagazine.Length; i++)
        {
            _button.Visitmagazine[i].SetActive(false);
            Destroy(_button.magazinetype[i]);
        }
    }
}
