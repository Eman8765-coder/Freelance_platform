-- ============================================================
-- SkillLink Freelance Platform — Database Creation Script
-- Course: Visual Programming (CS-412)
-- Student: Eman Fatima — 2024-ag-5381
-- Database: MySQL 8.0
-- ============================================================

CREATE DATABASE IF NOT EXISTS FreelancePlatform;
USE FreelancePlatform;

-- ── Table 1: Users ──────────────────────────────────────────
CREATE TABLE IF NOT EXISTS Users (
    user_id       INT PRIMARY KEY AUTO_INCREMENT,
    first_name    VARCHAR(50)  NOT NULL,
    last_name     VARCHAR(50)  NOT NULL,
    email         VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    phone         VARCHAR(20),
    role          ENUM('client','freelancer') NOT NULL,
    is_active     TINYINT DEFAULT 1,
    created_date  DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- ── Table 2: Clients ────────────────────────────────────────
CREATE TABLE IF NOT EXISTS Clients (
    client_id    INT PRIMARY KEY AUTO_INCREMENT,
    user_id      INT NOT NULL,
    company_name VARCHAR(100),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

-- ── Table 3: Freelancers ─────────────────────────────────────
CREATE TABLE IF NOT EXISTS Freelancers (
    freelancer_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id       INT NOT NULL,
    experience    VARCHAR(200),
    hourly_rate   DECIMAL(8,2) DEFAULT 0,
    rating        DECIMAL(3,2) DEFAULT 0,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

-- ── Table 4: Skills ──────────────────────────────────────────
CREATE TABLE IF NOT EXISTS Skills (
    skill_id      INT PRIMARY KEY AUTO_INCREMENT,
    freelancer_id INT NOT NULL,
    skill_name    VARCHAR(100) NOT NULL,
    FOREIGN KEY (freelancer_id) REFERENCES Freelancers(freelancer_id)
);

-- ── Table 5: Projects ────────────────────────────────────────
CREATE TABLE IF NOT EXISTS Projects (
    project_id  INT PRIMARY KEY AUTO_INCREMENT,
    client_id   INT NOT NULL,
    title       VARCHAR(150) NOT NULL,
    description TEXT,
    budget      DECIMAL(10,2),
    deadline    DATE,
    status      ENUM('open','in-progress','completed','closed') DEFAULT 'open',
    FOREIGN KEY (client_id) REFERENCES Clients(client_id)
);

-- ── Table 6: Bids ────────────────────────────────────────────
CREATE TABLE IF NOT EXISTS Bids (
    bid_id        INT PRIMARY KEY AUTO_INCREMENT,
    project_id    INT NOT NULL,
    freelancer_id INT NOT NULL,
    bid_amount    DECIMAL(10,2),
    proposal      TEXT,
    bid_date      DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (project_id)    REFERENCES Projects(project_id),
    FOREIGN KEY (freelancer_id) REFERENCES Freelancers(freelancer_id)
);

-- ── Table 7: Contracts ───────────────────────────────────────
CREATE TABLE IF NOT EXISTS Contracts (
    contract_id   INT PRIMARY KEY AUTO_INCREMENT,
    project_id    INT NOT NULL,
    freelancer_id INT NOT NULL,
    start_date    DATE,
    end_date      DATE,
    status        ENUM('active','completed','cancelled') DEFAULT 'active',
    FOREIGN KEY (project_id)    REFERENCES Projects(project_id),
    FOREIGN KEY (freelancer_id) REFERENCES Freelancers(freelancer_id)
);

-- ── Table 8: Payments ────────────────────────────────────────
CREATE TABLE IF NOT EXISTS Payments (
    payment_id     INT PRIMARY KEY AUTO_INCREMENT,
    contract_id    INT NOT NULL,
    amount         DECIMAL(10,2),
    payment_date   DATETIME DEFAULT CURRENT_TIMESTAMP,
    payment_method VARCHAR(50),
    FOREIGN KEY (contract_id) REFERENCES Contracts(contract_id)
);

-- ── Table 9: Reviews ─────────────────────────────────────────
CREATE TABLE IF NOT EXISTS Reviews (
    review_id   INT PRIMARY KEY AUTO_INCREMENT,
    contract_id INT NOT NULL,
    rating      INT CHECK (rating BETWEEN 1 AND 5),
    feedback    TEXT,
    review_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (contract_id) REFERENCES Contracts(contract_id)
);

-- ── Sample Data ───────────────────────────────────────────────
INSERT INTO Users (first_name, last_name, email, password_hash, phone, role)
VALUES
('Ahmed',  'Raza',    'ahmed@test.com',  'hashed_password', '03001234567', 'client'),
('Sara',   'Khan',    'sara@test.com',   'hashed_password', '03219876543', 'freelancer'),
('Fatima', 'Malik',   'fatima@test.com', 'hashed_password', '03451112233', 'client'),
('Usman',  'Ali',     'usman@test.com',  'hashed_password', '03331234567', 'freelancer'),
('Bilal',  'Hassan',  'bilal@test.com',  'hashed_password', '03121234567', 'client');

INSERT INTO Clients (user_id, company_name) VALUES
(1, 'Raza Tech Solutions'),
(3, 'Malik Enterprises'),
(5, 'Hassan Digital');

INSERT INTO Freelancers (user_id, experience, hourly_rate, rating) VALUES
(2, '3 years web development',       2500, 4.5),
(4, '5 years graphic design',        3000, 4.8);

INSERT INTO Projects (client_id, title, description, budget, deadline, status) VALUES
(1, 'E-Commerce Website',        'Need a complete online store',          150000, '2025-08-30', 'open'),
(2, 'Company Logo and Branding', 'Need professional logo design',          50000, '2025-07-15', 'open'),
(3, 'Food Delivery Mobile App',  'Android and iOS food delivery app',     300000, '2025-10-01', 'open');

INSERT INTO Bids (project_id, freelancer_id, bid_amount, proposal) VALUES
(1, 1, 120000, 'I have 3 years experience in web development.'),
(2, 2, 45000,  'I am a professional graphic designer with 5 years experience.');

INSERT INTO Contracts (project_id, freelancer_id, start_date, end_date, status) VALUES
(1, 1, '2025-05-01', '2025-08-30', 'active'),
(2, 2, '2025-05-10', '2025-07-15', 'active');

INSERT INTO Payments (contract_id, amount, payment_method) VALUES
(1, 60000, 'JazzCash'),
(2, 45000, 'EasyPaisa');

INSERT INTO Reviews (contract_id, rating, feedback) VALUES
(2, 5, 'Usman delivered excellent logo design work. Highly recommended.');