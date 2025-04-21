create database BookManagement_db;
use BookManagement_db;

CREATE TABLE Users (
    user_id INT PRIMARY KEY IDENTITY(1,1),
 full_name NVARCHAR(50) NOT NULL,
    password VARCHAR(255) NOT NULL,
    phone_number VARCHAR(15) NOT NULL UNIQUE, -- Thay email b?ng s? ?i?n tho?i
    address NVARCHAR(255) NULL, -- ??a ch? có th? ?? tr?ng
    gender CHAR(1) CHECK (gender IN ('M', 'F', 'O')), -- 'M' (Nam), 'F' (N?), 'O' (Khác)
    personal_id VARCHAR(20) NOT NULL UNIQUE, -- Ch?ng minh nhân dân (ho?c CCCD)
    role VARCHAR(10) CHECK (role IN ('admin', 'staff')) DEFAULT 'staff',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Bảng Categories để lưu danh mục sách
CREATE TABLE Categories (
    category_id INT PRIMARY KEY,
    category_name NVARCHAR(100) NOT NULL UNIQUE, -- Tên thể loại không được trùng
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Categories (category_id, category_name)
VALUES (1, N'Truyện tranh');

INSERT INTO Categories (category_id, category_name)
VALUES (2, N'Truyện chữ');

INSERT INTO Categories (category_id, category_name)
VALUES (3, N'Bút bi');

select * from Categories;


CREATE TABLE Units (
    unit_id INT PRIMARY KEY,
    unit_name NVARCHAR(50) NOT NULL,
    category_id INT NOT NULL,  -- Liên kết với Categories
    FOREIGN KEY (category_id) REFERENCES Categories(category_id) ON DELETE CASCADE
);

INSERT INTO Units (unit_id, unit_name, category_id)
VALUES 
    (1, N'Quyển', 1),
    (2, N'Tập', 1),
    (3, N'Hộp', 1),
    (4, N'Bộ', 1);




CREATE TABLE Products (
    product_id INT PRIMARY KEY, 
    product_name NVARCHAR(255) NOT NULL,
    category_id INT NOT NULL,
    unit_id INT NOT NULL,
    price DECIMAL(20,3) NOT NULL CHECK (price >= 0),
    stock_quantity INT NOT NULL CHECK (stock_quantity >= 0),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,

    -- Khi cập nhật category_id trong Categories, Products cũng cập nhật theo
    -- Khi xóa category_id, SQL Server sẽ không cho phép xóa nếu có Products liên quan
    FOREIGN KEY (category_id) REFERENCES Categories(category_id) 
    ON DELETE NO ACTION ON UPDATE CASCADE,

    -- Khi cập nhật unit_id trong Units, Products cũng cập nhật theo
    -- Khi xóa unit_id, SQL Server sẽ không cho phép xóa nếu có Products liên quan
    FOREIGN KEY (unit_id) REFERENCES Units(unit_id) 
    ON DELETE NO ACTION ON UPDATE CASCADE
);

SELECT u.unit_id, c.category_id, c.category_name, u.unit_name 
FROM Units u
JOIN Categories c ON u.category_id = c.category_id;

-- drop table Products;
-- drop table Units;
-- drop table Categories;
-- drop table Product_Transactions;
CREATE TABLE Product_Transactions (
    transaction_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NOT NULL,
    product_id INT NOT NULL,
    action_type VARCHAR(10) CHECK (action_type IN ('add', 'remove', 'update')),
    quantity INT CHECK (quantity > 0),
    transaction_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);


CREATE TABLE Orders (
    order_id VARCHAR(20) PRIMARY KEY,  -- Mã đơn hàng BHYYYYMMDD_X
    user_id INT NOT NULL,  -- Nhân viên tạo đơn hàng
    total_price DECIMAL(20,3) NOT NULL CHECK (total_price >= 0), -- Tổng giá trị đơn hàng
    order_date DATETIME DEFAULT CURRENT_TIMESTAMP,  -- Ngày đặt hàng
    FOREIGN KEY (user_id) REFERENCES Users(user_id) -- Liên kết nhân viên
);


CREATE TABLE Order_Details (
    order_detail_id INT PRIMARY KEY IDENTITY(1,1),  -- Khóa chính tự tăng
    order_id VARCHAR(20) NOT NULL,  -- Mã đơn hàng (liên kết với Orders)
    product_id INT NOT NULL,  -- Sản phẩm được mua
    quantity INT NOT NULL CHECK (quantity > 0),  -- Số lượng sản phẩm
    unit_price DECIMAL(20,3) NOT NULL CHECK (unit_price >= 0),  -- Giá tại thời điểm mua
    total_price AS (quantity * unit_price) PERSISTED,  -- Tự động tính tổng tiền

    FOREIGN KEY (order_id) REFERENCES Orders(order_id) ON DELETE CASCADE,
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

UPDATE users 
SET role = 'staff' 
WHERE phone_number = '0985036565' AND role = 'admin';
UPDATE users 
SET role = 'admin' 
WHERE phone_number = '0123456789';

ALTER TABLE Units
ADD last_updated_at DATETIME NULL;
EXEC sp_rename 'Categories.created_at', 'last_updated_at', 'COLUMN';


CREATE TABLE Attendance (
    attendance_id INT PRIMARY KEY IDENTITY(1,1),     -- Attendance ID
    user_id INT NOT NULL,                            -- Employee ID
    shift_id INT NOT NULL,                           -- Shift ID
    work_date DATE NOT NULL,                         -- Work date

    checkin_time DATETIME NULL,                      -- Check-in time
    status NVARCHAR(20) NOT NULL                     -- Vietnamese status
        CHECK (status IN (N'Chưa điểm danh', N'Có mặt', N'Đi trễ', N'Vắng')),

    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,   -- Record creation time
    updated_at DATETIME NULL,                        -- Last updated time

    FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (shift_id) REFERENCES Shifts(shift_id) ON DELETE CASCADE
);

select * from Users;
select * from Categories;
select * from Products;
select * from Units;
select * from Orders;
select * from Order_Details;

CREATE TABLE Shifts (
    shift_id INT PRIMARY KEY IDENTITY(1,1),  -- ID ca làm
    shift_name NVARCHAR(50) NOT NULL,        -- Tên ca (ví dụ: Ca sáng, Ca chiều)
    start_time TIME NOT NULL,                -- Thời gian bắt đầu ca
    end_time TIME NOT NULL,                  -- Thời gian kết thúc ca
    
);

INSERT INTO Attendance (user_id, shift_id, work_date, checkin_time, status)
VALUES 
(1, 1, '2025-10-01', '2025-10-01 07:05:00', N'Có mặt'),
(2, 2, '2025-10-02', '2025-10-02 14:15:00', N'Đi trễ'),
(3, 3, '2025-10-03', NULL, N'Vắng');


CREATE TABLE Shift_Schedule (
    schedule_id INT PRIMARY KEY IDENTITY(1,1), -- ID lịch làm việc
    user_id INT NOT NULL,                      -- ID nhân viên
    shift_id INT NOT NULL,                     -- ID ca làm
    work_date DATE NOT NULL,                   -- Ngày làm việc
    FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (shift_id) REFERENCES Shifts(shift_id) ON DELETE CASCADE
);

INSERT INTO Shifts (shift_name, start_time, end_time)
VALUES
(N'Ca sáng', '08:00:00', '12:00:00'),
(N'Ca chiều', '13:00:00', '17:00:00'),
(N'Ca tối', '18:00:00', '22:00:00');

-- Lịch làm việc cho user_id = 1 (Nguyễn Văn A)
INSERT INTO Shift_Schedule (user_id, shift_id, work_date,)
VALUES
(1, 1, '2023-10-01'),
(1, 2, '2023-10-02'),
(1, 3, '2023-10-03');

-- Lịch làm việc cho user_id = 2 (Lê Thị B)
INSERT INTO Shift_Schedule (user_id, shift_id, work_date)
VALUES
(2, 1, '2023-10-01'),
(2, 1, '2023-10-02'),
(2, 3, '2023-10-03');



-- Make sure the Users table is empty or IDs won't collide
-- user_id is an IDENTITY, so it increments automatically

INSERT INTO Users (full_name, password, phone_number, address, gender, personal_id, role)
VALUES
(N'Nguyễn Văn A', 'someHash1', '0901234567', N'123 Phan Văn Trị, Gò Vấp', 'M', '0123456789', 'admin'),
(N'Lê Thị B', 'someHash2', '0987654321', N'45 Lý Thường Kiệt, Q10', 'F', '9876543210', 'staff'),
(N'Trần Văn C', 'someHash3', '0975036565', N'56 Quang Trung, Q12', 'M', '1239874560', 'staff');

INSERT INTO Products (product_id, product_name, category_id, unit_id, price, stock_quantity)
VALUES
(101, N'Doraemon tập 1', 1, 1, 25000, 100),   -- Category 1 (Truyện tranh), Unit 1 (Quyển)
(102, N'Doraemon tập 2', 1, 1, 25000, 50),
(103, N'Bút bi Thiên Long', 3, 3, 5000, 200), -- Category 3 (Bút bi), Unit 3 (Hộp)
(104, N'Tiểu thuyết Kiều', 2, 1, 35000, 30),  -- Category 2 (Truyện chữ), Unit 1 (Quyển)
(105, N'Bút bi Panda', 3, 3, 7000, 100),      -- Category 3 (Bút bi), Unit 3 (Hộp)
(106, N'Truyện tranh One Piece', 1, 1, 30000, 70),
(107, N'Truyện chữ Harry Potter', 2, 4, 80000, 10); -- Category 2, Unit 4 (Bộ)

INSERT INTO Product_Transactions (user_id, product_id, action_type, quantity, transaction_date)
VALUES
(2, 101, 'add',    20, '2025-03-10 10:00:00'),  -- Staff (user_id=2) added 20 Doraemon tập 1
(2, 102, 'add',    10, '2025-03-10 10:05:00'),  -- Staff added 10 Doraemon tập 2
(3, 103, 'remove',  5, '2025-03-11 09:00:00'),  -- Staff (user_id=3) removed 5 Bút bi Thiên Long
(2, 104, 'update',  3, '2025-03-12 14:30:00'),  -- Possibly changed something about Tiểu thuyết Kiều
(3, 101, 'remove',  2, '2025-03-13 16:45:00'),  -- Staff removed 2 Doraemon tập 1
(2, 105, 'add',    50, '2025-03-13 18:00:00'),  -- Staff added 50 Bút bi Panda
(3, 106, 'add',    10, '2025-03-14 09:15:00');  -- Staff added 10 One Piece

INSERT INTO Orders (order_id, user_id, total_price, order_date)
VALUES
('BH20250314_001', 2, 125000, '2025-03-14 09:30:00'),  -- Created by user_id=2
('BH20250314_002', 3,  45000, '2025-03-14 10:15:00');  -- Created by user_id=3

INSERT INTO Order_Details (order_id, product_id, quantity, unit_price)
VALUES
('BH20250314_001', 101, 2, 25000),  -- 2 Doraemon tập 1 @ 25k => total_price=50k
('BH20250314_001', 104, 1, 35000),  -- 1 Tiểu thuyết Kiều @ 35k => total_price=35k
('BH20250314_002', 103, 3, 5000);   -- 3 Bút bi Thiên Long @ 5k => total_price=15k

