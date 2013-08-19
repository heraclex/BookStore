
ALTER TABLE UserProfile
DROP CONSTRAINT fk_UserProfile_UserId;
GO


ALTER TABLE UserProfile
ADD CONSTRAINT fk_UserProfile_UserId FOREIGN KEY(UserId)REFERENCES dbo.[User](UserId)
GO 