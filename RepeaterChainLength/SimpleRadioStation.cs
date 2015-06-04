using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeaterChainLength
{
    /// <summary>
    /// 4) Repeater chain length
    /// In one type of simple radio network, transceivers can operate on one of 20 fixed frequencies, which we will call channels 0 to 19.  
    /// Each transceiver can only cover a limited distance, beyond which the signal is too weak to be received. 
    /// The "central" transceiver always operates on channel 0.  
    /// To extend the network coverage, repeaters are installed which receive a signal on one channel and re-transmit the signal on another channel.  
    /// Each repeater can be described as a pair of channel numbers, the "upstream" channel number (which is "closer" to the central node) and the "downstream" channel number 
    /// (which is "further" from the central node).  
    /// No repeater can have a downstream channel of 0 (since this is used by the central node) and no two repeaters can have the same downstream channel (since their transmissions would interfere).
    /// Questions:
    /// 1. Given a list of repeater channel number pairs, determine the longest chain of repeaters in the network, 
    /// and identify any repeaters that are "orphaned" because there is no chain that connects them back to the central node.
    /// For example, for this set or repeaters (upstream/downstream):
    /// 0/1, 1/2, 3/4, 0/5
    /// the longest chain is two repeaters and repeater 3/4 is orphaned.
    /// </summary>
    public class SimpleRadioStation
    {
        List<Transceiver> _tranceivers = new List<Transceiver>();
        public SimpleRadioStation()
        {
            CentralReceiver centralReceiver = new CentralReceiver();
            _tranceivers.Add(centralReceiver);

        }
        public void CreateRepeaters(List<Repeater> repeaters)
        {
            int index = 1;
            foreach (var repeater in repeaters)
            {
                repeater.Index = index;
                _tranceivers.Add(repeater);
                index++;
            }
        }
        public int GetLongestChainOfRepeaters()
        {
            int result = 0;
            //start with the down.
            //get its up.
            //get the next repeater with a down value matching the up.
            //increment the count.
            //repeat.
            int receiverCount = 0;
            foreach (var receiver in _tranceivers)
            {
                var currentLength = CalculateLongest(receiver, receiverCount);
                if (currentLength > result)
                    result = currentLength;

                receiverCount++;
            }

            
            return result;
        }
        private int CalculateLongest(Transceiver repeater, int receiverCount)
        {
            int length = 0;
            //start with the down.
            //get its up.
            //get the next repeater with a down value matching the up.
            //increment the count.
            //repeat.
            
            var down = repeater.DownStreamFrequency;
            var up = repeater.UpStreamFrequency;

            foreach (var nextRepeater in _tranceivers)
            {
                if (repeater.Index != nextRepeater.Index)//don't test self.
                {
                    var nextRepeaterDown = nextRepeater.DownStreamFrequency;
                    var nextRepeaterUP = nextRepeater.UpStreamFrequency;

                    if (down == nextRepeaterUP)
                        length++;
                }
            }
            return length;
        }

        public List<Transceiver> GetOrphanedRepeaters()
        {
            List<Transceiver> result = new List<Transceiver>();
            //start with the down.
            //get its up.
            //get the next repeater with a down value matching the up.
            //increment the count.
            //repeat.
            int receiverCount = 0;
            foreach (var receiver in _tranceivers)
            {
                var orphaned = CalculateOrphans(receiver, receiverCount);
                if (orphaned != null)
                    result.Add(orphaned);

                receiverCount++;
            }

            return result;
        }
        private Transceiver CalculateOrphans(Transceiver repeater, int receiverCount)
        {
            if (!(repeater is Repeater))
                return null;


            Transceiver result = repeater;

            //get its down.
            //traverse through ever other repeater and check it's up.
            //if there is not a single match then I am an orphan.

            var down = repeater.DownStreamFrequency;
            var up = repeater.UpStreamFrequency;

            
            foreach (var nextRepeater in _tranceivers)
            {
                
                if (repeater.Index != nextRepeater.Index)//don't test self.
                {
                    var nextRepeaterDown = nextRepeater.DownStreamFrequency;
                    var nextRepeaterUP = nextRepeater.UpStreamFrequency;

                    if (up == nextRepeaterDown)
                        return null;
                        
                }
            }
            
            
            return result;

        }
    }

    public class Transceiver
    {
        List<int> _frequencies = new List<int>(20);
        int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        int _upStreamFrequency;
        public int UpStreamFrequency
        {
            get { return _upStreamFrequency; }
            set { _upStreamFrequency = value; }
        }
        int _downStreamFrequency;
        public int DownStreamFrequency
        {
            get { return _downStreamFrequency; }
            set
            {
                //if (value <= 0)
                //    throw new Exception("DownStream Frequency cannot be less than 0.");


                _downStreamFrequency = value;
            }
        }

        public Transceiver(int upStreamFrequency, int downStreamFrequency)
        {
            UpStreamFrequency = upStreamFrequency;
            DownStreamFrequency = downStreamFrequency;
        }

        public override string ToString()
        {
            return UpStreamFrequency + "/" + DownStreamFrequency; 
        }
    }

    public class CentralReceiver : Transceiver
    {
        
        public CentralReceiver() : base(0, 0)
        {
            
        }
    }

    public class Repeater : Transceiver
    {
        

        public Repeater(int upStreamFrequency, int downStreamFrequency) : base(upStreamFrequency, downStreamFrequency)
        {
            
        }
        
    }
}
