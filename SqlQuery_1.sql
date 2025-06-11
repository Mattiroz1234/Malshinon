CREATE DATABASE IF NOT EXISTS Malshinon; 

USE Malshinon;

CREATE TABLE IF NOT EXISTS People(
    id INT PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(32) NOT NULL,
    last_name VARCHAR(32) NOT NULL,
    secret_code VARCHAR(5) UNIQUE NOT NULL,
    type ENUM('reporter', 'target', 'both', 'potential_agent') NOT NULL, 
    num_reports INT(3) DEFAULT 0,
    num_mentions INT(3) DEFAULT 0
);

CREATE TABLE IF NOT EXISTS IntelReports(
	id INT AUTO_INCREMENT PRIMARY KEY, 
    reporter_id INT NOT NULL,
    target_id INT NOT NULL,
    text TEXT(256) NOT NULL,
    timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY(reporter_id) REFERENCES People(id),
    FOREIGN KEY(target_id) REFERENCES People(id)
); 

CREATE TABLE IF NOT EXISTS Alerts(
	id INT AUTO_INCREMENT PRIMARY KEY, 
    target_id INT NOT NULL,
    timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
    reason VARCHAR(256) NOT NULL,
    FOREIGN KEY(target_id) REFERENCES People(id)
); 