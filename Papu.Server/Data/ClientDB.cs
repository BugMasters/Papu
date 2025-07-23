using Supabase;

namespace Papu.Server.Data
{
    public class ClientDB
    {
        private bool IsInitialized = false;

        public Client Client { get; private set; }

        private static readonly Lazy<ClientDB> lazy = new Lazy<ClientDB>(() => new ClientDB());

        public static ClientDB Instance => lazy.Value;

        public async Task InitializeAsync(string pUrl, string pKey)
        {
            if(IsInitialized) return;

            Client = new Client(pUrl, pKey, new SupabaseOptions
            {
                AutoConnectRealtime = true
            });

            await Client.InitializeAsync();
            IsInitialized = true;
        }
    }
}
