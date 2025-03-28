DROP
DATABASE IF EXISTS MentorLink;

CREATE
DATABASE MentorLink;
USE
MentorLink;

CREATE TABLE User
(
    UserId   VARCHAR(128) PRIMARY KEY,
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
CREATE TABLE `Lecturer` (
    `LecturerId` INT NOT NULL AUTO_INCREMENT,
    `Major` VARCHAR(255) NOT NULL DEFAULT '',
    `University` VARCHAR(255) NOT NULL DEFAULT '',
    `Campus` VARCHAR(255) NOT NULL DEFAULT '',
    `Experience` TEXT NULL,
    `Description` TEXT NULL,
    `UserId` INT NOT NULL,
    PRIMARY KEY (`LecturerId`),
    CONSTRAINT `FK_Lecturer_User`
        FOREIGN KEY (`UserId`)
        REFERENCES `User` (`UserId`)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
CREATE TABLE `CapstoneTopic` (
    `CapstoneTopicId` INT NOT NULL AUTO_INCREMENT,
    `Title` VARCHAR(200) NOT NULL,
    `Status` INT NOT NULL DEFAULT 0,
    `SendTime` DATETIME NOT NULL,
    `ResponseTime` DATETIME NULL,
    `ResponseBy` VARCHAR(100) NULL,
    `ResponseMessage` TEXT NULL,
    `Content` TEXT NOT NULL,
    `CapstoneWorkspaceId` INT NOT NULL,
    PRIMARY KEY (`CapstoneTopicId`),
    CONSTRAINT `FK_CapstoneTopic_CapstoneWorkspace`
        FOREIGN KEY (`CapstoneWorkspaceId`)
        REFERENCES `CapstoneWorkspace` (`CapstoneWorkspaceId`)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE `LecturerWorkspace` (
    `WorkspaceId` INT NOT NULL,
    `LecturerId` INT NOT NULL,
    PRIMARY KEY (`WorkspaceId`, `LecturerId`),
    CONSTRAINT `FK_LecturerWorkspace_CapstoneWorkspace`
        FOREIGN KEY (`WorkspaceId`)
        REFERENCES `CapstoneWorkspace` (`CapstoneWorkspaceId`)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT `FK_LecturerWorkspace_Lecturer`
        FOREIGN KEY (`LecturerId`)
        REFERENCES `Lecturer` (`LecturerId`)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
CREATE TABLE `Student` (
    `StudentId` INT NOT NULL AUTO_INCREMENT,
    `Major` VARCHAR(255) NOT NULL DEFAULT '',
    `University` VARCHAR(255) NOT NULL DEFAULT '',
    `Campus` VARCHAR(255) NOT NULL DEFAULT '',
    `SchoolYear` INT NOT NULL,
    `IsGraduated` BOOLEAN NOT NULL DEFAULT FALSE,
    `StudentCard` VARCHAR(255) NULL,
    `CapstoneWorkspaceId` INT NOT NULL,
    `UserId` INT NOT NULL,
    PRIMARY KEY (`StudentId`),
    CONSTRAINT `FK_Student_CapstoneWorkspace`
        FOREIGN KEY (`CapstoneWorkspaceId`)
        REFERENCES `CapstoneWorkspace` (`CapstoneWorkspaceId`)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT `FK_Student_User`
        FOREIGN KEY (`UserId`)
        REFERENCES `User` (`UserId`)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

