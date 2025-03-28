USE
MentorLink;

INSERT INTO User (UserId, Email, Password, CreateAt, UpdateAt)
VALUES (UUID(), 'user1@example.com', 'hashed_password_1', NOW(), NOW()),
       (UUID(), 'user2@example.com', 'hashed_password_2', NOW(), NOW()),
       (UUID(), 'user3@example.com', 'hashed_password_3', NOW(), NOW()),
       (UUID(), 'user4@example.com', 'hashed_password_4', NOW(), NOW()),
       (UUID(), 'user5@example.com', 'hashed_password_5', NOW(), NOW());

INSERT INTO NewsCategory (Name)
VALUES ('Technology'),
       ('Education'),
       ('Business'),
       ('Health'),
       ('Entertainment');

INSERT INTO News (Title, Content, Author, PublicDate, Status, CategoryId)
VALUES ('AI đang thay đổi thế giới', '{
  "body": "Trí tuệ nhân tạo đang thay đổi cách chúng ta làm việc."
}', 1, NOW(), 1, 1),
       ('Học lập trình từ con số 0', '{
         "body": "Lập trình không khó nếu bạn biết bắt đầu từ đâu."
       }', 2, NOW(), 1, 2),
       ('Thị trường chứng khoán 2025', '{
         "body": "Thị trường tài chính có nhiều biến động."
       }', 3, NOW(), 1, 3),
       ('Cách sống khỏe mạnh', '{
         "body": "Ăn uống lành mạnh và tập thể dục giúp cải thiện sức khỏe."
       }', 4, NOW(), 1, 4),
       ('Top 10 bộ phim đáng xem năm nay', '{
         "body": "Danh sách phim hấp dẫn bạn không thể bỏ qua."
       }', 5, NOW(), 1, 5);

INSERT INTO CapstoneWorkspace (Name, Status, StartDate, EndDate, WorkspaceCode)
VALUES ('AI Research', 1, '2024-01-01', '2024-06-30', 'AI2024'),
       ('Blockchain Development', 1, '2024-02-01', '2024-07-30', 'BC2024'),
       ('HealthTech Innovations', 1, '2024-03-01', '2024-08-30', 'HT2024');

INSERT INTO TaskBoard (Title, Description, Status, CapstoneWorkspaceId)
VALUES ('Nghiên cứu AI', 'Phát triển mô hình AI thông minh.', 1, 1),
       ('Phát triển Blockchain', 'Xây dựng hệ thống blockchain mới.', 1, 2),
       ('Ứng dụng sức khỏe', 'Thiết kế ứng dụng theo dõi sức khỏe.', 1, 3);

INSERT INTO TaskList (ListName, Position, TaskBoardId)
VALUES ('Việc cần làm', 1, 1),
       ('Đang thực hiện', 2, 1),
       ('Hoàn thành', 3, 1),
       ('Việc cần làm', 1, 2),
       ('Đang thực hiện', 2, 2),
       ('Hoàn thành', 3, 2),
       ('Việc cần làm', 1, 3),
       ('Đang thực hiện', 2, 3),
       ('Hoàn thành', 3, 3);

INSERT INTO `Lecturer` (`Major`, `University`, `Campus`, `Experience`, `Description`, `UserId`)
VALUES 
('Computer Science', 'Harvard University', 'Main Campus', '5 years of teaching AI', 'Expert in Machine Learning', 1),
('Software Engineering', 'Stanford University', 'West Campus', '3 years of software development', 'Specializes in web development', 2),
('Data Science', 'MIT', 'North Campus', '7 years of data analysis', 'Focus on big data and AI', 3),
('Information Technology', 'University of Oxford', 'South Campus', '10 years of research', 'Leading expert in cybersecurity', 4);

INSERT INTO `LecturerWorkspace` (`WorkspaceId`, `LecturerId`)
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4);

INSERT INTO `Student` (`Major`, `University`, `Campus`, `SchoolYear`, `IsGraduated`, `StudentCard`, `CapstoneWorkspaceId`, `UserId`)
VALUES 
('Computer Science', 'Harvard University', 'Main Campus', 2025, FALSE, 'SC12345', 1, 1),
('Software Engineering', 'Stanford University', 'West Campus', 2024, TRUE, 'SC12346', 2, 2),
('Data Science', 'MIT', 'North Campus', 2023, FALSE, 'SC12347', 3, 3),
('Information Technology', 'University of Oxford', 'South Campus', 2026, TRUE, 'SC12348', 4, 4);

INSERT INTO CapstoneTopic
(CapstoneTopicId, Title, Status, SendTime, ResponseTime, ResponseBy, ResponseMessage, Content, CapstoneWorkspaceId) 
VALUES 
(1, 'Đề tài tốt nghiệp 1', 0, '2025-03-28 08:30:00', NULL, 'Lecturer', NULL, '/uploads/CapstoneTopic1.pdf', 1),

(2, 'Đề tài tốt nghiệp 2', 1, '2025-03-27 14:15:00', '2025-03-28 10:00:00', 'Admin', 'Đề tài đã được duyệt', '/uploads/CapstoneTopic2.pdf', 2),

(3, 'Đề tài tốt nghiệp 3', 2, '2025-03-26 09:45:00', '2025-03-27 15:30:00', 'Supervisor', 'Đề tài bị từ chối do không hợp lệ', '/uploads/CapstoneTopic3.pdf', 1);
