USE MentorLink;

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