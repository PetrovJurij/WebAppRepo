begin

IF OBJECT_ID ('Vote','U') IS NOT NULL DROP TABLE Vote;
IF OBJECT_ID ('Users','U') IS NOT NULL DROP TABLE Users;
IF OBJECT_ID ('Companies','U') IS NOT NULL DROP TABLE Companies
IF OBJECT_ID ('UserType','U') IS NOT NULL DROP TABLE UserType
IF OBJECT_ID ('Vote View','V') IS NOT NULL DROP View [Vote View]

end

go

begin
Create table Companies(
Company_Id		int Identity(1,1) Primary key not null,
CompanyName		nvarchar(50),
CompanyDesc		nvarchar(MAX),
CompanyRating	decimal(7,5),
NumberOfVotes	integer
)

Create table UserType(
UserType_Id int Identity(1,1) Primary key not null,
UserType	nvarchar(15)
);

Create table Users(
Users_Id		int Identity(1,1) Primary key not null,
Users_UserName	nvarchar(20),
Users_IP		nvarchar(12) not null,
Users_hash		nvarchar(MAX) not null,
Users_Type		integer not null,
User_Pass		nvarchar(MAX),
Foreign key(Users_Type) references UserType(UserType_Id)
);

Create table Vote(
Vote_Id			int Identity(1,1) Primary key not null,
Vote_User		int not null,
Voted_Company	int not null,
Vote_Comentary	nvarchar(MAX),
Vote_Weight		decimal(7,5),
Foreign key(Vote_User)		references	Users(Users_Id),
Foreign key(Voted_Company) references	Companies(Company_Id)
);


end;

go

Create View [Vote View] As
select  Vote_Id, Vote_Comentary, Vote_Weight, Users_UserName, Users_IP, Users_hash, CompanyName from Vote 
inner join Users on Vote.Vote_User=Users.Users_Id 
inner join UserType on Users.Users_Type=UserType.UserType_Id 
inner join Companies on Vote.Voted_Company=Companies.Company_Id


go



insert into Companies(CompanyName,CompanyDesc,CompanyRating,NumberOfVotes) Values('Com #2',' ',5.73,45);
insert into Companies(CompanyName,CompanyDesc,CompanyRating,NumberOfVotes) Values('Com #1',' ',1.8,255);
insert into Companies(CompanyName,CompanyDesc,CompanyRating,NumberOfVotes) Values('Com #3',' ',8.3,255);
insert into Companies(CompanyName,CompanyDesc,CompanyRating,NumberOfVotes) Values('Com #4',' ',2.5,255);
insert into Companies(CompanyName,CompanyDesc,CompanyRating,NumberOfVotes) Values('Com #5',' ',4.4,255);
insert into Companies(CompanyName,CompanyDesc,CompanyRating,NumberOfVotes) Values('Com #6',' ',10.0,255);
insert into Companies(CompanyName,CompanyDesc,CompanyRating,NumberOfVotes) Values('Com #7',' ',6.3,255);
insert into Companies(CompanyName,CompanyDesc,CompanyRating,NumberOfVotes) Values('Com #8',' ',9.5,255);
insert into Companies(CompanyName,CompanyDesc,CompanyRating,NumberOfVotes) Values('Com #9',' ',3.3,255);
insert into Companies(CompanyName,CompanyDesc,CompanyRating,NumberOfVotes) Values('Com #10',' ',7.2,255);
insert into Companies(CompanyName,CompanyDesc,CompanyRating,NumberOfVotes) Values('Com #11',' ',9.3,255);

go

begin

insert into UserType(UserType) Values('Anonymous')
insert into UserType(UserType) Values('Moderator')

end

go