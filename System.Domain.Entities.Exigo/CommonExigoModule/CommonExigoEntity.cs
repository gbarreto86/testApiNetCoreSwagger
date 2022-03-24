using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public enum Gender
    {

        /// <remarks/>
        Unknown,

        /// <remarks/>
        Male,

        /// <remarks/>
        Female,
    }
    public enum PayableType
    {

        /// <remarks/>
        Check,

        /// <remarks/>
        WireTransfer,

        /// <remarks/>
        PaymentCard,

        /// <remarks/>
        DirectDeposit,

        /// <remarks/>
        OnHold,

        /// <remarks/>
        BankWire,

        /// <remarks/>
        DebitCardHold,

        /// <remarks/>
        Other100,
    }
    public enum OrderStatusType
    {

        /// <remarks/>
        Incomplete,

        /// <remarks/>
        Pending,

        /// <remarks/>
        CCDeclined,

        /// <remarks/>
        ACHDeclined,

        /// <remarks/>
        Canceled,

        /// <remarks/>
        CCPending,

        /// <remarks/>
        ACHPending,

        /// <remarks/>
        Accepted,

        /// <remarks/>
        Printed,

        /// <remarks/>
        Shipped,

        /// <remarks/>
        PendingInventory,
    }
    public enum OrderType
    {

        /// <remarks/>
        Default,

        /// <remarks/>
        CustomerService,

        /// <remarks/>
        ShoppingCart,

        /// <remarks/>
        WebWizard,

        /// <remarks/>
        AutoOrder,

        /// <remarks/>
        Import,

        /// <remarks/>
        BackOrder,

        /// <remarks/>
        ReplacementOrder,

        /// <remarks/>
        ReturnOrder,

        /// <remarks/>
        WebAutoOrder,

        /// <remarks/>
        TicketSystem,

        /// <remarks/>
        APIOrder,

        /// <remarks/>
        BackOrderParent,

        /// <remarks/>
        ChildOrder,

        /// <remarks/>
        Other1,

        /// <remarks/>
        Other2,

        /// <remarks/>
        Other3,

        /// <remarks/>
        Other4,

        /// <remarks/>
        Other5,

        /// <remarks/>
        Other6,

        /// <remarks/>
        Other7,

        /// <remarks/>
        Other8,

        /// <remarks/>
        Other9,

        /// <remarks/>
        Other10,
    }
    public enum AutoOrderProcessType
    {

        /// <remarks/>
        AlwaysProcess,

        /// <remarks/>
        Conditional,
    }
    public enum AutoOrderPaymentType
    {

        /// <remarks/>
        PrimaryCreditCard,

        /// <remarks/>
        SecondaryCreditCard,

        /// <remarks/>
        CheckingAccount,

        /// <remarks/>
        WillSendPayment,

        /// <remarks/>
        BankDraft,

        /// <remarks/>
        PrimaryWalletAccount,

        /// <remarks/>
        SecondaryWalletAccount,
    }
    public enum FrequencyType
    {

        /// <remarks/>
        Weekly,

        /// <remarks/>
        BiWeekly,

        /// <remarks/>
        Monthly,

        /// <remarks/>
        BiMonthly,

        /// <remarks/>
        Quarterly,

        /// <remarks/>
        SemiYearly,

        /// <remarks/>
        Yearly,

        /// <remarks/>
        EveryFourWeeks,

        /// <remarks/>
        EverySixWeeks,

        /// <remarks/>
        EveryEightWeeks,

        /// <remarks/>
        EveryTwelveWeeks,

        /// <remarks/>
        SpecificDays,
    }
    public enum AccountCreditCardType
    {

        /// <remarks/>
        Primary,

        /// <remarks/>
        Secondary,
    }
    public enum ResultStatus
    {

        /// <remarks/>
        Success,

        /// <remarks/>
        Failure,
    }
}
