using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using System.Configuration;
using System.Data.SqlClient;

namespace Woodgrove
{
	[WebService(Name="Woodgrove Online Bank",Description="Woodgrove online banking services")]
	/// <summary>
	/// Summary description for OnlineBank.
	/// </summary>
	public class OnlineBank : System.Web.Services.WebService
	{
		// Header data member
		public WoodgroveAuthInfo authInfo;
		// Place holder data member until authentication added
		public WoodgroveAuthInfo tempAuthInfo;

		public OnlineBank()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();

			// Intialize tempAuthInfo.  Methods requiring authentication will
			// use as a temporary mechanism until header authentication/encryption added
			tempAuthInfo = new WoodgroveAuthInfo();
			tempAuthInfo.Username = "John";
			tempAuthInfo.Password = "password";
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion

		[WebMethod]
		[XmlInclude(typeof(CheckingAcct))]
		[XmlInclude(typeof(SavingsAcct))]
		[return:XmlArray("AnAccount")]
		//[return:XmlArrayItem("Savings",typeof(SavingsAcct))]
		//[return:XmlArrayItem("Checking",typeof(CheckingAcct))]
		[SoapHeader("authInfo",Direction=SoapHeaderDirection.In,Required=false)]
			// Get all accounts for a single customer
		public Acct[] GetAllAccounts()
		{
			// To allow server to work until client header authentication/encryption added
			if (authInfo == null)
				authInfo = tempAuthInfo;

			System.Data.SqlClient.SqlDataAdapter adapter;
			System.Data.SqlClient.SqlCommand cmd;
			System.Data.SqlClient.SqlConnection conn;
			string connString = (string)ConfigurationSettings.AppSettings["connectStringWoodgrove"];

			conn = new System.Data.SqlClient.SqlConnection();
			adapter = new System.Data.SqlClient.SqlDataAdapter();
			cmd = new System.Data.SqlClient.SqlCommand();

			// 
			// conn
			// 
			conn.ConnectionString = connString;
			// 
			// adapter
			// 
			
			adapter.SelectCommand = cmd;
			adapter.TableMappings.AddRange(
				new System.Data.Common.DataTableMapping[] 
				{
					new System.Data.Common.DataTableMapping(
									"Table", "_GetAccount", 
									new System.Data.Common.DataColumnMapping[] 
					{
						new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
						new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
						new System.Data.Common.DataColumnMapping("Description", "Description"),
						new System.Data.Common.DataColumnMapping("Balance", "Balance"),
						new System.Data.Common.DataColumnMapping("LastTransactionDate", "LastTransactionDate"),
						new System.Data.Common.DataColumnMapping("Type", "Type"),
						new System.Data.Common.DataColumnMapping("InterestRate", "InterestRate"),
						new System.Data.Common.DataColumnMapping("MinimumBalance", "MinimumBalance")
					})
				}
					);

																																																		
			// 
			// cmd
			// 
			cmd.CommandText = "_GetAllAccounts";
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Connection = conn;
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@userID", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, authInfo.Username));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@password", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, authInfo.Password));

			// Open connection, fill dataset, close connection
			conn.Open();
			AccountDataSet ds = new AccountDataSet();
			int nRecords = adapter.Fill(ds);
			conn.Close();

			// Check that records exists
			if (nRecords == 0)
				return null;

			// Allocate one per account
			Acct[] a = new Acct[ds._GetAccount.Count];

			for (int i = 0; i < ds._GetAccount.Count; i++)
			{
				// Set account information to return
				if (ds._GetAccount[i].Type == "SV")
				{
					SavingsAcct sa = new SavingsAcct();
					sa.InterestRate = ds._GetAccount[i].InterestRate;
					a[i] = sa;
				}
				else if (ds._GetAccount[i].Type == "CK")
				{
					CheckingAcct ca = new CheckingAcct();
					ca.MinimumBalance = ds._GetAccount[i].MinimumBalance;
					a[i] = ca;
				}
				a[i].AccountID = ds._GetAccount[i].AccountID;
				a[i].Description = ds._GetAccount[i].Description;
				a[i].Type = ds._GetAccount[i].Type;
				a[i].Balance = ds._GetAccount[i].Balance;
				a[i].lastTransaction = 
					(ds._GetAccount[i].IsLastTransactionDateNull() ? new DateTime(0) : ds._GetAccount[i].LastTransactionDate);
			}
			return a;
		}

		[WebMethod]
		[XmlInclude(typeof(CheckingAcct))]
		[XmlInclude(typeof(SavingsAcct))]
		[return:XmlElement("Checking",typeof(CheckingAcct))]
		[return:XmlElement("Savings",typeof(SavingsAcct))]
		[SoapHeader("authInfo",Direction=SoapHeaderDirection.In,Required=false)]
		// Get a single account
		public Acct GetAccount(int acctID)
		{
			// To allow server to work until client header authentication/encryption added
			if (authInfo == null)
				authInfo = tempAuthInfo;

			System.Data.SqlClient.SqlDataAdapter adapter;
			System.Data.SqlClient.SqlCommand cmd;
			System.Data.SqlClient.SqlConnection conn;
			string connString = (string)ConfigurationSettings.AppSettings["connectStringWoodgrove"];

			conn = new System.Data.SqlClient.SqlConnection();
			adapter = new System.Data.SqlClient.SqlDataAdapter();
			cmd = new System.Data.SqlClient.SqlCommand();

			// 
			// conn
			// 
			conn.ConnectionString = connString;
			// 
			// adapter
			// 
			adapter.SelectCommand = cmd;
			adapter.TableMappings.AddRange(
				new System.Data.Common.DataTableMapping[] 
				{
                    new System.Data.Common.DataTableMapping("Table", "_GetAccount", new System.Data.Common.DataColumnMapping[] 
					{
                        new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
						new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
						new System.Data.Common.DataColumnMapping("Description", "Description"),
						new System.Data.Common.DataColumnMapping("Balance", "Balance"),
						new System.Data.Common.DataColumnMapping("LastTransactionDate", "LastTransactionDate"),
						new System.Data.Common.DataColumnMapping("Type", "Type"),
						new System.Data.Common.DataColumnMapping("InterestRate", "InterestRate"),
						new System.Data.Common.DataColumnMapping("MinimumBalance", "MinimumBalance"),
						new System.Data.Common.DataColumnMapping("PerCheckFee", "PerCheckFee")
					})
				});
			// 
			// cmd
			// 
			cmd.CommandText = "_GetAccount";
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Connection = conn;
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@userID", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, authInfo.Username));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@password", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, authInfo.Password));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@acctID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, acctID));

			// Open connection, fill dataset, close connection
			conn.Open();
			AccountDataSet ds = new AccountDataSet();
			int nRecords = adapter.Fill(ds);
			conn.Close();

			// Check that account exists
			if (nRecords == 0)
				return null;

			Acct a;

			// Set account information to return
			if (ds._GetAccount[0].Type == "SV")
			{
				SavingsAcct sa = new SavingsAcct();
				sa.InterestRate = ds._GetAccount[0].InterestRate;
				a = sa;
			}
			else if (ds._GetAccount[0].Type == "CK")
			{
				CheckingAcct ca = new CheckingAcct();
				ca.MinimumBalance = ds._GetAccount[0].MinimumBalance;
				a = ca;
			}
			else
			{
				throw new Exception("Invalid account type returned.");
			}
			a.AccountID = ds._GetAccount[0].AccountID;
			a.Description = ds._GetAccount[0].Description;
			a.Type = ds._GetAccount[0].Type;
			a.Balance = ds._GetAccount[0].Balance;
			a.lastTransaction = 
				(ds._GetAccount[0].IsLastTransactionDateNull() ? new DateTime(0) : ds._GetAccount[0].LastTransactionDate);
			return a;
		}

		[WebMethod]
		[SoapHeader("authInfo",Direction=SoapHeaderDirection.In,Required=false)]
		// Get all transactions for a single account
		public TransactionDataSet GetTransactionHistory(int accountID, DateTime startDate, DateTime endDate)
		{
			// To allow server to work until client header authentication/encryption added
			if (authInfo == null)
				authInfo = tempAuthInfo;

			System.Data.SqlClient.SqlDataAdapter adapter;
			System.Data.SqlClient.SqlCommand cmd;
			System.Data.SqlClient.SqlConnection conn;
			string connString = (string)ConfigurationSettings.AppSettings["connectStringWoodgrove"];

			adapter = new System.Data.SqlClient.SqlDataAdapter();
			cmd = new System.Data.SqlClient.SqlCommand();
			conn = new System.Data.SqlClient.SqlConnection();
			// 
			// adapter
			// 
			adapter.SelectCommand = cmd;
			adapter.TableMappings.AddRange(
				new System.Data.Common.DataTableMapping[] 
				{
					new System.Data.Common.DataTableMapping("Table", "_GetTransactionLog", new System.Data.Common.DataColumnMapping[] 
					{
						new System.Data.Common.DataColumnMapping("TransactionID", "TransactionID"),
						new System.Data.Common.DataColumnMapping("TransactionDate", "TransactionDate"),
						new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
						new System.Data.Common.DataColumnMapping("Amount", "Amount"),
						new System.Data.Common.DataColumnMapping("Description", "Description"),
						new System.Data.Common.DataColumnMapping("Type", "Type")
					})
				});
			// 
			// cmd
			// 
			cmd.CommandText = "_GetTransactionLog";
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Connection = conn;
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@userID", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, authInfo.Username));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@password", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, authInfo.Password));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@acctID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, accountID));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@startDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, startDate));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@endDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, endDate));
			// 
			// conn
			// 
			conn.ConnectionString = connString;
			
			// Open connection, fill dataset, close connection
			conn.Open();
			TransactionDataSet ds = new TransactionDataSet();
			adapter.Fill(ds);
			conn.Close();
			return ds;
		}

		[WebMethod]
		[SoapHeader("authInfo",Direction=SoapHeaderDirection.In,Required=false)]
		// Check that there is amount can be authorized, create a token
		// return token and routing info
		public EFTBindingInfo AuthorizeFundsTransfer(int acctID, decimal amount)
		{
			// To allow server to work until client header authentication/encryption added
			if (authInfo == null)
				authInfo = tempAuthInfo;

			System.Data.SqlClient.SqlDataAdapter adapter;
			System.Data.SqlClient.SqlCommand cmd;
			System.Data.SqlClient.SqlConnection conn;
			string connString = (string)ConfigurationSettings.AppSettings["connectStringWoodgrove"];
			string transID;

			conn = new System.Data.SqlClient.SqlConnection();
			adapter = new System.Data.SqlClient.SqlDataAdapter();
			cmd = new System.Data.SqlClient.SqlCommand();

			// 
			// cmd
			// 
			// _EFTAuthorize(@userID AS nvarchar(50), @password AS nvarchar(50), @acctID as int, @amt as money, @token as nvarchar(50) output) 
			cmd.CommandText = "_EFTAuthorize";
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Connection = conn;
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@userID", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, authInfo.Username));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@password", System.Data.SqlDbType.NVarChar, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, authInfo.Password));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@acctID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, acctID));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@amt", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, amount));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EFTTransactionID", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			// 
			// conn
			// 
			conn.ConnectionString = connString;
			try
			{
				// Open connection, execute, close connection
				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
				transID = cmd.Parameters["@EFTTransactionID"].Value.ToString();
			}
			catch (SqlException se)
			{
				Trace.WriteLine(se.Message);
				throw new SoapException(se.Message, null);
			}

			// Create and set binding info
			EFTBindingInfo info = new EFTBindingInfo();
			
			// Calculate expire date and format token
			DateTime expires = DateTime.Now.AddMinutes(5);
			info.token = string.Format("<eft><transactionID>{0}</transactionID><acct>{1}</acct><amt>{2}</amt><expires>{3}</expires></eft>",
				transID, acctID, amount, expires);
			info.endPoint = string.Format("http://{0}/Woodgrove/Bank.asmx",Environment.MachineName);
			Context.Trace.Write(string.Format("Endpoint: {0} AuthorizeFundsTransfer Acct:{1} Amt:{2}",
				info.endPoint,acctID,amount));
			return info;
		}

		[WebMethod]
		// Given a token and routing information, complete the transaction
		// by transferring the funds and debiting the account
		public EFTConfirmation TransferFunds(string token, EFTRoutingInfo routingInfo)
		{
			// Parse out amount and transactionID from token
				// Convert token string to bytes[] to create MemoryStream
			System.Text.ASCIIEncoding a = new System.Text.ASCIIEncoding();
			System.IO.MemoryStream ms = new System.IO.MemoryStream(a.GetBytes(token));

			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
			doc.Load(ms);
			
			//Get transactionID, acctID and amount
			System.Xml.XmlNode node = doc.SelectSingleNode("eft/transactionID");
			if (node == null)
				throw new Exception("Invalid token.");
			
			string s = node.InnerText;
			Guid transID = new Guid(s);

			node = doc.SelectSingleNode("eft/acct");
			if (node == null)
				throw new Exception("Invalid token.");

			int acctID = Int32.Parse(node.InnerText);
			
			node = doc.SelectSingleNode("eft/amt");
			if (node == null)
				throw new Exception("Invalid token.");

			decimal amt = Decimal.Parse(node.InnerText);

			System.Data.SqlClient.SqlDataAdapter adapter;
			System.Data.SqlClient.SqlCommand cmd;
			System.Data.SqlClient.SqlConnection conn;
			string connString = (string)ConfigurationSettings.AppSettings["connectStringWoodgrove"];

			conn = new System.Data.SqlClient.SqlConnection();
			adapter = new System.Data.SqlClient.SqlDataAdapter();
			cmd = new System.Data.SqlClient.SqlCommand();

			// 
			// cmd
			// 
			// _EFTComplete(@acctID as int, @amt as money, @EFTTransactionID as uniqueidentifier, @confirmID as nvarchar(50) output)
			cmd.CommandText = "_EFTComplete";
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Connection = conn;
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@acctID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, acctID));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@amt", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, amt));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EFTTransactionID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, transID));
			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@confirmID", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Output, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			// 
			// conn
			// 
			conn.ConnectionString = connString;
		
			try
			{
				// Open connection, execute, close connection
				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();

				EFTConfirmation eftConfirm = new EFTConfirmation();
				eftConfirm.confirmationNumber = cmd.Parameters["@confirmID"].Value.ToString();
				eftConfirm.amt = amt;
				eftConfirm.transactionID = transID.ToString();
				Context.Trace.Write(string.Format("TransferFunds Acct:{0} Amt:{1}",acctID,amt));
				return eftConfirm;
			}
			catch (Exception se)
			{
				Trace.WriteLine(se.Message);
				throw new SoapException(se.Message, null);
			}
		}
	}

	// Base account type
	[XmlRoot("account")]
	public class Acct
	{
		[XmlElement("accountID")]
		public int AccountID;
		[XmlElement("description")]
		public string Description;
		[XmlElement("type")]
		public string Type;
		[XmlElement("balance")]
		public decimal Balance;
		[XmlElement("lastTransaction")]
		public DateTime lastTransaction;
	}

	// Derived saving account type
	[XmlRoot("savingsAcct")]
	public class SavingsAcct : Acct
	{
		[XmlElement("interestRate")]
		public decimal InterestRate;
	}

	// Derived checking account type
	[XmlRoot("checkingAcct")]
	public class CheckingAcct : Acct
	{
		public decimal MinimumBalance;
	}

	public class WoodgroveAuthInfo : SoapHeader 
	{
		public string Username;
		public string Password;
	}

}
