-- =============================================
-- Rick & Morty Explorer Database Script
-- =============================================

-- Create database
CREATE DATABASE IF NOT EXISTS rickmorty
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_0900_ai_ci;

-- Select database
USE rickmorty;

-- Drop table if exists (for clean install)
DROP TABLE IF EXISTS `Characters`;

-- Create table
CREATE TABLE `Characters` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Species` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Image` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Location` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastSync` datetime(6) NOT NULL,
  `Episodes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB
  DEFAULT CHARSET=utf8mb4
  COLLATE=utf8mb4_0900_ai_ci;
