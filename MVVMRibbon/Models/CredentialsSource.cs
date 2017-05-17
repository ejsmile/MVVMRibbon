using System.Collections.Generic;
using DevExpress.Mvvm.POCO;
using MVVMRibbon.Models;

namespace MVVMRibbon.ViewModels
{
    //
    // TODO - your implementation
    static class CredentialsSource {
        static System.Collections.Hashtable credentials;
        static CredentialsSource() {
            credentials = new System.Collections.Hashtable();
            credentials.Add("Guest", GetHash(null));
            credentials.Add("Reader", GetHash("reader"));
            credentials.Add("Administrator", GetHash("admin"));
        }
        internal static bool Check(string login, string pwd)
        {
            return login != null && Equals(credentials[login], GetHash(pwd));
        }

        static object GetHash(string password) {
            return password;
        }
        internal static System.Collections.Generic.IEnumerable<string> GetUserNames() {
            foreach(string item in credentials.Keys)
                yield return item;
        }
    }
}
