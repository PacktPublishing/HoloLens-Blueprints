using Microsoft.Azure.Documents.Client;
using System;
using System.Linq;

namespace AssetAPI.Models
{
    /// <summary>
    /// Product List Creator
    /// </summary>
    public class ProductListCreator
    {
        private DocumentClient client;
        private const string EndpointUri = "https://holoretaildb.documents.azure.com:443/";
        private const string PrimaryKey = "zQo6dggvkplL8mYIEzEViRvw6YpwRsRS0ET3viHSm1vKToQZs9ty7MWlQiQAFWjYQiViCERpQQKo3iQDWn2YOQ==";
        private const string DatabaseName = "ProductCollectionDB";
        private const string CollectionName = "ProductCollection";

        /// <summary>
        /// Get the Product List
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductList GetProductList(string id)
        {
            this.client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);

            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };


            IQueryable<ProductList> prodQuery = this.client.CreateDocumentQuery<ProductList>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName), queryOptions)
                    .Where(f => f.Id == id);


            foreach (ProductList product in prodQuery)
            {
                return product;
            }

            return null;
        }
    }
}