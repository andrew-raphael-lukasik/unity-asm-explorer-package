using UnityEditor;

namespace AsmExplorer
{
    [InitializeOnLoadAttribute]
    public static class ExplorerInstance
    {
        static WebService s_WebService;

        static ExplorerInstance() {
            RestartWebservice();
        }

        public static bool WebServiceRunning => s_WebService != null;

        public static void EnsureWebservice() {
            if (!WebServiceRunning)
                RestartWebservice();
        }

        public static void RestartWebservice()
        {
            s_WebService?.Stop();
            s_WebService = new WebService(new Explorer(), "explorer");
            s_WebService.Start();
        }
        
        public static void StopWebservice()
        {
            s_WebService?.Stop();
            s_WebService = null;
        }
    }
}