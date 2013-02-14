using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lucene.Net.Store;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using Lucene.Net;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;

namespace KMWeb
{
    public partial class SearchResults : System.Web.UI.Page
    {
        public static void SearchSomething(string wordToSearch)
        {

            Directory directory = FSDirectory.Open(new
    System.IO.DirectoryInfo("E:\\GitHub\\LuceneIndex"));

            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29);


            QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_29, "postBody", analyzer);

            Query query = parser.Parse(wordToSearch+"*");

            //Setup searcher
            IndexSearcher searcher = new IndexSearcher(directory);
            //Do the search
            //Hits hits = searcher.Search(query);

            //var searcher = new IndexSearcher(directory, true);

            Lucene.Net.Search.Query query1 = parser.Parse(wordToSearch); 
            Lucene.Net.Search.Searcher searcher1 =
  new Lucene.Net.Search.IndexSearcher
    (Lucene.Net.Index.IndexReader.Open(directory, true));

            TopScoreDocCollector collector =
    TopScoreDocCollector.Create(100, true);

            searcher1.Search(query1, collector);
            ScoreDoc[] hits = collector.TopDocs().ScoreDocs;


            for (int j = 0; j < hits.Length; j++)
            {
                int docId = hits[j].Doc;
                float score = hits[j].Score;

                Lucene.Net.Documents.Document doc = searcher.Doc(docId);

                string result = "Score: " + score.ToString() +
                                " Field: " + doc.Get("postBody") +
                                " Field2: " + doc.Get("TERM");

            }

            //QueryParser parser = new QueryParser("postBody", analyzer);
            //Query query = parser.Parse("text");


            TopDocs topDocs = searcher.Search(query, 20);


            int results = topDocs.ScoreDocs.Length;
           // int results = hits.Length();

            //var parser = BuildQueryParser();
            //var query = parser.Parse(searchQuery);
            var Searcher = searcher;

            TopDocs hits1 = searcher.Search(query, null, 20);
            //IList<SearchResult> result = new List<SearchResult>();
            //float scoreNorm = 1.0f / hits.GetMaxScore();


            Console.WriteLine("Found {0} results", results);

            ScoreDoc scoreDoc;
            for (int i = 0; i < topDocs.TotalHits; i++)
            {
                Document doc = searcher.Doc(topDocs.ScoreDocs[i].Doc);
                //Document doc = searcher.Doc(td.scoreDocs[i].doc);

                 //scoreDoc = topDocs.ScoreDocs[i];

                //float score = scoreDoc.Score;

                //int docId = scoreDoc.Doc;

               // Document doc = searcher.Doc(docId);



                //Console.WriteLine("Result num {0}, score {1}", i + 1, score);

                //Console.WriteLine("ID: {0}", doc.Get("id"));

                //Console.WriteLine("Text found: {0}\r\n", doc.Get("postBody"));
                string a = doc.Get("postBody");
            }

            
            searcher.Dispose();

            directory.Dispose();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string wordToSearch = Request.QueryString["WordToSearch"];
            SearchSomething(wordToSearch);
        }
    }
}