using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class LogRepository : ILogRepository
    {
        public async Task<ParseLogResult> ParseLog(string filePath)
        {
            var lines = File.ReadAllLines(filePath.Trim('"'));
            var result = new Dictionary<string, Report>();

            Report currentGame = null;
            int gameIndex = 1;

            foreach (var line in lines)
            {
                if (line.Contains("InitGame"))
                {
                    currentGame = new Report();
                    result[$"game_{gameIndex++}"] = currentGame;
                }
                else if (line.Contains("Kill:"))
                {
                    if (currentGame == null) continue;

                    currentGame.TotalKills++;

                    var match = Regex.Match(line, @"Kill:\s+\d+\s+\d+\s+\d+:\s+(.+?)\s+killed\s+(.+?)\s+by");
                    if (!match.Success) continue;

                    var killer = match.Groups[1].Value;
                    var victim = match.Groups[2].Value;

                    if (victim != "<world>" && !currentGame.Players.Contains(victim))
                        currentGame.Players.Add(victim);

                    if (killer != "<world>" && !currentGame.Players.Contains(killer))
                        currentGame.Players.Add(killer);

                    if (killer == "<world>")
                    {
                        if (!currentGame.Kills.ContainsKey(victim))
                            currentGame.Kills[victim] = 0;
                        currentGame.Kills[victim]--;
                    }
                    else
                    {
                        if (!currentGame.Kills.ContainsKey(killer))
                            currentGame.Kills[killer] = 0;
                        currentGame.Kills[killer]++;
                    }
                }
            }

            return new ParseLogResult { Games = result };
        }
    }
}
