﻿using System;
using System.Text;
using _10.State.States;
using _10.State.States.Abstract;

namespace _10.State
{
    public class GumballMachine
    {
        private IState _soldOutState;
        private IState _noQuarterState;
        private IState _hasQuarterState;
        private IState _soldState;

        private IState _state;
        private int _count = 0;

        public GumballMachine(int count)
        {
            _soldOutState = new SoldOutState(this);
            _noQuarterState = new NoQuarterState(this);
            _hasQuarterState = new HasQuarterState(this);
            _soldState = new SoldState(this);
            
            _count = count;
            if (count > 0)
            {
                _state = _noQuarterState;
            }
        }

        public void InsertQuarter()
        {
            _state.InsertQuarter();
        }

        public void EjectQuarter()
        {
            _state.EjectQuarter();
        }

        public void TurnCrank()
        {
            _state.TurnCrank();
            _state.Dispense();
        }

        internal void ReleaseBall()
        {
            Console.WriteLine("A gumball comes rolling out the slot...");
            if (_count > 0)
            {
                _count = _count - 1;
            }
        }
        
        public void Refill(int numGumBalls)
        {
            _count = numGumBalls;
            _state = _noQuarterState;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("\nMighty Gumball, Inc.");
            result.Append("\nJava-enabled Standing Gumball Model #2004\n");
            result.Append($"Inventory: {_count.ToString()} gumball");
            if (_count != 1)
            {
                result.Append("s");
            }

            result.Append("\nMachine is ");
            if (_state == _soldOutState)
            {
                result.Append("sold out");
            }
            else if (_state == _noQuarterState)
            {
                result.Append("waiting for quarter");
            }
            else if (_state == _hasQuarterState)
            {
                result.Append("waiting for turn of crank");
            }
            else if (_state == _soldState)
            {
                result.Append("delivering a gumball");
            }

            result.Append("\n");
            return result.ToString();
        }

        internal void SetState(IState state)
        {
            _state = state;
        }

        internal IState GetHasQuarterState()
        {
            return _hasQuarterState;
        }

        internal IState GetNoQuarterState()
        {
            return _noQuarterState;
        }

        internal IState GetSoldOutState()
        {
            return _soldOutState;
        }

        internal IState GetSoldState()
        {
            return _soldState;
        }

        internal int GetCount()
        {
            return _count;
        }
    }
}