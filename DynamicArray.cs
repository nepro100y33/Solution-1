using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution__1_List_
{
    class DynamicArray<T> where T : new()
    {
        T[] array;
        
        private void IncreaseCapacity() //увеличение емкости
        {
            T[] cap = array;
            array = new T[array.Length*2];

            for (int i = 0; i < cap.Length; i++)
            {
                array[i] = cap[i];
            }
        }
        //Свойство Length–получение длины заполненной части массива
        public int Length
        {           
            get
            {
                int length = 0;

                for (int i = 0; i < Capacity; i++)
                {
                    if (!array[Capacity - i - 1].Equals(default(T)))
                    {
                        length = Capacity - i;
                        break;
                    }
                }
                return length;//возвращаем длину заполненной части
            }
        }


        //Свойство Capacity–получение реальной ёмкости массива
        public int Capacity
        {
            get
            {
                return array.Length;
            }
        }
        //Конструктор без параметров
        public DynamicArray()
        {
            array = new T[8];
        }
        //Конструктор с 1 целочисленным параметром
        public DynamicArray(int size)
        {
            array = new T[size];
        }
        //Конструктор, который в качестве параметра принимает массив
        public DynamicArray(T[] arr)
        {
            array = new T[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                array[i] = arr[i];
            }
        }
        //Метод Add, добавляющий в конец массива один элемент
        public void Add(T elem)
        {
            if (Length != Capacity)//если емкость позволяет, добавляем элемент
            {
                array[Length] = elem;
            }
            else
            {
                IncreaseCapacity();//если нет, увеличиваем емкость
                array[Length] = elem;
            }
        }
        //МетодAddRange, добавляющий в конец массива содержимое переданного массива
        public void AddRange(T[] arr)
        {
            if (Capacity - Length > arr.Length)//если емкость позволяет, добавляем массив
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    array[Length] = arr[i];
                }
            }
            else
            {
                IncreaseCapacity();//если нет, увеличиваем на емкость добавляемого массива

                for (int i = 0; i < arr.Length; i++)
                {
                    array[Length] = arr[i];
                }
            }

        }
        //Метод Remove, удаляющий из коллекции указанный элемент
        public bool Remove(T elem)
        {
            bool remove = false;
            for (int i = 0; i < Capacity; i++)
            {
                if (array[i].Equals(elem))//проверка на существование элемента
                {
                    for (int j = 0; j < Length - i - 1; j++)
                    {
                        array[i + j] = array[i + j + 1];
                    }

                    array[Length - 1] = default(T);//замена удаленного элемента на дефолтное
                    remove = true;
                }
                else
                {
                    remove = false;
                }
            }
            return remove;
        }
        //Метод Insert, позволяющий добавить элемент в произвольную позицию массива
        public void Insert(T elem, int position)
        {
            if (position < Capacity && position >= 0)//проверка на возможнось вставки элемента в выбранную позицию
            {
                if (Capacity != Length)
                {
                    for (int i = 0; i < Length - position; i++)
                    {
                        array[Length - i] = array[Length - i - 1];
                    }
                    array[position] = elem; //устанавливаем элемент на выбранную позицию
                }
                else
                {
                    IncreaseCapacity(); //увеличиваем емкость

                    for (int i = 0; i < Length - position; i++)
                    {
                        array[Length - i] = array[Length - i - 1];
                    }
                    array[position] = elem;
                }
            }
            else
            {
                  throw new ArgumentOutOfRangeException();
            }
           
        }

        //Индексатор, позволяющий работать с элементом с указанным номером
        public T this[int index]
        {
            get
            {
                if (index < Capacity)
                {
                    return array[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (index < Capacity)
                {
                    array[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
