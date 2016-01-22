using Baricade.Core.Movables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core.Fields
{
    public class ContainerField : BaseField
    {
        private Movable _tempChild;
        private Movable _child;

        public Movable Child
        {
            get { return _child; }
            set
            {
                _child = value;
                if(_child != null)
                {
                    _child.StandingOn = this;
                }               
            }
        }
        public Movable TempChild
        {
            get { return _tempChild; }
            set
            {
                _tempChild = value;
                if(_tempChild != null)
                {
                    _tempChild.StandingOn = this;
                }               
            }
        }

        

        public override bool IsEmpty => Child == null;

        public override bool AcceptMove(Movable movable)
        {
            if(movable is Movables.Pawn)
            {
                if(Child is Movables.Baricade)
                {
                    if(movable.HasMovesLeft)
                    {
                        return false;
                    }                   
                }
                else 
                {
                    if(!IsEmpty)
                    {
                        var pawn = movable as Pawn;
                        var child = Child as Pawn;
                        if (pawn.Owner == child.Owner && movable.IsLastMove)
                        {
                            return false;
                        }
                    }                    
                }
            }
            return true;
        }

        public void Place(Movable movable)
        {
            if(movable.HasMovesLeft)
            {
                RemovePreviousMovable(movable);

                TempChild = movable;
            }
            else
            {
                if(!IsEmpty)
                {
                    //geslagen Child gaat naar juiste collectionfield'
                    var sendToAfterHit = SendToAfterHit(Child as Pawn);
                    sendToAfterHit.Children.Add(Child);
                    Child.StandingOn = sendToAfterHit;
                    //baricademode moet worden aangezet als baricade wordt geslagen
                }
                RemovePreviousMovable(movable);
                
                Child = movable;                
            }
        }

        void RemovePreviousMovable(Movable movable)
        {
            if (movable.IsFirstMove)
            {
                var standingOnContainer = movable.StandingOn as ContainerField;
                if (standingOnContainer == null)
                {
                    var standingOnCollection = movable.StandingOn as CollectionField;
                    standingOnCollection.Children.Remove(movable);
                }
                else //container
                {
                    standingOnContainer.Child = null;
                }
            }
            else
            {
                var standingOnContainer = movable.StandingOn as ContainerField;
                if (standingOnContainer != null)
                {
                    standingOnContainer.TempChild = null;
                }
            }
        }

        public void ClearPrevious(Movable movable)
        {
            var cf = movable.StandingOn as ContainerField;
            if (cf != null)
            {                
                if (cf.TempChild == movable)
                    cf.TempChild = null;
                else
                    cf.Child = null;
            }

            var collf = movable.StandingOn as CollectionField;
            if (collf != null)
                collf.Children.Remove(movable);
        }

        void ClearPreviousTempChild(Movable movable)
        {
            var cf = movable.StandingOn as ContainerField;
            if (cf != null && cf.TempChild == movable)
                cf.TempChild = null;
        }

        public virtual CollectionField SendToAfterHit(Pawn pawn)
        {
            return Board.GetSpawnPointForPlayer(pawn.Owner);
        }
    }
}
