using Microsoft.Extensions.Configuration;

namespace NewsDemo.Common
{
    public class ConfigItems
    {
        public static IConfiguration Configuration { get; set; } = null!;

        #region Default Connection

        public static string ConnectionString => Configuration["Data:DefaultConnection:ConnString"];

        #endregion

        public static string DevelopmentVersion => DateTime.Now.Ticks.ToString();

        public static string CryptographyKey => Configuration["Data:CryptographyKey"];
        public static string SiteUrl => Configuration["Data:SiteUrl"];
        public static bool IsDevelopmentMode => Convert.ToBoolean(Configuration["Data:IsDevelopmentMode"]);
        public static bool IsPwaWorking => Convert.ToBoolean(Configuration["Data:IsPwaWorking"]);
        public static int SessionIdleTimeoutInDay => Convert.ToInt32(Configuration["Data:SessionIdleTimeoutInDay"]);
        public static int ResetPasswordExpiryTimeInSeconds => Convert.ToInt32(Configuration["Data:ResetPasswordExpiryTimeInSeconds"]);

        #region CDN Path details

        public static string CDNUploadDirPath => Convert.ToString(Configuration["Data:CDN:UploadDirPath"]);
        public static string CDNTemplatePath => Convert.ToString(Configuration["Data:CDN:TemplatePath"]);
        public static string CDNContentAbsolutePath => Convert.ToString(Configuration["Data:CDN:ContentAbsolutePath"]);

        #endregion

        #region Versioning

        public static string CssVersion => Convert.ToString(Configuration["Data:Versioning:CssVersion"]);
        public static string JsVersion => Convert.ToString(Configuration["Data:Versioning:JsVersion"]);

        #endregion

        #region Default details

        public static int DefaultPageSize => Convert.ToInt32(Configuration["Data:Default:PageSize"]);
        public static int DefaultPageNumber => Convert.ToInt32(Configuration["Data:Default:PageNumber"]);
        public static int CreatedBy => Convert.ToInt32(Configuration["Data:Default:CreatedBy"]);
        public static int ModifiedBy => Convert.ToInt32(Configuration["Data:Default:ModifiedBy"]);
        public static int DeletedBy => Convert.ToInt32(Configuration["Data:Default:DeletedBy"]);
        public static string DefaultPasswordForCreateUser => Convert.ToString(Configuration["Data:Default:PasswordForCreateUser"]);
        public static string DefaultImagePath => Convert.ToString(Configuration["Data:Default:ImagePath"]);

        #endregion

        #region Caching details

        public static bool IsCacheActive => Convert.ToBoolean(Configuration["Data:Caching:IsCacheActive"]);
        public static bool CacheWithRemoveOtherSite => Convert.ToBoolean(Configuration["Data:Caching:CacheWithRemoveOtherSite"]);
        public static bool IsLockCustomCacheMethods => Convert.ToBoolean(Configuration["Data:Caching:IsLockCustomCacheMethods"]);
        public static bool CacheInSleepWhileRequestIsInProgress => Convert.ToBoolean(Configuration["Data:Caching:CacheInSleepWhileRequestIsInProgress"]);

        #endregion

        #region XSS / DDOS prevention details

        public static bool DDOS_FilterXssRequests => Convert.ToBoolean(Configuration["Data:DDOS:FilterXssRequests"]);
        public static int DDOS_BannedRequestCount => Convert.ToInt32(Configuration["Data:DDOS:BannedRequestCount"]);
        public static int DDOS_ReductionInterval => Convert.ToInt32(Configuration["Data:DDOS:ReductionInterval"]);
        public static int DDOS_ReAccessInMinutes => Convert.ToInt32(Configuration["Data:DDOS:ReAccessInMinutes"]);

        #endregion

        #region Email Configuration details

        public static bool IsSendEmail => Convert.ToBoolean(Configuration["Data:Email:IsSendEmail"]);
        public static string SMTPHost => Convert.ToString(Configuration["Data:Email:SMTPHost"]);
        public static int SMTPPort => Convert.ToInt32(Configuration["Data:Email:SMTPPort"]);
        public static bool IsSMTPEnableSsl => Convert.ToBoolean(Configuration["Data:Email:IsSMTPEnableSsl"]);
        public static string DisplayEmailSender => Convert.ToString(Configuration["Data:Email:DisplayEmailSender"]);
        public static string EmailSender => Convert.ToString(Configuration["Data:Email:Sender"]);
        public static string EmailPassword => Convert.ToString(Configuration["Data:Email:Password"]);

        #endregion

        #region SMS Configuration details

        public static bool IsSendSMS => Convert.ToBoolean(Configuration["Data:SMS:IsSendSMS"]);
        public static string SMSAccountSId => Convert.ToString(Configuration["Data:SMS:AccountSId"]);
        public static string SMSAuthToken => Convert.ToString(Configuration["Data:SMS:AuthToken"]);
        public static string SMSFromNumber => Convert.ToString(Configuration["Data:SMS:FromNumber"]);
        public static string SMSCountryCode => Convert.ToString(Configuration["Data:SMS:CountryCode"]);

        #endregion        

        #region NewsDemo

        public static int NewsDemoNumberLength => Convert.ToInt32(Configuration["Data:NewsDemo:NumberLength"]);
        public static int AdminMaxCardCanBeGenerate => Convert.ToInt32(Configuration["Data:NewsDemo:AdminMaxCardCanBeGenerate"]);
        public static int PartnerDefaultPhysicalCardRequest => Convert.ToInt32(Configuration["Data:NewsDemo:PartnerDefaultPhysicalCardRequest"]);
        public static double NewsDemoProcessingFee => Convert.ToDouble(Configuration["Data:NewsDemo:ProcessingFee"]);
        public static double NewsDemoPhysicalCardMailingFee => Convert.ToDouble(Configuration["Data:NewsDemo:PhysicalCardMailingFee"]);
        public static decimal DefaultNewsDemoPurchaseValue => Convert.ToDecimal(Configuration["Data:NewsDemo:DefaultPurchaseValue"]);
        public static decimal DefaultNewsDemoMinimumValue => Convert.ToDecimal(Configuration["Data:NewsDemo:MinumumPurchaseValue"]);
        public static int UnAssignPhysicalCardInventoryAlertCount => Convert.ToInt32(Configuration["Data:NewsDemo:UnAssignPhysicalNewsDemoAlertCount"]);

        #endregion

        #region Matrix

        public static decimal ShopkeeperRedeemPercentage => Convert.ToDecimal(Configuration["Data:Matrix:ShopkeeperRedeemPercentage"]);
        public static decimal CarwashRedeemPercentage => Convert.ToDecimal(Configuration["Data:Matrix:CarwashRedeemPercentage"]);
        public static double ActivateNowShopkeeperProfit => Convert.ToDouble(Configuration["Data:Matrix:ShopkeeperProfit"]);
        public static double ActivateNowCarwashProfit => Convert.ToDouble(Configuration["Data:Matrix:CarwashProfit"]);

        #endregion

        #region Payment Gateway

        public static string StripeConfigurationApiKeySecretKey => Convert.ToString(Configuration["Data:PaymentGateway:StripeConfigurationApiKeySecretKey"]);

        public static string CheckBookAPIKey => Convert.ToString(Configuration["Data:PaymentGateway:CheckBook:APIKey"]);
        public static string CheckBookAPISecret => Convert.ToString(Configuration["Data:PaymentGateway:CheckBook:APISecret"]);
        public static string CheckBookApiUri => Convert.ToString(Configuration["Data:PaymentGateway:CheckBook:ApiUri"]);
        public static string CheckBookDebitBankAccountId => Convert.ToString(Configuration["Data:PaymentGateway:CheckBook:DebitBankAccountId"]);
        public static bool IsDebitAccountInfomationRequired => Convert.ToBoolean(Configuration["Data:PaymentGateway:CheckBook:IsDebitAccountInfomationRequired"]);
        #endregion

        #region AWS

        public static string AWS_BucketName => Convert.ToString(Configuration["Data:AWS:BucketName"]);
        public static string AWS_BucketURL => Convert.ToString(Configuration["Data:AWS:BucketURL"]);
        public static string AWS_AccessKey => Convert.ToString(Configuration["Data:AWS:AccessKey"]);
        public static string AWS_SecretKey => Convert.ToString(Configuration["Data:AWS:SecretKey"]);
        public static string AWS_TempFolderName => Convert.ToString(Configuration["Data:AWS:TempFolderName"]);
        public static string AWS_UserFolderName => Convert.ToString(Configuration["Data:AWS:UserFolderName"]);
        public static string AWS_NewsDemoFolderName => Convert.ToString(Configuration["Data:AWS:NewsDemoFolderName"]);
        public static string AWS_ShopKeeperFolderName => Convert.ToString(Configuration["Data:AWS:ShopKeeperFolderName"]);
        public static int AWS_MultiPartFileSize => Convert.ToInt32(Configuration["Data:AWS:MultiPartFileSize"]);

        #endregion

        #region Contact Information

        public static string ContactInformation_Address1 => Convert.ToString(Configuration["Data:ContactInformation:Address1"]);
        public static string ContactInformation_Address2 => Convert.ToString(Configuration["Data:ContactInformation:Address2"]);
        public static string ContactInformation_Address3 => Convert.ToString(Configuration["Data:ContactInformation:Address3"]);
        public static string ContactInformation_PhoneNumber => Convert.ToString(Configuration["Data:ContactInformation:PhoneNumber"]);
        public static string ContactInformation_PhysicalCardPurchaseSupportNumber => Convert.ToString(Configuration["Data:ContactInformation:PhysicalCardPurchaseSupportNumber"]);
        public static string ContactInformation_Email => Convert.ToString(Configuration["Data:ContactInformation:Email"]);
        public static string ContactInformation_Facebook => Convert.ToString(Configuration["Data:ContactInformation:Facebook"]);
        public static string ContactInformation_Twitter => Convert.ToString(Configuration["Data:ContactInformation:Twitter"]);
        public static string ContactInformation_YouTube => Convert.ToString(Configuration["Data:ContactInformation:YouTube"]);
        public static string ContactInformation_Instagram => Convert.ToString(Configuration["Data:ContactInformation:Instagram"]);

        #endregion

        #region ReCaptcha

        public static string ReCaptcha_SiteKey => Convert.ToString(Configuration["Data:ReCaptcha:SiteKey"]);
        public static string ReCaptcha_SecretKey => Convert.ToString(Configuration["Data:ReCaptcha:SecretKey"]);
        public static string ReCaptcha_VerificationUrl => Convert.ToString(Configuration["Data:ReCaptcha:VerificationUrl"]);

        #endregion

        #region Subject Messages

        public static string SubjectMessages_Otp => Convert.ToString(Configuration["Data:SubjectMessages:Otp"]);
        public static string SubjectMessages_ForgotPasswordSendLink => Convert.ToString(Configuration["Data:SubjectMessages:ForgotPasswordSendLink"]);
        public static string SubjectMessages_AccountCreated => Convert.ToString(Configuration["Data:SubjectMessages:AccountCreated"]);
        public static string SubjectMessages_NewsDemoPurchased => Convert.ToString(Configuration["Data:SubjectMessages:NewsDemoPurchased"]);
        public static string SubjectMessages_SupportEmailSubjectPhysicalCardPurchase => Convert.ToString(Configuration["Data:SubjectMessages:SupportEmailSubjectPhysicalCardPurchase"]);
        public static string SubjectMessages_SupportEmailSubjectNewsDemoCheckBalance => Convert.ToString(Configuration["Data:SubjectMessages:SupportEmailSubjectNewsDemoCheckBalance"]);
        public static string SubjectMessages_SupportEmailSubjectBulkPhysicalCardRequest => Convert.ToString(Configuration["Data:SubjectMessages:SupportEmailSubjectBulkPhysicalCardRequest"]);
        public static string SubjectMessages_SupportEmailSubjectUnAssignPhysicalNewsDemoLessInventoryAlert => Convert.ToString(Configuration["Data:SubjectMessages:SupportEmailSubjectUnAssignPhysicalNewsDemoLessInventoryAlert"]);
        public static string CheckbookAccountCreated => Convert.ToString(Configuration["Data:SubjectMessages:CheckbookAccountCreated"]);
        public static string SubjectMessages_VirtualCreditCardRequestAlert => Convert.ToString(Configuration["Data:SubjectMessages:SupportSmsEmailSubjectVirtualCreditCardRequest"]);


        #endregion

        #region Sms Messages

        public static string LogInOTPTemplate => Convert.ToString(Configuration["Data:SmsMessages:LogInOTPTemplate"]);
        public static string RegisterOTPTemplate => Convert.ToString(Configuration["Data:SmsMessages:RegisterOTPTemplate"]);
        public static string RedeemAmountOTPTemplate => Convert.ToString(Configuration["Data:SmsMessages:RedeemAmountOTPTemplate"]);
        public static string ForgotPasswordTemplate => Convert.ToString(Configuration["Data:SmsMessages:ForgotPasswordTemplate"]);
        public static string AdminCreateNewShopKeeperTemplate => Convert.ToString(Configuration["Data:SmsMessages:AdminCreateNewShopKeeperTemplate"]);
        public static string PurchasedNewsDemoReceiverTemplate => Convert.ToString(Configuration["Data:SmsMessages:PurchasedNewsDemoReceiverTemplate"]);
        public static string PurchasedNewsDemoSenderTemplate => Convert.ToString(Configuration["Data:SmsMessages:PurchasedNewsDemoSenderTemplate"]);
        public static string PhysicalCardPurchaseSupportTemplate => Convert.ToString(Configuration["Data:SmsMessages:PhysicalCardPurchaseSupportTemplate"]);
        public static string PhysicalCardPurchaserTemplate => Convert.ToString(Configuration["Data:SmsMessages:PhysicalCardPurchaserTemplate"]);
        public static string NewsDemoCheckBalanceSupportTemplate => Convert.ToString(Configuration["Data:SmsMessages:NewsDemoCheckBalanceSupportTemplate"]);
        public static string PhysicalNewsDemoLessInventorySupportTemplate => Convert.ToString(Configuration["Data:SmsMessages:PhysicalNewsDemoLessInventorySupportTemplate"]);
        public static string PartnerCreateVirtualCard => Convert.ToString(Configuration["Data:SmsMessages:PartnerCreateVirtualCard"]);
        public static string VirtualCreditCardRequestSupportTemplate => Convert.ToString(Configuration["Data:SmsMessages:VirtualCreditCardRequestSupportTemplate"]);
        public static string PurchasedNewsDemoSupportTemplate => Convert.ToString(Configuration["Data:SmsMessages:PurchasedNewsDemoSupportTemplate"]);
        public static string ActivateNewsDemoSupportTemplate => Convert.ToString(Configuration["Data:SmsMessages:ActivateNewsDemoSupportTemplate"]);
        public static string APIServiceRegisterOTPTemplate => Convert.ToString(Configuration["Data:SmsMessages:APIServiceRegisterOTPTemplate"]);
        public static string APIServiceRegenerateTokenOTPTemplate => Convert.ToString(Configuration["Data:SmsMessages:APIServiceRegenerateTokenOTPTemplate"]);
        #endregion

        #region Gift Card History Detail Messages

        public static string NewsDemoHistoryDetailMessages_PaymentInprogress => Convert.ToString(Configuration["Data:NewsDemoHistoryDetailMessages:PaymentInprogress"]);
        public static string NewsDemoHistoryDetailMessages_PaymentApproved => Convert.ToString(Configuration["Data:NewsDemoHistoryDetailMessages:PaymentApproved"]);
        public static string NewsDemoHistoryDetailMessages_PaymentCanceled => Convert.ToString(Configuration["Data:NewsDemoHistoryDetailMessages:PaymentCanceled"]);
        public static string NewsDemoHistoryDetailMessages_UploadFile => Convert.ToString(Configuration["Data:NewsDemoHistoryDetailMessages:UploadFile"]);
        public static string NewsDemoHistoryDetailMessages_Update => Convert.ToString(Configuration["Data:NewsDemoHistoryDetailMessages:Update"]);
        public static string NewsDemoHistoryDetailMessages_ActivateNewsDemo => Convert.ToString(Configuration["Data:NewsDemoHistoryDetailMessages:ActivateNewsDemo"]);
        public static string NewsDemoHistoryDetailMessages_ActivateNewsDemoUserInfo => Convert.ToString(Configuration["Data:NewsDemoHistoryDetailMessages:ActivateNewsDemoUserInfo"]);
        public static string NewsDemoHistoryDetailMessages_BuyNewsDemoInfo => Convert.ToString(Configuration["Data:NewsDemoHistoryDetailMessages:BuyNewsDemoInfo"]);
        public static string NewsDemoHistoryDetailMessages_BuyPhysicalNewsDemoRequestInfo => Convert.ToString(Configuration["Data:NewsDemoHistoryDetailMessages:BuyPhysicalNewsDemoRequestInfo"]);
        public static string NewsDemoHistoryDetailMessages_AssignRequestedPhysicalNewsDemoInfo => Convert.ToString(Configuration["Data:NewsDemoHistoryDetailMessages:AssignRequestedPhysicalNewsDemoInfo"]);
        public static string VitualCardCreated => Convert.ToString(Configuration["Data:NewsDemoHistoryDetailMessages:VitualCardCreated"]);

        #endregion

        #region Static Message

        public static string StaticMessage_UserExistWithEmailErrMsg => Convert.ToString(Configuration["Data:StaticMessage:UserExistWithEmailErrMsg"]);
        public static string StaticMessage_UserExistWithPhoneNoErrMsg => Convert.ToString(Configuration["Data:StaticMessage:UserExistWithPhoneNoErrMsg"]);

        #endregion

        #region Error Messages
        public static string NotFound => Convert.ToString(Configuration["Data:ErrorMessages:NotFound"]);
        public static string NotExist => Convert.ToString(Configuration["Data:ErrorMessages:NotExist"]);
        public static string NotRegisterd => Convert.ToString(Configuration["Data:ErrorMessages:NotRegisterd"]);

        public static string EmailOrPhoneNoInvalid => Convert.ToString(Configuration["Data:ErrorMessages:EmailOrPhoneNoInvalid"]);
        public static string EmailOrCellPhoneNotRegistered => Convert.ToString(Configuration["Data:ErrorMessages:EmailOrCellPhoneNotRegistered"]);
        public static string AccountInactive => Convert.ToString(Configuration["Data:ErrorMessages:AccountInactive"]);
        public static string LoginDetailsInvalid => Convert.ToString(Configuration["Data:ErrorMessages:LoginDetailsInvalid"]);
        public static string EnterRequiredValue => Convert.ToString(Configuration["Data:ErrorMessages:EnterRequiredValue"]);

        public static string ExceptionInMethod => Convert.ToString(Configuration["Data:ErrorMessages:ExceptionInMethod"]);

        public static string PasswordRestLinkExpired => Convert.ToString(Configuration["Data:ErrorMessages:PasswordRestLinkExpired"]);

        public static string NoPartnerFoundWithThisUniqueURL => Convert.ToString(Configuration["Data:ErrorMessages:NoPartnerFoundWithThisUniqueURL"]);
        public static string EnterRequiredDetails => Convert.ToString(Configuration["Data:ErrorMessages:EnterRequiredDetails"]);
        public static string EnterEmailOrCellNo => Convert.ToString(Configuration["Data:ErrorMessages:EnterEmailOrCellNo"]);
        public static string CardInactiveOrSuspended => Convert.ToString(Configuration["Data:ErrorMessages:CardInactiveOrSuspended"]);
        public static string TokenNotFound => Convert.ToString(Configuration["Data:ErrorMessages:TokenNotFound"]);
        public static string reCaptchaTokenInvalid => Convert.ToString(Configuration["Data:ErrorMessages:reCaptchaTokenInvalid"]);

        public static string NewsDemoDetailsNotValid => Convert.ToString(Configuration["Data:ErrorMessages:NewsDemoDetailsNotValid"]);
        public static string CodeInvalid => Convert.ToString(Configuration["Data:ErrorMessages:CodeInvalid"]);
        public static string BalanceInsufficient => Convert.ToString(Configuration["Data:ErrorMessages:BalanceInsufficient"]);
        public static string DataFoundInvalid => Convert.ToString(Configuration["Data:ErrorMessages:DataFoundInvalid"]);
        public static string BatchNoOrQuantityNotFound => Convert.ToString(Configuration["Data:ErrorMessages:BatchNoOrQuantityNotFound"]);
        public static string UserCannotAccessThisAction => Convert.ToString(Configuration["Data:ErrorMessages:UserCannotAccessThisAction"]);


        public static string UserNotExist => Convert.ToString(Configuration["Data:ErrorMessages:UserNotExist"]);
        public static string EnterValidData => Convert.ToString(Configuration["Data:ErrorMessages:EnterValidData"]);
        public static string UniqueUrlIsAlreadyInUsed => Convert.ToString(Configuration["Data:ErrorMessages:UniqueUrlIsAlreadyInUsed"]);
        public static string ConfirmPasswordNotMatch => Convert.ToString(Configuration["Data:ErrorMessages:ConfirmPasswordNotMatch"]);
        public static string CurrentPasswordInvalid => Convert.ToString(Configuration["Data:ErrorMessages:CurrentPasswordInvalid"]);
        public static string FieldsOneOrMoreEmpty => Convert.ToString(Configuration["Data:ErrorMessages:FieldsOneOrMoreEmpty"]);
        public static string BalanceWithdrawalRequestInvalid => Convert.ToString(Configuration["Data:ErrorMessages:BalanceWithdrawalRequestInvalid"]);

        public static string SitemapGenerationError => Convert.ToString(Configuration["Data:ErrorMessages:SitemapGenerationError"]);

        public static string PaymentTransactionNotAdded => Convert.ToString(Configuration["Data:ErrorMessages:PaymentTransactionNotAdded"]);

        public static string UserAlreadyExist => Convert.ToString(Configuration["Data:ErrorMessages:UserAlreadyExist"]);
        public static string EnterValidNewsDemoNumber => Convert.ToString(Configuration["Data:ErrorMessages:EnterValidNewsDemoNumber"]);
        public static string EnterInActiveNewsDemoNumber => Convert.ToString(Configuration["Data:ErrorMessages:EnterInActiveNewsDemoNumber"]);
        public static string UserNotCreated => Convert.ToString(Configuration["Data:ErrorMessages:UserNotCreated"]);
        public static string UserInformationInvalid => Convert.ToString(Configuration["Data:ErrorMessages:UserInformationInvalid"]);
        public static string PartnerBulkImportNoFilePresent => Convert.ToString(Configuration["Data:ErrorMessages:PartnerBulkImportNoFilePresent"]);
        public static string PartnerBulkImportNoRecordsPresent => Convert.ToString(Configuration["Data:ErrorMessages:PartnerBulkImportNoRecordsPresent"]);
        public static string PartnerBulkImportMissingColumns => Convert.ToString(Configuration["Data:ErrorMessages:PartnerBulkImportMissingColumns"]);
        public static string VirtualCardRequestAlreadySent => Convert.ToString(Configuration["Data:ErrorMessages:VirtualCardRequestAlreadySent"]);
        public static string HeaderNotExist => Convert.ToString(Configuration["Data:ErrorMessages:HeaderNotExist"]);
        public static string AuthorizationHeaderIsIncorrect => Convert.ToString(Configuration["Data:ErrorMessages:AuthorizationHeaderIsIncorrect"]);
        public static string TokenIsIncorrect => Convert.ToString(Configuration["Data:ErrorMessages:TokenIsIncorrect"]);

        #endregion

        #region Success Messages
        public static string Success => Convert.ToString(Configuration["Data:SuccessMessage:Success"]);
        public static string PasswordUpdatedMessage => Convert.ToString(Configuration["Data:SuccessMessage:PasswordUpdatedMessage"]);
        public static string DetailsUpdatedMessage => Convert.ToString(Configuration["Data:SuccessMessage:DetailsUpdatedMessage"]);
        public static string SuccessMsg => Convert.ToString(Configuration["Data:SuccessMessage:SuccessMsg"]);
        public static string BankDetailSuccessMsg => Convert.ToString(Configuration["Data:SuccessMessage:BankDetailSuccessMsg"]);
        public static string NewsDemoBulkRequestSuccessMsg => Convert.ToString(Configuration["Data:SuccessMessage:NewsDemoBulkRequestSuccessMsg"]);
        public static string BalanceWithdrawalRequestSuccessMsg => Convert.ToString(Configuration["Data:SuccessMessage:BalanceWithdrawalRequestSuccessMsg"]);
        public static string NewsDemoAssignToPartnerSuccessMsg => Convert.ToString(Configuration["Data:SuccessMessage:NewsDemoAssignToPartnerSuccessMsg"]);
        public static string NewsDemoActivitedSuccessMsg => Convert.ToString(Configuration["Data:SuccessMessage:NewsDemoActivitedSuccessMsg"]);
        public static string AchPaymentSuccessMsg => Convert.ToString(Configuration["Data:SuccessMessage:AchPaymentSuccessMsg"]);
        public static string PhysicalNewsDemoRequestSuccessMsg => Convert.ToString(Configuration["Data:SuccessMessage:PhysicalNewsDemoRequestSuccessMsg"]);
        public static string PartnerBulkImportSuccessMsg => Convert.ToString(Configuration["Data:SuccessMessage:PartnerBulkImportSuccessMsg"]);
        #endregion

        #region Sample Excel File Paths
        public static string SampleExcelFile_PartnerBulkInsertFilePath => Convert.ToString(Configuration["Data:SampleExcelFile:PartnerBulkInsertFilePath"]);
        #endregion

        #region Partner Bulk Import
        public static string FileRow_FirstName => Convert.ToString(Configuration["Data:PartnerBulkImport:FileRowName:FirstName"]);
        public static string FileRow_LastName => Convert.ToString(Configuration["Data:PartnerBulkImport:FileRowName:LastName"]);
        public static string FileRow_PartnerEmailAddress => Convert.ToString(Configuration["Data:PartnerBulkImport:FileRowName:PartnerEmailAddress"]);
        public static string FileRow_PartnerCellNumber => Convert.ToString(Configuration["Data:PartnerBulkImport:FileRowName:PartnerCellNumber"]);
        public static string FileRow_CarwashName => Convert.ToString(Configuration["Data:PartnerBulkImport:FileRowName:CarwashName"]);
        public static string FileRow_CarwashAddress => Convert.ToString(Configuration["Data:PartnerBulkImport:FileRowName:CarwashAddress"]);
        public static string FileRow_City => Convert.ToString(Configuration["Data:PartnerBulkImport:FileRowName:City"]);
        public static string FileRow_Zipcode => Convert.ToString(Configuration["Data:PartnerBulkImport:FileRowName:Zipcode"]);
        public static string FileRow_AlternateCellNumber => Convert.ToString(Configuration["Data:PartnerBulkImport:FileRowName:AlternateCellNumber"]);
        public static string FileRow_BusinessTelephoneNumber => Convert.ToString(Configuration["Data:PartnerBulkImport:FileRowName:BusinessTelephoneNumber"]);
        public static string ImportErrMsg_MandatoryFieldsMsg => Convert.ToString(Configuration["Data:PartnerBulkImport:ErrorMessages:MandatoryFieldsMsg"]);
        public static string ImportErrMsg_InvalidEmailMsg => Convert.ToString(Configuration["Data:PartnerBulkImport:ErrorMessages:InvalidEmailMsg"]);
        public static string ImportErrMsg_InvalidNumberLenghtMsg => Convert.ToString(Configuration["Data:PartnerBulkImport:ErrorMessages:InvalidNumberLenghtMsg"]);
        public static string ImportErrMsg_DuplicateFieldMsg => Convert.ToString(Configuration["Data:PartnerBulkImport:ErrorMessages:DuplicateFieldMsg"]);
        public static string PartnerBulkImport_ExcelFileRowLimitMsg => Convert.ToString(Configuration["Data:PartnerBulkImport:ExcelFileRowLimitMsg"]);
        public static int PartnerBulkImport_ExcelFileRowLimit => Convert.ToInt32(Configuration["Data:PartnerBulkImport:ExcelFileRowLimit"]);
        #endregion

        #region Common Messages
        public static string NewsDemoSendOnSceduleDateTime => Convert.ToString(Configuration["Data:CommonMessage:NewsDemoSendOnSceduleDateTime"]);
        public static string NewsDemoGenerated => Convert.ToString(Configuration["Data:CommonMessage:NewsDemoGenerated"]);
        public static string NewsDemoBuldRequestAdded => Convert.ToString(Configuration["Data:CommonMessage:NewsDemoBuldRequestAdded"]);
        public static string LinkSentToRegisterdEmailOrCellPhone => Convert.ToString(Configuration["Data:CommonMessage:LinkSentToRegisterdEmailOrCellPhone"]);
        public static string SMSNotificationAuthorizationMessage => Convert.ToString(Configuration["Data:CommonMessage:SMSNotificationAuthorizationMessage"]);

        #endregion

        #region JWT
        public static string JwtKey => Convert.ToString(Configuration["Data:Jwt:Key"]);
        public static string JwtIssuer => Convert.ToString(Configuration["Data:Jwt:Issuer"]);
        public static string JwtAudience => Convert.ToString(Configuration["Data:Jwt:Audience"]);
        public static string JwtSubject => Convert.ToString(Configuration["Data:Jwt:Subject"]);
        public static string NewsDemoSecretAnonymousKey => Convert.ToString(Configuration["Data:NewsDemoSecretAnonymousKey"]);
        public static string NewsDemoSecretKey => Convert.ToString(Configuration["Data:NewsDemoSecretKey"]);
        #endregion
    }
}
