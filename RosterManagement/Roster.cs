using System;
using System.Linq;
using System.Collections.Generic;

namespace RosterManagement
{
    public class CodeSchool
    {
        Dictionary<int, List<string>> _roster;

        public CodeSchool()
        {
            _roster = new Dictionary<int, List<String>>();
        }
        
        /// <summary>
        /// Should be able to Add Student to a Particular Wave
        /// </summary>
        /// <param name="cadet">Refers to the name of the Cadet</param>
        /// <param name="wave">Refers to the Wave number</param>
        public void Add(string cadet, int wave)
        {
            List<string> list;
            if (!_roster.ContainsKey(wave))
            {
                list = new List<string>();
                list.Add(cadet);
                _roster.Add(wave, list);
            }
            else
            {
                list = _roster[wave];
                list.Add(cadet);
                _roster[wave] = list;
            }
            
        }

        /// <summary>
        /// Returns all the Cadets in a given wave
        /// </summary>
        /// <param name="wave">Refers to the wave number from where cadet list is to be fetched</param>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Grade(int wave)
        {
            List<string> list = new List<string>();
            try
            {
                list = _roster[wave];
                list.Sort();
            }
            catch(KeyNotFoundException e)
            {
                Console.WriteLine(e);
            }

            return list;
        }

        /// <summary>
        /// Return all the cadets in the CodeSchool
        /// </summary>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Roster()
        {
            var cadets = new List<string>();

            List<int> list = new List<int>();

            foreach (KeyValuePair<int, List<string>> entry in _roster)
            {
                list.Add(entry.Key);
            }
            list.Sort();

            foreach (int a in list)
            {
                List<String> listOfCadetsInAWave = _roster[a];
                listOfCadetsInAWave.Sort();
                cadets.AddRange(listOfCadetsInAWave);
            }
            
            return cadets.ToList();
        }
    }
}