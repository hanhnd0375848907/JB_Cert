using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public enum BlankCertType
    {
        HightSchool = 1,
        JuniorHighSchool = 2,
        University = 3,
        Master = 4
    }

    public enum KindOfCert
    {
        Root = 1,
        Copy = 2
    }

    public static class Permission
    {
        public static string StudentList = "StudentList";
        public static string AddStudent = "AddStudent";
        public static string DeleteStudent = "DeleteStudent";
        public static string UpdateStudent = "UpdateStudent";
        public static string SchoolList = "SchoolList";
        public static string AddSchool = "AddSchool";
        public static string DeleteSchool = "DeleteSchool";
        public static string UpdateSchool = "UpdateSchool";
        public static string ExamList = "ExamList";
        public static string AddExam = "AddExam";
        public static string UpdateExam = "UpdateExam";
        public static string DeleteExam = "DeleteExam";
        public static string BlankCertList = "BlankCertList";
        public static string AddBlankCert = "AddBlankCert";
        public static string UpdateBlankCert = "UpdateBlankCert";
        public static string DeleteBlankCert = "DeleteBlankCert";
        public static string CertList = "CertList";
        public static string AddCert = "AddCert";
        public static string DeleteCert = "DeleteCert";
        public static string UpdateCert = "UpdateCert";
        public static string BlankCertTypeList = "BlankCertTypeList";
        public static string PrintCert = "PrintCert";
        public static string ManagingAccount = "ManagingAccount";
        public static string BlankCertConfig = "BlankCertConfig";
        public static string EducationAndTraning = "EducationAndTraning";
    }
    public static class Common
    {
        public const string VERSION = "1.2.0";
        public const string COMMON_ERORR = "Có lỗi, vui lòng liên hệ nhà phát triển phần mềm";
    }

    public static class CurrentUser
    {
        public static int Id { get; set; }
        public static string Username { get; set; }

    }

    public static class TextHelper
    {
        public static string ConvertToUnsign(string strInput)
        {
            string stFormD = strInput.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }
    }

    public static class PasswordWraper
    {
        public static string GeneratePassword(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial, bool includeSpaces, int lengthOfPassword)
        {
            const int MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS = 2;
            const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
            const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NUMERIC_CHARACTERS = "0123456789";
            const string SPECIAL_CHARACTERS = @"!#$%&*@\";
            const string SPACE_CHARACTER = " ";
            const int PASSWORD_LENGTH_MIN = 8;
            const int PASSWORD_LENGTH_MAX = 128;

            if (lengthOfPassword < PASSWORD_LENGTH_MIN || lengthOfPassword > PASSWORD_LENGTH_MAX)
            {
                return "Password length must be between 8 and 128.";
            }

            string characterSet = "";

            if (includeLowercase)
            {
                characterSet += LOWERCASE_CHARACTERS;
            }

            if (includeUppercase)
            {
                characterSet += UPPERCASE_CHARACTERS;
            }

            if (includeNumeric)
            {
                characterSet += NUMERIC_CHARACTERS;
            }

            if (includeSpecial)
            {
                characterSet += SPECIAL_CHARACTERS;
            }

            if (includeSpaces)
            {
                characterSet += SPACE_CHARACTER;
            }

            char[] password = new char[lengthOfPassword];
            int characterSetLength = characterSet.Length;

            System.Random random = new System.Random();
            for (int characterPosition = 0; characterPosition < lengthOfPassword; characterPosition++)
            {
                password[characterPosition] = characterSet[random.Next(characterSetLength - 1)];

                bool moreThanTwoIdenticalInARow =
                    characterPosition > MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS
                    && password[characterPosition] == password[characterPosition - 1]
                    && password[characterPosition - 1] == password[characterPosition - 2];

                if (moreThanTwoIdenticalInARow)
                {
                    characterPosition--;
                }
            }

            return string.Join(null, password);
        }

        public static bool PasswordIsValid(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial, bool includeSpaces, string password)
        {
            const string REGEX_LOWERCASE = @"[a-z]";
            const string REGEX_UPPERCASE = @"[A-Z]";
            const string REGEX_NUMERIC = @"[\d]";
            const string REGEX_SPECIAL = @"([!#$%&*@\\])+";
            const string REGEX_SPACE = @"([ ])+";

            bool lowerCaseIsValid = !includeLowercase || (includeLowercase && Regex.IsMatch(password, REGEX_LOWERCASE));
            bool upperCaseIsValid = !includeUppercase || (includeUppercase && Regex.IsMatch(password, REGEX_UPPERCASE));
            bool numericIsValid = !includeNumeric || (includeNumeric && Regex.IsMatch(password, REGEX_NUMERIC));
            bool symbolsAreValid = !includeSpecial || (includeSpecial && Regex.IsMatch(password, REGEX_SPECIAL));
            bool spacesAreValid = !includeSpaces || (includeSpaces && Regex.IsMatch(password, REGEX_SPACE));

            return lowerCaseIsValid && upperCaseIsValid && numericIsValid && symbolsAreValid && spacesAreValid;
        }
    }

    public static class NetWorkWrapper
    {
        public static bool HasInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
