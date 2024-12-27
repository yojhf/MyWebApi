CREATE TABLE [dbo].[PointsLogs]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,	-- 일련번호
	userId int not null,							-- 사용자 ID
	userName nvarchar(25),							-- 사용자 이름
	totalPoint int default(0),						-- 종합포인트
	Created DatetimeOffset(7) default(getdate())	-- 등록일시
)
