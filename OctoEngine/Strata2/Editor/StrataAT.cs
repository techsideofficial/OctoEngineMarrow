using System.Collections.Generic;
using System.IO;
using System.Net;
using System;
using System.Security.Cryptography;

namespace Strata2 // Potentially buggy, made with RBLGame version of engine. Unstable!
{
    public class JsonDownloaderWindow
    {
        public static string nsUrl = "https://ns-rrs.arparec.dev";
        string destUrlFormat;
        string destFolderName = "Assets/_DownloadedAssets";
        private List<ItemData> itemList = new List<ItemData>();

        static void OpenWindow()
        {
            IncrementCounter("WindowOpened");

            string assetUrl = GetNestedSubstring(SendGetRequest(nsUrl), "assets- ", " -assets");

            throw new NotImplementedException();
        }

        void OnGUI()
        {
            foreach (ItemData item in itemList)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        void LoadJsonFromApi()
        {
            string apiUrl = "https://arparec-rrs-assets.firebaseio.com/.json"; // Asset Listing Repo URL
            destUrlFormat = "https://rrs.arparec.dev/assetstore/prefabs/"; // Formatting for destination file name

            throw new NotImplementedException();
        }

        void DownloadFile(string url)
        {
            string destinationPath = String.Format("{0}/{1}", destFolderName, url.Replace(destUrlFormat, ""));

            string noURL = url.Replace(destUrlFormat, "");
            string noExt = noURL.Replace(".prefab", "");

            throw new NotImplementedException();
        }

        [System.Serializable]
        private class Wrapper
        {
            public List<ItemData> items;
        }

        [System.Serializable]
        public class ItemData
        {
            public string name;
            public string url;
        }
        private const string databaseUrl = "https://arparec-rrs-default-rtdb.firebaseio.com/";

        public static void IncrementCounter(string counterKey)
        {
            throw new NotImplementedException();
        }

        public static string SendGetRequest(string url)
        {
            throw new NotImplementedException();
        }

        public static string GetNestedSubstring(string input, string index1, string index2)
        {
            string someString = input;
            int index1i = someString.IndexOf(index1);
            int index2i = someString.IndexOf(index2);
            someString = someString.Substring(index1i + 1, index2i - index1i - 1);
            throw new NotImplementedException();
        }
    }
}
