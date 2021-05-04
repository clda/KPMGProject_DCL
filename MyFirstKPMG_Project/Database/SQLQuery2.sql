Use Darshan

Create table tblProducts
					 (	iProductId		int Identity(1,1) primary key,
						vchProductName		varchar(max),
						vchProductCategory	varchar(max),
						decproductPrice	decimal(18,4),
						dtPurchaseDate	date
					)

Insert	tblProducts
Values	('Oneplus', 'Mobile', 39999, '2020-5-5'),
		('Poco', 'Mobile', 7999, '2020-10-23'),
		('iphone', 'Mobile', 18000, '2018-3-2'),
		('HP', 'Laptop', 54000, '2016-7-17'),
		('Puma', 'Shoes', 999, '2020-5-5')

		--Select * from Products

go
Create Procedure proc_ViewProducts
	As
	Begin
		Select * from tblProducts
	End

go

Create Procedure Proc_ViewProductById
	@ProductId int
	As
	Begin
		Select * from Products Where iProductId = @ProductId
	End

Go

Create table tblUserLoginDetails
								(
									iUserId	int Identity(1,1) primary key,
									vchUserName	varchar(50),
									vchUserPassword	varchar(50),
									vchUserRole		varchar(50)
								)

	Insert	tblUserLoginDetails
	Values	('Darshan','cGFzc3dvcmQxMjM=','User'),('Naveen','cGFzc3dvcmQxMjM=','User')
	
	

Go

Create Procedure Proc_UserLogin
@UserName varchar(50)

As
Begin
Select * from tblUserLoginDetails LD where LD.vchUserName = @UserName
End




