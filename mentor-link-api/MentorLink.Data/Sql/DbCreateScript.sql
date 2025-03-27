DROP DATABASE IF EXISTS MentorLink;
CREATE DATABASE MentorLink;
USE MentorLink;

CREATE TABLE User(
    UserId VARCHAR(32) PRIMARY KEY,
    Email VARCHAR(255), 
    Password VARCHAR(128),
    CreateAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdateAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
    
CREATE TABLE News (
    NewsId INT PRIMARY KEY AUTO_INCREMENT,
    Title VARCHAR(255) NOT NULL,
    Content JSON,
    Author INT NOT NULL,
    PublicDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Category VARCHAR(100),
    Status INT DEFAULT 0,
    UpdateStatus INT DEFAULT 0
);

CREATE TABLE CapstoneWorkspace (
    CapstoneWorkspaceId INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    Status VARCHAR(50),
    StartDate TIMESTAMP,
    EndDate TIMESTAMP,
    WorkspaceCode VARCHAR(100) UNIQUE
);

CREATE TABLE TaskBoard (
    TaskBoardId INT PRIMARY KEY AUTO_INCREMENT,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    Status VARCHAR(50),
    CapstoneWorkspaceId INT,
    FOREIGN KEY (CapstoneWorkspaceId) REFERENCES CapstoneWorkspace(CapstoneWorkspaceId)
);

CREATE TABLE TaskList (
    TaskListId INT PRIMARY KEY AUTO_INCREMENT,
    ListName VARCHAR(255) NOT NULL,
    Position INT,
    TaskBoardId INT NOT NULL,
    FOREIGN KEY (TaskBoardId) REFERENCES TaskBoard(TaskBoardId) ON DELETE CASCADE
);