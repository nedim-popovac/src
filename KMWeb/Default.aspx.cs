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
    public partial class _Default : System.Web.UI.Page
    {

        private static void WriteDocument()
        {

            Directory directory = FSDirectory.Open("E:\\GitHub\\LuceneIndex");
            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            IndexWriter writer = new IndexWriter(directory, analyzer,IndexWriter.MaxFieldLength.UNLIMITED);

            //Directory directory = FSDirectory.Open("E:\\GitHub\\LuceneIndex");


            //Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29);

            //var writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);

            Document doc = new Document();
            
            //doc.Add(new Field("postBody", text, Field.Store.YES, Field.Index.TOKENIZED));
            

           // var doc = new Document();

            //doc.Add(new Field("id", "1", Field.Store.YES, Field.Index.NO));

           // doc.Add(new Field("postBody", "Lorem ipsum", Field.Store.YES,
             //                  Field.Index.ANALYZED));

            doc.Add(new Field("id", "1", Field.Store.YES, Field.Index.ANALYZED));

            doc.Add(new Field("postBody", "brazil", Field.Store.YES,
                               Field.Index.ANALYZED));

            doc.Add(new Field("id", "2", Field.Store.YES, Field.Index.ANALYZED));

            doc.Add(new Field("postBody", "argentina", Field.Store.YES,
                               Field.Index.ANALYZED));

            writer.AddDocument(doc);


            writer.Optimize();
           
            writer.Commit();

            writer.Dispose();
        }

        

        protected void Page_Load(object sender, EventArgs e)
        {
                HyperLinkKM.NavigateUrl = "CategoryView.aspx?CategoryId=1";
                HyperLinkWEBP.NavigateUrl = "CategoryView.aspx?CategoryId=2";
                HyperLinkStatistika.NavigateUrl = "CategoryView.aspx?CategoryId=3";
                HyperLinkNoCat.NavigateUrl = "CategoryView.aspx?CategoryId=4";
                if (!IsPostBack)
                   WriteDocument();
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/NewArticle.aspx");
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/NewArticle.aspx");
        }

        protected void btnSearchBox_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SearchResults.aspx?WordToSearch=" + txtSearchBox.Text);
            
        }
    }
}
