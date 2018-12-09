using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using DABHandIn4.TraderInfoRestApi.Core.Repositories;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Document = Microsoft.Azure.Documents.Document;

namespace DABHandIn4.TraderInfoRestApi.Presistences.Repositories
{
    public class RepositoryHistorik<T> : IRepository<T> where T : class
    {
        public RepositoryHistorik()
        {
            CreateCollectionIfNotExistsAsync().Wait();
        }

        public IDocumentClient Client()
        {

            IDocumentClient client = new DocumentClient(new Uri(Endpoint), Key);
            return client;
        }
        //private readonly string Endpoint = "https://localhost:8081";
        //private readonly string Key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        //private readonly string DatabaseId = "TraderInfo";
        //private readonly string CollectionId = "HistorikOgAktuel";

        private readonly string Endpoint = "https://e18i4dab.documents.azure.com:443";
        private readonly string Key = "f0iauDuxIYj9maEbhPBoeO8r8gpXRnCmVsRizDE9JgSbmmGdpFMve7hNQJ8ijXKZGztjJj6DtWd4s3gPvRrT4g==";
        private readonly string DatabaseId = "E18I4DABH4Gr15";
        private readonly string CollectionId = "HistorikOgAktuel";
        private DocumentClient client;

        public virtual async Task<IQueryable<T>> GetAllItemsAsync()
        {
            IDocumentQuery<T> query = Client().CreateDocumentQuery<T>(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), new FeedOptions { MaxItemCount = -1 }).AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results.AsQueryable();
        }

        public virtual async Task<T> GetItemAsync(string id)
        {
            try
            {
                Document document = await Client().ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
                return (T)(dynamic)document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public virtual async Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            IDocumentQuery<T> query = Client().CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                new FeedOptions { MaxItemCount = -1 })
                .Where(predicate)
                .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }

        public virtual async Task<Document> CreateItemAsync(T item)
        {
            return await Client().CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), item);
        }

        public virtual async Task<Document> UpdateItemAsync(string id, T item)
        {
            return await Client().ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id), item);
        }

        public virtual async Task DeleteItemAsync(string id)
        {
            await Client().DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
        }

        //public virtual void Initialize()
        //{
        //    client = new DocumentClient(new Uri(Endpoint), Key);
        //    CreateDatabaseIfNotExistsAsync().Wait();
        //    CreateCollectionIfNotExistsAsync().Wait();
        //}

        private async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await Client().ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await Client().CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task CreateCollectionIfNotExistsAsync()
        {
            try
            {
                await Client().ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await Client().CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection { Id = CollectionId },
                        new RequestOptions { OfferThroughput = 1000 });
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
