using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;

public class Leaderboard : MonoBehaviour 
{
    public Text[] usernames;
    public Text[] times;
    private List<string> usernamesList = new List<string>();
    private List<string> sortedUsernamesList = new List<string>();
    private List<string> timesList = new List<string>();
    private List<int> intTimesList = new List<int>();
    private List<int> sortedIntTimesList = new List<int>();
    private bool leaderboardCreated = false;

    public void GetLeaderboard() {
        if (!leaderboardCreated) {
            DataDump.Initialize();
            IList<IList<object>> usernamesListDump = DataDump.ReadEntries("A3", "A20", 0);
            usernamesList.AddRange(from list in usernamesListDump
                                   from username in list
                                   select username as string);
            IList<IList<object>> timesListDump = DataDump.ReadEntries("R3", "R20", 0);
            timesList.AddRange(from list in timesListDump from time in list select time as string);
            foreach (string time in timesList) {
                var match = Regex.Match(time, @"([-+]?[0-9]*\.?[0-9]+)");
                if (match.Success) {
                    intTimesList.Add(Mathf.RoundToInt(System.Convert.ToSingle(match.Groups[1].Value)));
                } else {
                    intTimesList.Add(-1);
                }
            }
            foreach (int time in intTimesList) {
                if (time == -1) {
                    usernamesList.RemoveAt(intTimesList.IndexOf(-1));
                    intTimesList.Remove(-1);
                }
            }
            Debug.Log(intTimesList.Count);
            Debug.Log(usernamesList.Count);
            sortedIntTimesList = intTimesList.ToList().OrderBy(t => t).ToList();
            if (sortedIntTimesList.Count > 9) {
                sortedIntTimesList = sortedIntTimesList.GetRange(0,8).ToList();
                usernamesList = usernamesList.GetRange(0, 8).ToList();
            }
            Debug.Log(sortedIntTimesList.Count);
            foreach (var time in sortedIntTimesList) {

                sortedUsernamesList.Add(usernamesList[intTimesList.IndexOf(time)]);
            }
            int leaderboardLength = (sortedUsernamesList.Count <= sortedIntTimesList.Count ? sortedUsernamesList.Count : sortedIntTimesList.Count);
            for (int i = 0; i < leaderboardLength; i++) {
                usernames[i].text = sortedUsernamesList[i];
                int minutes = Mathf.FloorToInt(sortedIntTimesList[i] / 60);
                int seconds = sortedIntTimesList[i] % 60;
                string secondsText = seconds.ToString();
                while (secondsText.Length < 2) {
                    secondsText = "0" + secondsText;
                }
                times[i].text = (minutes != 0 ? (minutes.ToString() + ":") : "0:") + secondsText;
            }
            if (leaderboardLength < usernames.Length) {
                for (int i = leaderboardLength; i < usernames.Length; i++) {
                    usernames[i].text = "";
                    times[i].text = "";
                }
            }
            leaderboardCreated = true;
        }
    }
}