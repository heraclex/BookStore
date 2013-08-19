
ALTER TABLE UserRole
DROP CONSTRAINT fk_UserRole_UserId;
GO

ALTER TABLE UserRole
DROP CONSTRAINT fk_UserRole_RoleId;
GO 

ALTER TABLE UserRole
ADD CONSTRAINT fk_UserRole_UserId FOREIGN KEY(UserId)REFERENCES dbo.[User](UserId),
CONSTRAINT fk_UserRole_RoleId FOREIGN KEY(RoleId)REFERENCES dbo.[Role](RoleId)
GO 