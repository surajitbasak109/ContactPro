/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 50550
 Source Host           : localhost:3306
 Source Schema         : contactpro

 Target Server Type    : MySQL
 Target Server Version : 50550
 File Encoding         : 65001

 Date: 16/12/2019 15:56:15
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for tbl_constituency
-- ----------------------------
DROP TABLE IF EXISTS `tbl_constituency`;
CREATE TABLE `tbl_constituency`  (
  `id` int(11) NOT NULL,
  `code` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `id`(`id`, `code`) USING BTREE,
  INDEX `code`(`code`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of tbl_constituency
-- ----------------------------
INSERT INTO `tbl_constituency` VALUES (1, '001', 'Test 1');
INSERT INTO `tbl_constituency` VALUES (2, '002', 'Test 2');

-- ----------------------------
-- Table structure for tbl_district
-- ----------------------------
DROP TABLE IF EXISTS `tbl_district`;
CREATE TABLE `tbl_district`  (
  `id` int(11) NOT NULL,
  `code` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `id`(`id`, `code`) USING BTREE,
  INDEX `code`(`code`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of tbl_district
-- ----------------------------
INSERT INTO `tbl_district` VALUES (1, '001', 'Jalpaiguri');
INSERT INTO `tbl_district` VALUES (2, '002', 'Darjeeling');
INSERT INTO `tbl_district` VALUES (3, '003', 'Birbhum');
INSERT INTO `tbl_district` VALUES (4, '004', 'Coochbehar');
INSERT INTO `tbl_district` VALUES (5, '005', 'Kolkata');
INSERT INTO `tbl_district` VALUES (6, '006', 'Nadia');
INSERT INTO `tbl_district` VALUES (7, '007', 'Murshidabad');
INSERT INTO `tbl_district` VALUES (8, '008', 'North 24 Pargana');
INSERT INTO `tbl_district` VALUES (9, '009', 'South 24 Pargana');
INSERT INTO `tbl_district` VALUES (10, '010', 'Alipurduar');
INSERT INTO `tbl_district` VALUES (11, '011', 'Bankura');
INSERT INTO `tbl_district` VALUES (12, '012', 'Uttar Dinajpur');
INSERT INTO `tbl_district` VALUES (13, '013', 'Dakshin Dinajpur');
INSERT INTO `tbl_district` VALUES (14, '014', 'Hooghly');
INSERT INTO `tbl_district` VALUES (15, '015', 'Howrah');

-- ----------------------------
-- Table structure for tbl_membership
-- ----------------------------
DROP TABLE IF EXISTS `tbl_membership`;
CREATE TABLE `tbl_membership`  (
  `id` int(11) NOT NULL,
  `code` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `person_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `dob` date NULL DEFAULT NULL,
  `father_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `gender` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `add1` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `add2` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `city` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `district_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `district` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `panchayat_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `panchayat` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `const_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `const` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `mobile` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `id`(`id`, `code`) USING BTREE,
  INDEX `fk_district`(`district_code`) USING BTREE,
  INDEX `fk_panchayt`(`panchayat_code`) USING BTREE,
  INDEX `fk_constituency`(`const_code`) USING BTREE,
  CONSTRAINT `fk_constituency` FOREIGN KEY (`const_code`) REFERENCES `tbl_constituency` (`code`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_district` FOREIGN KEY (`district_code`) REFERENCES `tbl_district` (`code`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_panchayt` FOREIGN KEY (`panchayat_code`) REFERENCES `tbl_panchayat` (`code`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of tbl_membership
-- ----------------------------
INSERT INTO `tbl_membership` VALUES (1, '001', 'Surajit Basak', '1989-02-06', 'Bhupen Basak', 'Male', 'Chayan Para', 'Kali Saha More', 'Siliguri', '001', NULL, '001', '', '001', NULL, '9749129271', NULL);
INSERT INTO `tbl_membership` VALUES (2, '002', 'Ajay Saha', '2019-12-16', 'Moni Saha', 'Male', 'Fulbari', '', 'Siliguri', '002', 'Darjeeling', '001', 'Test 1', '002', 'Test 2', '9532658515', '2019-12-16 12:54:04');

-- ----------------------------
-- Table structure for tbl_panchayat
-- ----------------------------
DROP TABLE IF EXISTS `tbl_panchayat`;
CREATE TABLE `tbl_panchayat`  (
  `id` int(11) NOT NULL,
  `code` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `id`(`id`, `code`) USING BTREE,
  INDEX `code`(`code`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of tbl_panchayat
-- ----------------------------
INSERT INTO `tbl_panchayat` VALUES (1, '001', 'Test 1');
INSERT INTO `tbl_panchayat` VALUES (2, '002', 'Test 2');
INSERT INTO `tbl_panchayat` VALUES (3, '003', 'Test 3');

-- ----------------------------
-- Procedure structure for getConstituencies
-- ----------------------------
DROP PROCEDURE IF EXISTS `getConstituencies`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getConstituencies`()
BEGIN
	#Routine body goes here...
	SELECT name, code FROM tbl_constituency;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getConstituencyName
-- ----------------------------
DROP PROCEDURE IF EXISTS `getConstituencyName`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getConstituencyName`(IN `const_code` varchar(255))
BEGIN
	SELECT name FROM tbl_constituency WHERE code = const_code;

END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getDistrictName
-- ----------------------------
DROP PROCEDURE IF EXISTS `getDistrictName`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getDistrictName`(IN `distcode` varchar(255))
BEGIN
	#Routine body goes here...
	SELECT name FROM tbl_district WHERE code = distcode;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getDistricts
-- ----------------------------
DROP PROCEDURE IF EXISTS `getDistricts`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getDistricts`()
BEGIN
	#Routine body goes here...
	SELECT name, code FROM tbl_district;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getPanchayatName
-- ----------------------------
DROP PROCEDURE IF EXISTS `getPanchayatName`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getPanchayatName`(IN `panchayat_code` varchar(255))
BEGIN
	SELECT name FROM tbl_panchayat WHERE code = panchayat_code;

END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for getPanchayats
-- ----------------------------
DROP PROCEDURE IF EXISTS `getPanchayats`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getPanchayats`()
BEGIN
	#Routine body goes here...
	SELECT name, code FROM tbl_panchayat;
END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
