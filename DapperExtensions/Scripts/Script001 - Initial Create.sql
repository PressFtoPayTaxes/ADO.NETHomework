create table [dbo].[Articles]
(
	Id uniqueidentifier not null primary key,
	AuthorName nvarchar(50) not null,
	Date datetime not null,
	Text nvarchar(max) not null
)
GO
create table [dbo].[Comments]
(
	Id uniqueidentifier not null primary key,
	AuthorName nvarchar(50) not null,
	Date datetime not null,
	Text nvarchar(max) not null,
	ArticleId uniqueidentifier not null foreign key
	references Articles(Id)
)