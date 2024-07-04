﻿using System.ComponentModel;
using System.Reflection;

namespace NewsDemo.Common
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            FieldInfo? fi = enumValue.GetType().GetField(enumValue.ToString());

            if (fi == null)
                return enumValue.ToString();

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return enumValue.ToString();
        }
    }

    public class Enums
    {
        public static string GetEnumDescription(Enum value)
        {
            try
            {
                if (value.GetHashCode() == 0)
                    return "";

                FieldInfo fi = value.GetType().GetField(value.ToString());

                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return value.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string GetEnumDescription<TEnum>(int value)
        {
            return GetEnumDescription((Enum)(object)((TEnum)(object)value));
        }

        public enum ChangeFrequency
        {
            Always,
            Hourly,
            Daily,
            Weekly,
            Monthly,
            Yearly,
            Never
        }

        public enum StatusCode
        {
            Ok = 200,
            BadRequest = 400,
            NotFound = 404, // also use for data not found
            ServerError = 500,
            AccessDenied = 403,
            NotAllowed = 405,
            Conflict = 409,
            Unauthorized = 401
        }

        public enum NewsDemoScheduleType
        {
            SendNow = 1,
            ScehduledDate = 2
        }

        public enum UserCachingTime
        {
            VeryShort = 2,
            SemiShort = 5,
            Short = 10,
            Medium = 30,
            Long = 60,
            SemiLong = 90,
            VeryLong = 180
        }

        public enum UserType
        {
            SuperAdmin = 1,     // Super Admin
            ShopKeeper = 2,     // Carwash / Partner
            EndUser = 3,        // Customer,
            SubAdmin = 4,        // Sub Admin
            ApiService = 5        // API Service User
        }

        public enum UserStatus
        {
            [Description("Active")]
            Active = 1,
            [Description("InActive")]
            InActive = 2,
            [Description("Suspended")]
            Suspended = 3
        }

        public enum EmailSmsTemplate
        {
            Login = 1,
            Registartion = 2,
            ForgotPassword = 3,
            RedeemAmountOtp = 4,
            AdminCreateNewShopKeeper = 5,
            PurchasedNewsDemoReceiver = 6,
            PurchasedNewsDemoSender = 7,
            SupportPhysicalCardPurchase = 8,
            SupportNewsDemoCheckBalance = 9,
            SupportPhysicalCardLessInventory = 10,
            PartnerCreateVirtualCard = 11,
            VirtualCreditCardRequest = 12,
            SupportNewsDemoPurchase = 13,
            SupportActivateNewsDemo = 14,
            ApiRegistration = 15,
            ApiTokenChange = 16
        }
        public enum GridPageSize
        {
            [Description("10")]
            Ten = 10,
            [Description("20")]
            Twenty = 20,
            [Description("30")]
            Thirty = 30,
            [Description("50")]
            Fifty = 50,
            [Description("100")]
            Hundred = 100
        }

        public enum ResizeType
        {
            LongestSide,
            Width,
            Height
        }

        public enum MailType
        {
            DispatchDate = 1,
            DeliveredDate = 2
        }

        public enum CardStatus
        {
            [Description("Active")]
            Active = 1,
            [Description("InActive")]
            InActive = 2,
            [Description("Suspended")]
            Suspended = 3,
            [Description("PaymentInProgress")]
            PaymentInProgress = 4,
            [Description("PaymentCanceled")]
            PaymentCanceled = 5
        }

        public enum BulkCardRequestStatus
        {
            [Description("Requested")]
            Requested = 1,
            [Description("Acknowledge By Admin")]
            AcknowledgeByAdmin = 2,
            [Description("Preparing Gift Card")]
            PreparingNewsDemo = 3,
            [Description("Shipped")]
            Shipped = 4,
            [Description("Completed")]
            Completed = 5,
            [Description("Rejected")]
            Rejected = 6,
            [Description("Cancelled")]
            Cancelled = 7,
        }

        public enum ShopKeeperBalanceWithdrawalRequestStatus
        {
            [Description("Requested")]
            Requested = 1,
            [Description("Cancel")]
            Cancel = 2,
            [Description("Approve")]
            Approve = 3,
            [Description("Reject")]
            Reject = 4
        }

        public enum TransactionType
        {
            [Description("Purchase")]
            Purchase = 1,
            [Description("Credit")]
            Credit = 2,
            [Description("Debit")]
            Debit = 3,
            [Description("Credit For Activation")]
            CreditForActivation = 4,
            [Description("Credit For Sell Card")]
            CreditForSellCard = 5
        }

        public enum NewsDemoType
        {
            Digital = 1,
            Physical = 2
        }

        public enum NewsDemoSendMethod
        {
            ByEmail = 1,
            ByPhone = 2
        }

        public enum PhysicalNewsDemoType
        {
            Anonymous = 1,
            AddReceipient = 2
        }

        public enum PaymentMethod
        {
            Stripe = 1
        }

        public enum PaymentStatus
        {
            Initiate = 1,
            Approved = 2,
            Canceled = 3
        }

        public enum CardHistoryOperation
        {
            Insert = 1,
            Update = 2,
            Delete = 3,
            PaymentApproved = 4,
            PaymentCanceled = 5
        }

        public enum BankAccountType
        {
            [Description("CHECKING")]
            Checking = 1,
            [Description("BUSINESS")]
            Business = 2,
            [Description("SAVINGS")]
            Savings = 3
        }

        public enum NewsDemoBatchDetailLogStatus
        {
            [Description("New Generated")]
            NewGenerated = 1,
            [Description("Assigned To Partner")]
            AssignedToPartner = 2,
            [Description("Assigned To Customer")]
            AssignedToCustomer = 3
        }

        public enum Access
        {
            [Description("No Access")]
            NoAccess = 1,
            [Description("View Only")]
            isView = 2,
            [Description("Full Access")]
            All = 3
        }
        public enum PageValueById
        {
            Manage_NewsDemo=1,
            Manage_Partner=2,
            Manage_User=3,
            Report=4,
            Statistics= 5,
            Physical_NewsDemo_Request = 6,
            Partner_Bulk_Buy_Request = 7,
            Partner_Balance_Withdrawal_Request = 8,
            Manage_VirtualVisaCard = 9
        }

        public enum VirtualCreditCardRequestStatus
        {
            [Description("Requested")]
            Requested = 1,
            [Description("Approved")]
            Approved = 2,
            [Description("Rejected")]
            Rejected = 3
        }

        public enum ManageCalculation
        {
            [Description("CreateVCCDeduction")]
            CreateVCCDeduction = 1,
        }

        //API Project - Status Code
        public enum NewsDemoStatusCode
        {
            ModelStateError = -1,
            Ok = 200,
            BadRequest = 400,
            NotFound = 404, // also use for data not found
            ServerError = 500,
            UnAuthorized = 401,
            AccessDenied = 403,
            NotAllowed = 405,
            Conflict = 409
        }
    }
}
