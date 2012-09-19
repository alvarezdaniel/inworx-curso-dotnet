using System;

namespace Woodgrove
{
	public struct EFTAccount
	{
		string Name;
		string Number;
	}

	public struct EFTBindingInfo
	{
		public string token;
		public string endPoint;
	}

	public struct EFTRoutingInfo
	{
		public string Bank;
		public string ABA_RoutingNo;
		public string AccountName;
		public string AccountNumber;
		public string SubAccountName;
		public string SubAccountNumber;
	}

	public struct EFTConfirmation
	{
		public string confirmationNumber;
		public decimal amt;
		public string transactionID;
	}
}
