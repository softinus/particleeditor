using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.DirectSound;

namespace Ex1
{
    class Event
    {
        string szEventID;


        /// <summary>
        /// EventID
        /// </summary>
        /// <returns>Event name</returns>
        public string EventID
        {
            get { return szEventID; }
            set { szEventID = value; }
        }

        bool bPlayAtBirth;

        /// <summary>
        /// Play At Birth
        /// </summary>
        /// <returns>boolean that says if the event is to happen at a particles birth</returns>
        public bool PlayAtBirth
        {
            get { return bPlayAtBirth; }
            set { bPlayAtBirth = value; }
        }
        bool bPlayAtDeath;

        /// <summary>
        /// Play At Death
        /// </summary>
        /// <returns>boolean that says if the event is to happen at a particles death</returns>
        public bool PlayAtDeath
        {
            get { return bPlayAtDeath; }
            set { bPlayAtDeath = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="EventID">Name of the event</param>
        /// <param name="PlayOnDeath">true if it plays on death of a particle</param>
        /// <param name="PlayOnBirth">true if it plays on death of a particle</param>
        public Event(string EventID, bool PlayOnDeath, bool PlayOnBirth)
        {
            szEventID = EventID;
            bPlayAtBirth = PlayOnBirth;
            bPlayAtDeath = PlayOnDeath;
        }

    }
}
