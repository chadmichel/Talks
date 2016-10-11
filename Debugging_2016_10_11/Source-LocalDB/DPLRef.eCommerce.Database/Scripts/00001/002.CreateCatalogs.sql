if not exists (select * from INFORMATION_SCHEMA.TABLES  t where t.TABLE_NAME='Catalogs')
    create table Catalogs (
        Id int identity(1,1) not null primary key,
        SellerId int not null,
        Name nvarchar(50) null,
        Description nvarchar(max) null,
        IsAvailable bit not null default(1),
        CreatedAt datetime2 not null default(getdate()),
        UpdatedAt datetime2 not null default(getdate())
    )


    
    ALTER TABLE [dbo].Catalogs
ADD CONSTRAINT FK_Catalogs_SellerId FOREIGN KEY (SellerId)     
    REFERENCES Sellers (Id);
go