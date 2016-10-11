if not exists (select * from INFORMATION_SCHEMA.TABLES  t where t.TABLE_NAME='Products')
    create table Products (
        Id int identity(1,1) not null primary key,
        CatalogId int not null,
        SellerProductId nvarchar(50) null,
        Name nvarchar(50) null,
        Summary nvarchar(max) null,	
        Detail nvarchar(max) null,		
        Price decimal not null,
        CreatedAt datetime2 not null default(getdate()),
        UpdatedAt datetime2 not null default(getdate()),
        SupplierName nvarchar(50) null,
        ShippingWeight decimal not null,
        IsAvailable bit not null,
        IsDownloadable bit not null
    )
 
ALTER TABLE [dbo].Products
ADD CONSTRAINT FK_Products_CatalogId FOREIGN KEY (CatalogId)     
    REFERENCES Catalogs (Id);
go