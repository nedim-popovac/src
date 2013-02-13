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

            Directory directory = FSDirectory.Open("E:\\GitHub\\LuceneIndex");

            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29);


            var parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_29, "postBody", analyzer);

            Query query = parser.Parse(wordToSearch+"*");

            var searcher = new IndexSearcher(directory, true);


            TopDocs topDocs = searcher.Search(query, 10);


            int results = topDocs.ScoreDocs.Length;

            Console.WriteLine("Found {0} results", results);

            ScoreDoc scoreDoc;
            for (int i = 0; i < results; i++)
            {

                 scoreDoc = topDocs.ScoreDocs[i];

                float score = scoreDoc.Score;

                int docId = scoreDoc.Doc;

                Document doc = searcher.Doc(docId);



                Console.WriteLine("Result num {0}, score {1}", i + 1, score);

                Console.WriteLine("ID: {0}", doc.Get("id"));

                Console.WriteLine("Text found: {0}\r\n", doc.Get("postBody"));
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