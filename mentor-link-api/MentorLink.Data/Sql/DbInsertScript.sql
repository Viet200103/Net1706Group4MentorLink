USE MentorLink;

INSERT INTO News (Title, Content, Author, PublicDate, Category, Status, UpdateStatus) VALUES
('Bài viết đầu tiên', '{"text": "Đây là nội dung bài viết đầu tiên"}', 1, '2025-03-27 10:00:00', 'Công nghệ', 1, 1),
('Hướng dẫn lập trình', '{"text": "Lập trình là một kỹ năng quan trọng"}', 2, '2025-03-26 15:30:00', 'Học tập', 0, 0),
('Tin tức mới nhất', '{"text": "Tin nóng hổi vừa thổi vừa đọc"}', 3, '2025-03-27 08:45:00', 'Thời sự', 2, 1),
('Sự kiện tháng 4', '{"text": "Chuỗi sự kiện đặc biệt tháng 4"}', 1, '2025-04-01 09:00:00', 'Sự kiện', 1, 1),
('Giới thiệu MentorLink', '{"text": "MentorLink giúp kết nối sinh viên với mentor"}', 2, '2025-03-25 14:20:00', 'Giáo dục', 1, 0);

INSERT INTO CapstoneWorkspace (Name, Status, StartDate, EndDate, WorkspaceCode) 
VALUES 
('Phát triển phần mềm', 'Đang hoạt động', '2024-01-01', '2024-12-31', 'PTPM2024'),
('Chiến lược Marketing', 'Đang hoạt động', '2024-02-01', '2024-11-30', 'CLM2024'),
('Thiết kế sản phẩm', 'Không hoạt động', '2023-05-01', '2023-12-31', 'TKSP2023');

INSERT INTO TaskBoard (Title, Description, Status, CapstoneWorkspaceId) 
VALUES 
('Bảng Sprint 1', 'Bảng công việc cho Sprint 1', 'Đang hoạt động', 1),
('Kế hoạch Marketing', 'Bảng quản lý các công việc trong chiến dịch marketing', 'Đang hoạt động', 2),
('Bảng thiết kế UI', 'Nhiệm vụ liên quan đến thiết kế giao diện', 'Không hoạt động', 3);

INSERT INTO TaskList (ListName, Position, TaskBoardId) 
VALUES 
('Việc cần làm', 1, 1),
('Đang thực hiện', 2, 1),
('Hoàn thành', 3, 1),
('Ý tưởng', 1, 2),
('Thực thi', 2, 2),
('Kiểm thử', 1, 3),
('Xem xét cuối cùng', 2, 3);

