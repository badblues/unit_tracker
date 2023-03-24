IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'unit_tracker')
BEGIN
	CREATE DATABASE unit_tracker;
	CREATE TABLE marker (Id UNIQUEIDENTIFIER PRIMARY KEY, Latitude FLOAT, Longitude FLOAT);
END

IF NOT EXISTS(SELECT * FROM sys.syslogins WHERE name = 'unit_tracker_admin')
BEGIN
	CREATE LOGIN unit_tracker_admin WITH PASSWORD = 'admin';
END

USE unit_tracker;

CREATE USER unit_tracker_admin FOR LOGIN unit_tracker_admin;

GRANT ALL PRIVILEGES ON unit_tracker.dbo.marker TO unit_tracker_admin;