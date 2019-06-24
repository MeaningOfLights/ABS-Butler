using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSDownloader
{

    public class Config
    {
        public const string googleSite = "site:";
        public string SOwebsite { get; set; } //  defaults to "site:Stackoverflow.com";
        public string cultureInfo { get; set; } //  defaults to "en-US";
        public int opacity { get; set; }

        public ResultsSort resultSort { get; set; }
        public AnswersSort answersSort { get; set; }

        public string topUserIds { get; set; }
        public string topBountyHunterIds { get; set; }

        public bool excludeProjectName { get; set; }
        public bool excludeSolutionName { get; set; }

        public string codingLanguage { get; set; }

        public string[] noiseWords { get; set; }
        public bool replaceNoiseWordsWithAsterisk { get; set; }

        public bool upvoteCopyPastedQuestion { get; set; }
        public bool upvoteCopyPastedAnswer { get; set; }
    }

    public enum ResultsSort
    {
        Relevance, // tf–idf weighting scheme: http://en.wikipedia.org/wiki/Tf%E2%80%93idf
        Votes,
        HighRepUsers,
        MostViewed,
        Bounty
    }

    public enum AnswersSort
    {
        //Bounty = 1,
        //MarkedAnswer = 2,
        //MostVotes = 4  //I was thinking of a sorting algorithm
        Votes,
        Active,
        Oldest
    }
}
