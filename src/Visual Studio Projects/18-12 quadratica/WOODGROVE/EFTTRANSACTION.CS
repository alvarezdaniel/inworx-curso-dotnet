//------------------------------------------------------------------------------
// <autoEFTTransactionDS>
//     This code was EFTTransactionDS by a tool.
//     Runtime Version: 1.0.2914.16
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is reEFTTransactionDS.
// </autoEFTTransactionDS>
//------------------------------------------------------------------------------

// 
// This source code was auto-EFTTransactionDS by xsd, Version=1.0.2914.16.
// 
using System;
using System.Data;
using System.Xml;
using System.Runtime.Serialization;


[Serializable()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public class EFTTransactionDS : System.Data.DataSet {
    
    private EFTTransactionDataTable tableEFTTransaction;
    
    public EFTTransactionDS() {
        this.InitClass();
    }
    
    private EFTTransactionDS(SerializationInfo info, StreamingContext context) {
        this.InitClass();
        this.GetSerializationData(info, context);
    }
    
    [System.ComponentModel.Browsable(false)]
    [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
    public EFTTransactionDataTable EFTTransaction {
        get {
            return this.tableEFTTransaction;
        }
    }
    
    protected override bool ShouldSerializeTables() {
        return false;
    }
    
    protected override bool ShouldSerializeRelations() {
        return false;
    }
    
    protected override void ReadXmlSerializable(XmlReader reader) {
        this.ReadXml(reader, XmlReadMode.IgnoreSchema);
    }
    
    protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
        System.IO.MemoryStream stream = new System.IO.MemoryStream();
        this.WriteXmlSchema(new XmlTextWriter(stream, null));
        stream.Position = 0;
        return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
    }
    
    private void InitClass() {
        this.DataSetName = "EFTTransactionDS";
        this.Namespace = "";
        this.tableEFTTransaction = new EFTTransactionDataTable();
        this.Tables.Add(this.tableEFTTransaction);
    }
    
    private bool ShouldSerializeEFTTransaction() {
        return false;
    }
    
    public delegate void EFTTransactionRowChangeEventHandler(object sender, EFTTransactionRowChangeEvent e);
    
    public class EFTTransactionDataTable : DataTable, System.Collections.IEnumerable {
        
        private DataColumn columnAccountId;
        
        private DataColumn columnTransactionTimestamp;
        
        private DataColumn columnAmount;
        
        internal EFTTransactionDataTable() : 
                base("EFTTransaction") {
            this.InitClass();
        }
        
        [System.ComponentModel.Browsable(false)]
        public int Count {
            get {
                return this.Rows.Count;
            }
        }
        
        internal DataColumn AccountIdColumn {
            get {
                return this.columnAccountId;
            }
        }
        
        internal DataColumn TransactionTimestampColumn {
            get {
                return this.columnTransactionTimestamp;
            }
        }
        
        internal DataColumn AmountColumn {
            get {
                return this.columnAmount;
            }
        }
        
        public EFTTransactionRow this[int index] {
            get {
                return ((EFTTransactionRow)(this.Rows[index]));
            }
        }
        
        public event EFTTransactionRowChangeEventHandler EFTTransactionRowChanged;
        
        public event EFTTransactionRowChangeEventHandler EFTTransactionRowChanging;
        
        public event EFTTransactionRowChangeEventHandler EFTTransactionRowDeleted;
        
        public event EFTTransactionRowChangeEventHandler EFTTransactionRowDeleting;
        
        public void AddEFTTransactionRow(EFTTransactionRow row) {
            this.Rows.Add(row);
        }
        
        public EFTTransactionRow AddEFTTransactionRow(int AccountId, System.DateTime TransactionTimestamp, System.Decimal Amount) {
            EFTTransactionRow rowEFTTransactionRow = ((EFTTransactionRow)(this.NewRow()));
            rowEFTTransactionRow.ItemArray = new object[] {
                    AccountId,
                    TransactionTimestamp,
                    Amount};
            this.Rows.Add(rowEFTTransactionRow);
            return rowEFTTransactionRow;
        }
        
        public System.Collections.IEnumerator GetEnumerator() {
            return this.Rows.GetEnumerator();
        }
        
        private void InitClass() {
            this.columnAccountId = new DataColumn("AccountId", typeof(int), "", System.Data.MappingType.Element);
            this.Columns.Add(this.columnAccountId);
            this.columnTransactionTimestamp = new DataColumn("TransactionTimestamp", typeof(System.DateTime), "", System.Data.MappingType.Element);
            this.Columns.Add(this.columnTransactionTimestamp);
            this.columnAmount = new DataColumn("Amount", typeof(System.Decimal), "", System.Data.MappingType.Element);
            this.Columns.Add(this.columnAmount);
        }
        
        public EFTTransactionRow NewEFTTransactionRow() {
            return ((EFTTransactionRow)(this.NewRow()));
        }
        
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
            // We need to ensure that all Rows in the tabled are typed rows.
            // Table calls newRow whenever it needs to create a row.
            // So the following conditions are covered by Row newRow(Record record)
            // * Cursor calls table.addRecord(record) 
            // * table.addRow(object[] values) calls newRow(record)    
            return new EFTTransactionRow(builder);
        }
        
        protected override System.Type GetRowType() {
            return typeof(EFTTransactionRow);
        }
        
        protected override void OnRowChanged(DataRowChangeEventArgs e) {
            base.OnRowChanged(e);
            if ((this.EFTTransactionRowChanged != null)) {
                this.EFTTransactionRowChanged(this, new EFTTransactionRowChangeEvent(((EFTTransactionRow)(e.Row)), e.Action));
            }
        }
        
        protected override void OnRowChanging(DataRowChangeEventArgs e) {
            base.OnRowChanging(e);
            if ((this.EFTTransactionRowChanging != null)) {
                this.EFTTransactionRowChanging(this, new EFTTransactionRowChangeEvent(((EFTTransactionRow)(e.Row)), e.Action));
            }
        }
        
        protected override void OnRowDeleted(DataRowChangeEventArgs e) {
            base.OnRowDeleted(e);
            if ((this.EFTTransactionRowDeleted != null)) {
                this.EFTTransactionRowDeleted(this, new EFTTransactionRowChangeEvent(((EFTTransactionRow)(e.Row)), e.Action));
            }
        }
        
        protected override void OnRowDeleting(DataRowChangeEventArgs e) {
            base.OnRowDeleting(e);
            if ((this.EFTTransactionRowDeleting != null)) {
                this.EFTTransactionRowDeleting(this, new EFTTransactionRowChangeEvent(((EFTTransactionRow)(e.Row)), e.Action));
            }
        }
        
        public void RemoveEFTTransactionRow(EFTTransactionRow row) {
            this.Rows.Remove(row);
        }
    }
    
    public class EFTTransactionRow : DataRow {
        
        private EFTTransactionDataTable tableEFTTransaction;
        
        internal EFTTransactionRow(DataRowBuilder rb) : 
                base(rb) {
            this.tableEFTTransaction = ((EFTTransactionDataTable)(this.Table));
        }
        
        public int AccountId {
            get {
                try {
                    return ((int)(this[this.tableEFTTransaction.AccountIdColumn]));
                }
                catch (InvalidCastException e) {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set {
                this[this.tableEFTTransaction.AccountIdColumn] = value;
            }
        }
        
        public System.DateTime TransactionTimestamp {
            get {
                try {
                    return ((System.DateTime)(this[this.tableEFTTransaction.TransactionTimestampColumn]));
                }
                catch (InvalidCastException e) {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set {
                this[this.tableEFTTransaction.TransactionTimestampColumn] = value;
            }
        }
        
        public System.Decimal Amount {
            get {
                try {
                    return ((System.Decimal)(this[this.tableEFTTransaction.AmountColumn]));
                }
                catch (InvalidCastException e) {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set {
                this[this.tableEFTTransaction.AmountColumn] = value;
            }
        }
        
        public bool IsAccountIdNull() {
            return this.IsNull(this.tableEFTTransaction.AccountIdColumn);
        }
        
        public void SetAccountIdNull() {
            this[this.tableEFTTransaction.AccountIdColumn] = System.Convert.DBNull;
        }
        
        public bool IsTransactionTimestampNull() {
            return this.IsNull(this.tableEFTTransaction.TransactionTimestampColumn);
        }
        
        public void SetTransactionTimestampNull() {
            this[this.tableEFTTransaction.TransactionTimestampColumn] = System.Convert.DBNull;
        }
        
        public bool IsAmountNull() {
            return this.IsNull(this.tableEFTTransaction.AmountColumn);
        }
        
        public void SetAmountNull() {
            this[this.tableEFTTransaction.AmountColumn] = System.Convert.DBNull;
        }
    }
    
    public class EFTTransactionRowChangeEvent : EventArgs {
        
        private EFTTransactionRow eventRow;
        
        private System.Data.DataRowAction eventAction;
        
        public EFTTransactionRowChangeEvent(EFTTransactionRow row, DataRowAction action) {
            this.eventRow = row;
            this.eventAction = action;
        }
        
        public EFTTransactionRow Row {
            get {
                return this.eventRow;
            }
        }
        
        public DataRowAction Action {
            get {
                return this.eventAction;
            }
        }
    }
}
