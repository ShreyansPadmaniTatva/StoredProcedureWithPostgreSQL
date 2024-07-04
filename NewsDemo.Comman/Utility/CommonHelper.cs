using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace NewsDemo.Common
{
    public static class CommonHelper
    {
        public static decimal? StringToDecimal(string numberString)
        {
            if (!string.IsNullOrEmpty(numberString))
            {
                if (decimal.TryParse(numberString, out decimal d))
                    return d;
                return null;
            }
            return null;
        }

        public static float? StringToDecimalNull(string numberString)
        {
            if (!string.IsNullOrEmpty(numberString))
            {
                if (float.TryParse(numberString, out float d))
                    return d;
                return null;
            }
            return null;
        }

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            var IsValid = Regex.IsMatch(phoneNumber, @"^\d{10}$");
            return IsValid;
        }

        public static string? DecimalToString(decimal? number)
        {
            string? value = null;

            if (number != 0)
            {
                value = number?.ToString("n2", new CultureInfo("en-US"));
            }

            return value;
        }

        public static string DisplayDateTime(DateTime dateTime, bool isDisplayTime = false)
        {
            if (dateTime == DateTime.MinValue)
                return "";

            if (isDisplayTime)
                return dateTime.ToString("MM-dd-yyyy hh:mm tt", CultureInfo.InvariantCulture);

            return dateTime.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
        }

        public static string GetTemplatefromEnum(int templateEnum)
        {
            if (templateEnum == Enums.EmailSmsTemplate.Registartion.GetHashCode())
            {
                return Convert.ToString(ConfigItems.RegisterOTPTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.Login.GetHashCode())
            {
                return Convert.ToString(ConfigItems.LogInOTPTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.ForgotPassword.GetHashCode())
            {
                return Convert.ToString(ConfigItems.ForgotPasswordTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.RedeemAmountOtp.GetHashCode())
            {
                return Convert.ToString(ConfigItems.RedeemAmountOTPTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.AdminCreateNewShopKeeper.GetHashCode())
            {
                return Convert.ToString(ConfigItems.AdminCreateNewShopKeeperTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.PurchasedNewsDemoReceiver.GetHashCode())
            {
                return Convert.ToString(ConfigItems.PurchasedNewsDemoReceiverTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.PurchasedNewsDemoSender.GetHashCode())
            {
                return Convert.ToString(ConfigItems.PurchasedNewsDemoSenderTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.SupportPhysicalCardPurchase.GetHashCode())
            {
                return Convert.ToString(ConfigItems.PhysicalCardPurchaseSupportTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.SupportNewsDemoCheckBalance.GetHashCode())
            {
                return Convert.ToString(ConfigItems.NewsDemoCheckBalanceSupportTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.SupportPhysicalCardLessInventory.GetHashCode())
            {
                return Convert.ToString(ConfigItems.PhysicalNewsDemoLessInventorySupportTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.PartnerCreateVirtualCard.GetHashCode())
            {
                return Convert.ToString(ConfigItems.PartnerCreateVirtualCard);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.VirtualCreditCardRequest.GetHashCode())
            {
                return Convert.ToString(ConfigItems.VirtualCreditCardRequestSupportTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.SupportNewsDemoPurchase.GetHashCode())
            {
                return Convert.ToString(ConfigItems.PurchasedNewsDemoSupportTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.SupportActivateNewsDemo.GetHashCode())
            {
                return Convert.ToString(ConfigItems.ActivateNewsDemoSupportTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.ApiRegistration.GetHashCode())
            {
                return Convert.ToString(ConfigItems.APIServiceRegisterOTPTemplate);
            }
            else if (templateEnum == Enums.EmailSmsTemplate.ApiTokenChange.GetHashCode())
            {
                return Convert.ToString(ConfigItems.APIServiceRegenerateTokenOTPTemplate);
            }
            else
            {
                return String.Empty;
            }
        }

        public static string CalculateSignature(string timestampString)
        {
            string data = $"{timestampString}-{"NewsDemoSecretKey"}";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(bytes);
            string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hashString;
        }

        public static bool VerifySignature(string timestampString, string signature)
        {
            string expectedSignature = CalculateSignature(timestampString);
            return signature == expectedSignature;
        }

        public static string GetExtenssionAndBase64(string image)
        {
            string extenssion = "";
            if (image != "")
            {
                if (image.Contains("data:image/jpeg;base64,"))
                {
                    image = image.Replace("data:image/jpeg;base64,", "").Replace(" ", "+");
                    extenssion = ".jpeg";
                }
                if (image.Contains("data:image/jpg;base64,"))
                {
                    image = image.Replace("data:image/jpg;base64,", "").Replace(" ", "+");
                    extenssion = ".jpg";
                }
                if (image.Contains("data:image/png;base64,"))
                {
                    image = image.Replace("data:image/png;base64,", "").Replace(" ", "+");
                    extenssion = ".png";
                }
                if (image.Contains("data:image/gif;base64,"))
                {
                    image = image.Replace("data:image/gif;base64,", "").Replace(" ", "+");
                    extenssion = ".gif";
                }
                if (image.Contains("data:image/bmp;base64,"))
                {
                    image = image.Replace("data:image/bmp;base64,", "").Replace(" ", "+");
                    extenssion = ".bmp";
                }

            }
            return image + extenssion;
        }

        public static int GenerateOTP(int otpLength = 4)
        {
            Random random = new Random();
            int min = (int)Math.Pow(10, otpLength - 1);
            int max = (int)Math.Pow(10, otpLength) - 1;

            return random.Next(min, max);
        }

        public static string GetFilterPropertyValue(string filterObj, string key)
        {
            string value = string.Empty;
            //var result = JsonSerializer.Deserialize<List<SelectListItem>>(filterObj);
            //if (result != null && result.Count() > 0)
            //{
            //    foreach (var item in result)
            //    {
            //        if (item.Text.Equals(key))
            //            value = item.Value;
            //    }
            //}
            return value;
        }

        public static string GetUserType(int userType)
        {
            if (userType == Enums.UserType.ShopKeeper.GetHashCode())
                return "Partner";
            else if (userType == Enums.UserType.EndUser.GetHashCode())
                return "Customer";
            else if (userType == Enums.UserType.SuperAdmin.GetHashCode())
                return "Super Admin";
            else if (userType == Enums.UserType.SubAdmin.GetHashCode())
                return "Sub Admin";
            else if (userType == Enums.UserType.ApiService.GetHashCode())
                return "Api Service";

            return "";
        }

        public static string GetNewsDemoNumberString(string NewsDemoNumber)
        {
            if (string.IsNullOrEmpty(NewsDemoNumber) == false && NewsDemoNumber.Length == 16)
            {
                var f4 = NewsDemoNumber.Substring(0, 4);
                var f8 = f4 + " " + NewsDemoNumber.Substring(4, 4);
                var f12 = f8 + " " + NewsDemoNumber.Substring(8, 4);
                var f16 = f12 + " " + NewsDemoNumber.Substring(12, 4);

                return f16;
            }

            return NewsDemoNumber;
        }

        public static string GetTransactionType(int? transactionType)
        {
            if (transactionType == Enums.TransactionType.Purchase.GetHashCode())
                return "Purchase";
            else if (transactionType == Enums.TransactionType.Credit.GetHashCode())
                return "Credit";
            else if (transactionType == Enums.TransactionType.Debit.GetHashCode())
                return "Debit";
            else if (transactionType == Enums.TransactionType.CreditForActivation.GetHashCode())
                return "Credit for activation";
            else if (transactionType == Enums.TransactionType.CreditForSellCard.GetHashCode())
                return "Credit for sell card";

            return "";
        }

        public static string GetBankAccountTypeDescription(int? bankAccountType)
        {
            if (bankAccountType == Enums.BankAccountType.Checking.GetHashCode())
                return "CHECKING";
            else if (bankAccountType == Enums.BankAccountType.Business.GetHashCode())
                return "BUSINESS";
            else if (bankAccountType == Enums.BankAccountType.Savings.GetHashCode())
                return "SAVINGS";
            return "";
        }

        public static string GetImageThumbnailPathName(string filePath, int width, int height = -1, bool isLarge = false)
        {
            var fileInfo = new FileInfo(filePath);
            string fileName = fileInfo.Name;

            var extension = fileInfo.Extension;
            string orignalextension = extension.ToLower();

            // verify extension
            string lExtension = extension.ToLower();
            if (lExtension != ".jpg" && lExtension != ".jpeg" && lExtension != ".png" && lExtension != ".gif" && lExtension != ".bmp")
                return "";

            if (lExtension != ".jpg" && lExtension != ".jpeg")
                orignalextension = extension.ToLower();

            // image thumb name
            string thumbName = fileName.Replace(extension, "") + "_thumb_" + width + (height != -1 ? "_" + height : "") + orignalextension;
            string thumbFilePath = filePath.Replace(fileName, thumbName);

            return thumbFilePath;
        }

        public static string GetCardHistoryOperation(int? cardHistoryOperation)
        {
            if (cardHistoryOperation == Enums.CardHistoryOperation.Insert.GetHashCode())
                return "Insert";
            else if (cardHistoryOperation == Enums.CardHistoryOperation.Update.GetHashCode())
                return "Update";
            else if (cardHistoryOperation == Enums.CardHistoryOperation.Delete.GetHashCode())
                return "Delete";
            else if (cardHistoryOperation == Enums.CardHistoryOperation.PaymentApproved.GetHashCode())
                return "Payment approved";
            else if (cardHistoryOperation == Enums.CardHistoryOperation.PaymentCanceled.GetHashCode())
                return "Payment canceled";
            return "";
        }

        public static string ToDateTimeString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        public static long ConvertDateToUnixTime(this string dt)
        {
            DateTime dateTime = DateTime.Parse(dt);
            long unixTimestamp = ToUnixTimestamp(dateTime);
            return unixTimestamp;
        }

        public static int ToUnixTimestamp(DateTime dateTime)
        {
            return (int)(dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
    }
}
