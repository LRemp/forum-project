-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.11.5-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.3.0.6589
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for chathub
CREATE DATABASE IF NOT EXISTS `chathub` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci */;
USE `chathub`;

-- Dumping structure for table chathub.channels
CREATE TABLE IF NOT EXISTS `channels` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `description` text DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table chathub.channels: ~3 rows (approximately)
DELETE FROM `channels`;
INSERT INTO `channels` (`id`, `name`, `description`) VALUES
	(25, NULL, 'new desc'),
	(26, 'string', 'brand new dedsc'),
	(30, 'Automotive', 'Thread to disccuss all about car culture');

-- Dumping structure for table chathub.conversations
CREATE TABLE IF NOT EXISTS `conversations` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `description` text DEFAULT NULL,
  `fk_author` int(11) NOT NULL,
  `fk_channel` int(11) NOT NULL,
  `created` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table chathub.conversations: ~2 rows (approximately)
DELETE FROM `conversations`;
INSERT INTO `conversations` (`id`, `name`, `description`, `fk_author`, `fk_channel`, `created`) VALUES
	(1, 'new convo', 'test', 0, 26, NULL),
	(2, 'BMW', 'All about BMWs', 0, 30, NULL),
	(4, 'Audi', 'All about Audi\'s', 0, 30, NULL);

-- Dumping structure for table chathub.messages
CREATE TABLE IF NOT EXISTS `messages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `text` text DEFAULT NULL,
  `fk_author` int(11) NOT NULL,
  `fk_conversation` int(11) NOT NULL,
  `created` datetime DEFAULT current_timestamp(),
  `edited` tinyint(4) DEFAULT 0,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table chathub.messages: ~6 rows (approximately)
DELETE FROM `messages`;
INSERT INTO `messages` (`id`, `text`, `fk_author`, `fk_conversation`, `created`, `edited`) VALUES
	(4, 'Hi there', 1, 0, NULL, 0),
	(5, 'Hi there', 1, 0, NULL, 0),
	(6, 'Hi there', 1, 0, '2023-10-09 12:03:39', 0),
	(7, 'Hi there', 1, 2, '2023-10-09 12:05:50', 0),
	(8, 'This is an updated message', 1, 2, '2023-10-09 12:11:39', 0);

-- Dumping structure for table chathub.user
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table chathub.user: ~0 rows (approximately)
DELETE FROM `user`;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
