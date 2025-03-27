DROP DATABASE IF EXISTS MentorLink;
CREATE DATABASE MentorLink;
USE MentorLink;

create table capstoneworkspace
(
    CapstoneWorkspaceId int auto_increment
        primary key,
    Name                varchar(255)  not null,
    Status              int default 0 not null,
    StartDate           datetime(6)   null,
    EndDate             datetime(6)   null,
    WorkspaceCode       varchar(100)  not null
);

create table newscategory
(
    CategoryId int auto_increment
        primary key,
    Name       varchar(255) not null
);

create table news
(
    NewsId     int auto_increment
        primary key,
    Title      varchar(255)                                     not null,
    Content    json                                             not null,
    Author     int                                              not null,
    PublicDate datetime(6) default '0001-01-01 00:00:00.000000' not null,
    Status     int         default 0                            not null,
    CategoryId int         default 0                            not null,
    constraint FK_News_NewsCategory_CategoryId
        foreign key (CategoryId) references newscategory (CategoryId)
            on delete cascade
);

create index IX_News_CategoryId
    on news (CategoryId);

create table taskboard
(
    TaskBoardId         int auto_increment
        primary key,
    Title               varchar(255)  not null,
    Description         text          not null,
    Status              int default 0 not null,
    CapstoneWorkspaceId int default 0 not null,
    constraint FK_TaskBoard_CapstoneWorkspace_CapstoneWorkspaceId
        foreign key (CapstoneWorkspaceId) references capstoneworkspace (CapstoneWorkspaceId)
            on delete cascade
);

create index IX_TaskBoard_CapstoneWorkspaceId
    on taskboard (CapstoneWorkspaceId);

create table tasklist
(
    TaskListId  int auto_increment
        primary key,
    ListName    varchar(255)  not null,
    Position    int default 0 not null,
    TaskBoardId int           not null,
    constraint FK_TaskList_TaskBoard_TaskBoardId
        foreign key (TaskBoardId) references taskboard (TaskBoardId)
            on delete cascade
);

create index IX_TaskList_TaskBoardId
    on tasklist (TaskBoardId);