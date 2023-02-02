using System.Collections.Generic;
using BuggyApiTest.Support;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace BuggyApiTest.TestData
{
    public class RegisterTestData
    {
        public RegisterTestData()
        {
        }

        public static IEnumerable<TestCaseData> RegisterData()
        {
            //bool useNum, bool useLow, bool useUpp, bool useSpe, string custom
            yield return new TestCaseData(
                "user_auto"+ StringCommon.GetRandomString(10, true, true, true, false, ""),
                "first_name", "last_name", "!Q23sdklf", System.Net.HttpStatusCode.Created, null).
                SetName("Check register user properly");
            yield return new TestCaseData("user_auto", "first_name", "last_name", "!Q23sdklf",
                System.Net.HttpStatusCode.BadRequest, "UsernameExistsException: User already exists").
                SetName("Check register user existing");
            yield return new TestCaseData(
                "user_auto" + StringCommon.GetRandomString(10, true, true, true, false, ""),
                "first_name", "last_name", "!Q23sdk",
                System.Net.HttpStatusCode.BadRequest,
                "InvalidPasswordException: Password did not conform with policy: Password not long enough").
                SetName("Check register user with password !Q23sdk");
        }

        public static string setUserData(string dataFile, string userName, string firstName, string lastName, string password)
        {

            JObject jObject = JsonCommon.GetJsonFromDataFile(dataFile);
            jObject["username"] = userName;
            jObject["firstName"] = firstName;
            jObject["lastName"] = lastName;
            jObject["password"] = password;
            jObject["confirmPassword"] = password;

            return jObject.ToString();
        }
    }
}
