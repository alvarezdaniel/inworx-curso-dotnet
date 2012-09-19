USE Woodgrove
DELETE FROM SavingsAccount
DELETE FROM CheckingAccount
DELETE FROM TransactionLog
DELETE FROM Account
DELETE FROM Customer

INSERT Into Customer (ContactName) VALUES ('Sydney Kramer')
INSERT INTO Account (CustomerID, Description, Type) VALUES (3, 'Savings', 'SV')
INSERT INTO SavingsAccount VALUES (5, 5.5)
INSERT INTO Account (CustomerID, Description, Type) VALUES (3, 'Checking', 'CK')
INSERT INTO CheckingAccount VALUES (6, 0.0, null, 10, 10.0, 0.25)

SELECT * FROM Customer
SELECT * FROM Account
SELECT * FROM SavingsAccount
SELECT * FROM CheckingAccount

SELECT * FROM Account a
LEFT OUTER JOIN SavingsAccount sa ON a.AccountID = sa.AccountID
LEFT OUTER JOIN CheckingAccount ca ON a.AccountID = ca.AccountID
WHERE a.AccountID = 5

