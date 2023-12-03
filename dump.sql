-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.32-MariaDB-1:10.4.32+maria~ubu2004 - mariadb.org binary distribution
-- Server OS:                    debian-linux-gnu
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

-- Dumping structure for table chathub.admins
CREATE TABLE IF NOT EXISTS `admins` (
  `id` int(11) NOT NULL,
  `fk_user` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `fk_user` (`fk_user`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table chathub.admins: ~2 rows (approximately)
DELETE FROM `admins`;
INSERT INTO `admins` (`id`, `fk_user`) VALUES
	(1, 3),
	(2, 4);

-- Dumping structure for table chathub.channelrequests
CREATE TABLE IF NOT EXISTS `channelrequests` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fk_user` int(11) DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `description` text DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table chathub.channelrequests: ~2 rows (approximately)
DELETE FROM `channelrequests`;
INSERT INTO `channelrequests` (`id`, `fk_user`, `name`, `description`) VALUES
	(1, 4, 'New channel', 'New channel description'),
	(2, 4, 'Audi', 'All about audis');

-- Dumping structure for table chathub.channels
CREATE TABLE IF NOT EXISTS `channels` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `description` text DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table chathub.channels: ~3 rows (approximately)
DELETE FROM `channels`;
INSERT INTO `channels` (`id`, `name`, `description`) VALUES
	(1, 'BMW', 'Everything about BMWs'),
	(2, 'Dogs', 'Every dog owner is welcome here'),
	(3, 'Space', 'Feel spaceious? Hit up here');

-- Dumping structure for table chathub.conversations
CREATE TABLE IF NOT EXISTS `conversations` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `description` text DEFAULT NULL,
  `fk_author` int(11) NOT NULL,
  `fk_channel` int(11) NOT NULL,
  `created` datetime DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table chathub.conversations: ~3 rows (approximately)
DELETE FROM `conversations`;
INSERT INTO `conversations` (`id`, `name`, `description`, `fk_author`, `fk_channel`, `created`) VALUES
	(1, 'Common E60 problems', 'What can be the most common issues for engine issues?', 4, 1, '2023-11-29 14:01:37'),
	(2, 'Cute pics', 'Have a beautiful picture of a dog? Post it here', 4, 2, '2023-11-29 14:02:10'),
	(3, 'Diesel or petrol?', 'Main pros and cons of both world', 4, 1, '2023-11-29 14:02:39');

-- Dumping structure for table chathub.messages
CREATE TABLE IF NOT EXISTS `messages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `text` text DEFAULT NULL,
  `fk_author` int(11) NOT NULL,
  `fk_conversation` int(11) NOT NULL,
  `created` datetime DEFAULT current_timestamp(),
  `edited` tinyint(4) DEFAULT 0,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table chathub.messages: ~2 rows (approximately)
DELETE FROM `messages`;
INSERT INTO `messages` (`id`, `text`, `fk_author`, `fk_conversation`, `created`, `edited`) VALUES
	(1, 'Hi there', 4, 1, '2023-11-29 14:02:55', 0),
	(2, 'Does anyone have e60 with 2.5l diesel engine?', 4, 1, '2023-11-29 14:03:32', 0);

-- Dumping structure for table chathub.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` text NOT NULL,
  `email` varchar(50) NOT NULL,
  `forceRelogin` tinyint(1) DEFAULT 0,
  `deactivated` tinyint(1) DEFAULT 0,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table chathub.users: ~3 rows (approximately)
DELETE FROM `users`;
INSERT INTO `users` (`id`, `username`, `password`, `email`, `forceRelogin`, `deactivated`) VALUES
	(2, 'test', '$2a$11$vwVRKl4sLQa.cSuj4Ya7IOCdyLKmKAjXjhNd6POPiEs8wWqZj4G2u', 'test@test.com', 0, 0),
	(3, 'postman_user', '$2a$11$ko.zPTmEU7lyw6x0VOVFrutPcdy0ZfD.bPjaGmtsi81arSiyAxf.u', 'postman@forum.test', 0, 0),
	(4, 'admin', '$2a$11$eylY1rt8BeO7Kxojtnk5VeotTutDsE/vKwE67fALIm4WmlM78D7Da', 'admin@chathub.com', 0, 0);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
