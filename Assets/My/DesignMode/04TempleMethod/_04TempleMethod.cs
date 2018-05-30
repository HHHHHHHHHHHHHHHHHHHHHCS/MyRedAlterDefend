using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DesignMode
{

    public class _04TempleMethod : MonoBehaviour
    {
        private void Awake()
        {
            AbsPeople south = new SouthPeople();
            south.Eat();
            AbsPeople north = new NorthPeople();
            north.Eat();
        }
    }


    public abstract class AbsPeople
    {
        public void Eat()
        {
            OrderFood();
            EatSomething();
            PayBill();
        }

        private void OrderFood()
        {
            Debug.Log("点菜");
        }

        protected virtual void EatSomething()
        {

        }

        private void PayBill()
        {
            Debug.Log("买单");
        }
    }

    public class NorthPeople : AbsPeople
    {

        protected override void EatSomething()
        {
            Debug.Log("我在吃面条");
        }
    }


    public class SouthPeople : AbsPeople
    {

        protected override void EatSomething()
        {
            Debug.Log("我在吃米饭");
        }
    }
}