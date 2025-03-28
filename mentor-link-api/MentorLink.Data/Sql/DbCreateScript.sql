DROP
DATABASE IF EXISTS MentorLink;

CREATE
DATABASE MentorLink;
USE
MentorLink;

CREATE TABLE User
(
    UserId   VARCHAR(32) PRIMARY KEY,
    Email    VARCHAR(255),
    Password VARCHAR(128),
    CreateAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdateAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE CapstoneWorkspace
(
    CapstoneWorkspaceId INT AUTO_INCREMENT PRIMARY KEY,
    Name                VARCHAR(255) NOT NULL,
    Status              INT          NOT NULL,
    StartDate           DATETIME(6)  NULL,
    EndDate             DATETIME(6)  NULL,
    WorkspaceCode       VARCHAR(100) NOT NULL
);

CREATE TABLE NewsCategory
(
    CategoryId INT AUTO_INCREMENT PRIMARY KEY,
    Name       VARCHAR(255) NOT NULL
);

CREATE TABLE News
(
    NewsId     INT AUTO_INCREMENT PRIMARY KEY,
    Title      VARCHAR(255)                        NOT NULL,
    Content    JSON                                NOT NULL,
    Author     INT                                 NOT NULL,
    PublicDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL ON UPDATE CURRENT_TIMESTAMP,
    CategoryId INT                                 NOT NULL,
    Status     INT                                 NOT NULL,
    CONSTRAINT FK_News_NewsCategory FOREIGN KEY (CategoryId) REFERENCES NewsCategory (CategoryId) ON DELETE CASCADE
);

CREATE INDEX IX_News_CategoryId ON News (CategoryId);

CREATE TABLE TaskBoard
(
    TaskBoardId         INT AUTO_INCREMENT PRIMARY KEY,
    Title               VARCHAR(255) NOT NULL,
    Description         TEXT         NOT NULL,
    Status              INT          NOT NULL,
    CapstoneWorkspaceId INT          NOT NULL,
    CONSTRAINT FK_TaskBoard_CapstoneWorkspace FOREIGN KEY (CapstoneWorkspaceId) REFERENCES CapstoneWorkspace (CapstoneWorkspaceId) ON DELETE CASCADE
);

CREATE INDEX IX_TaskBoard_CapstoneWorkspaceId ON TaskBoard (CapstoneWorkspaceId);

CREATE TABLE TaskList
(
    TaskListId  INT AUTO_INCREMENT PRIMARY KEY,
    ListName    VARCHAR(255) NOT NULL,
    Position    INT          NOT NULL,
    TaskBoardId INT          NOT NULL,
    CONSTRAINT FK_TaskList_TaskBoard FOREIGN KEY (TaskBoardId) REFERENCES TaskBoard (TaskBoardId) ON DELETE CASCADE
);

CREATE INDEX IX_TaskList_TaskBoardId ON TaskList (TaskBoardId);
