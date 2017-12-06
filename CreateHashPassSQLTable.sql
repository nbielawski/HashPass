CREATE TABLE [dbo].[Account] (
    [AccountId]    INT                IDENTITY (1, 1) NOT NULL,
    [OwnerId]      UNIQUEIDENTIFIER   NOT NULL,
    [AcctName]     NVARCHAR (MAX)     NOT NULL,
    [AcctPassword] NVARCHAR (MAX)     NOT NULL,
    [AddedUtc]     DATETIMEOFFSET (7) NOT NULL,
    [UpdatedUtc]   DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_dbo.Account] PRIMARY KEY CLUSTERED ([AccountId] ASC)
);