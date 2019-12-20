-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2019. Dec 20. 19:26
-- Kiszolgáló verziója: 10.4.6-MariaDB
-- PHP verzió: 7.3.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `ingatlan_centrum`
--

DROP DATABASE IF EXISTS `ingatlan_centrum`;
CREATE DATABASE IF NOT EXISTS `ingatlan_centrum` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `ingatlan_centrum`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `eladok`
--

DROP TABLE IF EXISTS `eladok`;
CREATE TABLE IF NOT EXISTS `eladok` (
  `azonosito` int(11) NOT NULL AUTO_INCREMENT,
  `vezeteknev` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  `keresztnev` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  `adoszam` int(10) NOT NULL,
  `telepules` int(11) NOT NULL,
  `lakcim` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  `telefonszam` varchar(11) COLLATE utf8_hungarian_ci NOT NULL,
  `email` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`azonosito`),
  KEY `telepules` (`telepules`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `eladok`
--

INSERT INTO `eladok` (`azonosito`, `vezeteknev`, `keresztnev`, `adoszam`, `telepules`, `lakcim`, `telefonszam`, `email`) VALUES
(1, 'Jakab', 'Csaba', 2147483647, 5, 'Jászai Mari tér 12', '06309241515', 'jcsaba@gmail.com'),
(2, 'Latinovits', 'Zoltán', 2147483647, 34, 'Balatoni utca 7', '0613125553', 'zoltanaszinesz@citromail.hu'),
(3, 'Stohl', 'András', 2147483647, 21, 'Kiskunság utca 5', '06705558965', 'tequila@freemail.hu'),
(4, 'Dayka', 'Margit', 2147483647, 11, 'Nagyerdő 7', '06206667266', 'dayka1907@gmail.com'),
(5, 'Rudolf', 'Péter', 2147483647, 2, 'Könyves Kálmán körút 77', '06205267822', 'pepe5@freemail.hu'),
(6, 'Somlai', 'Edina', 2147483647, 7, 'Erős János utca 3', '06302802719', 'edobaba@gmail.com');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ingatlanok`
--

DROP TABLE IF EXISTS `ingatlanok`;
CREATE TABLE IF NOT EXISTS `ingatlanok` (
  `azonosito` int(11) NOT NULL AUTO_INCREMENT,
  `leiras` varchar(150) COLLATE utf8_hungarian_ci NOT NULL,
  `tulajdonos` int(11) NOT NULL,
  `telepules` int(11) NOT NULL,
  `ar` int(11) NOT NULL,
  `alapterulet` int(11) NOT NULL,
  `kategoria` int(11) NOT NULL,
  `allapot` int(11) NOT NULL,
  `ugynok` varchar(6) COLLATE utf8_hungarian_ci NOT NULL,
  `meghirdetve` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  `eladva` varchar(10) COLLATE utf8_hungarian_ci DEFAULT NULL,
  PRIMARY KEY (`azonosito`),
  KEY `tulajdonos` (`tulajdonos`),
  KEY `telepules` (`telepules`),
  KEY `kategoria` (`kategoria`),
  KEY `allapot` (`allapot`),
  KEY `ugynok` (`ugynok`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ingatlanok`
--

INSERT INTO `ingatlanok` (`azonosito`, `leiras`, `tulajdonos`, `telepules`, `ar`, `alapterulet`, `kategoria`, `allapot`, `ugynok`, `meghirdetve`, `eladva`) VALUES
(1, 'Nagy ház', 5, 32, 12000000, 1234, 4, 2, 'XYZ987', '2019-08-14', '0000-00-00'),
(2, 'Kis panellakás a városban!', 6, 42, 2000000, 1356, 1, 1, 'ABC123', '2019-08-14', '0000-00-00'),
(3, 'Nagy villa', 1, 26, 12000000, 13000, 2, 2, 'XYZ987', '2019-07-11', '0000-00-00'),
(4, 'Kis Panel', 4, 50, 17000000, 35, 1, 2, 'ABC123', '2019-07-11', '0000-00-00'),
(5, 'Családi fészek', 2, 42, 22990990, 148, 6, 2, 'XYZ987', '2019-07-12', '0000-00-00'),
(6, 'Polgári Palota', 5, 52, 49560000, 187, 2, 1, 'ABC123', '2019-07-31', '0000-00-00');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ingatlan_allapotok`
--

DROP TABLE IF EXISTS `ingatlan_allapotok`;
CREATE TABLE IF NOT EXISTS `ingatlan_allapotok` (
  `azonosito` int(11) NOT NULL AUTO_INCREMENT,
  `elnevezes` varchar(25) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`azonosito`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ingatlan_allapotok`
--

INSERT INTO `ingatlan_allapotok` (`azonosito`, `elnevezes`) VALUES
(1, 'új'),
(2, 'használt'),
(3, 'felújítandó');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ingatlan_kategoriak`
--

DROP TABLE IF EXISTS `ingatlan_kategoriak`;
CREATE TABLE IF NOT EXISTS `ingatlan_kategoriak` (
  `azonosito` int(11) NOT NULL AUTO_INCREMENT,
  `elnevezes` varchar(25) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`azonosito`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ingatlan_kategoriak`
--

INSERT INTO `ingatlan_kategoriak` (`azonosito`, `elnevezes`) VALUES
(1, 'panel'),
(2, 'tégla'),
(3, 'bérleti jog'),
(4, 'családi ház'),
(5, 'tanya'),
(6, 'garázs'),
(7, 'kert'),
(8, 'termőföld');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `telepulesek`
--

DROP TABLE IF EXISTS `telepulesek`;
CREATE TABLE IF NOT EXISTS `telepulesek` (
  `azonosito` int(11) NOT NULL AUTO_INCREMENT,
  `nev` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`azonosito`)
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `telepulesek`
--

INSERT INTO `telepulesek` (`azonosito`, `nev`) VALUES
(1, 'Algyő'),
(2, 'Ambrózfalva'),
(3, 'Apátfalva'),
(4, 'Árpádhalom'),
(5, 'Ásotthalom'),
(6, 'Baks'),
(7, 'Balástya'),
(8, 'Bordány'),
(9, 'Csanádalberti'),
(10, 'Csanádpalota'),
(11, 'Csanytelek'),
(12, 'Csengele'),
(13, 'Csongrád'),
(14, 'Derekegyház'),
(15, 'Deszk'),
(16, 'Dóc'),
(17, 'Domaszék'),
(18, 'Eperjes'),
(19, 'Fábiánsebestyén'),
(20, 'Felgyő'),
(21, 'Ferencszállás'),
(22, 'Forráskút'),
(23, 'Földeák'),
(24, 'Hódmezővásárhely'),
(25, 'Kistelek'),
(26, 'Királyhegyes'),
(27, 'Kiszombor'),
(28, 'Klárafalva'),
(29, 'Kövegy'),
(30, 'Kübekháza'),
(31, 'Magyarcsanád'),
(32, 'Makó'),
(33, 'Nagyér'),
(34, 'Nagylak'),
(35, 'Nagymágocs'),
(36, 'Nagytőke'),
(37, 'Óföldeák'),
(38, 'Ópusztaszer'),
(39, 'Pitvaros'),
(40, 'Pusztamérges'),
(41, 'Pusztaszer'),
(42, 'Röszke'),
(43, 'Rúzsa'),
(44, 'Sándorfalva'),
(45, 'Szatymaz'),
(46, 'Szeged'),
(47, 'Szegvár'),
(48, 'Székkutas'),
(49, 'Szentes'),
(50, 'Tiszasziget'),
(51, 'Tömörkény'),
(52, 'Újszantiván'),
(53, 'Üllés'),
(54, 'Zákányszék'),
(55, 'Zsombó');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ugynokok`
--

DROP TABLE IF EXISTS `ugynokok`;
CREATE TABLE IF NOT EXISTS `ugynokok` (
  `azonosito` varchar(6) COLLATE utf8_hungarian_ci NOT NULL,
  `jelszo` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  `vezeteknev` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  `keresztnev` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  `telefonszam` varchar(11) COLLATE utf8_hungarian_ci NOT NULL,
  `kategoria` int(11) NOT NULL,
  `aktiv` tinyint(1) NOT NULL,
  PRIMARY KEY (`azonosito`),
  KEY `kategoria` (`kategoria`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ugynokok`
--

INSERT INTO `ugynokok` (`azonosito`, `jelszo`, `vezeteknev`, `keresztnev`, `telefonszam`, `kategoria`, `aktiv`) VALUES
('ABC123', 'Ugynok12', 'Miklós', 'Árpád', '06202346794', 1, 1),
('XYZ987', 'Ugynok13', 'Teszt', 'Elek', '06302134112', 2, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ugynok_kategoriak`
--

DROP TABLE IF EXISTS `ugynok_kategoriak`;
CREATE TABLE IF NOT EXISTS `ugynok_kategoriak` (
  `azonosito` int(11) NOT NULL AUTO_INCREMENT,
  `elnevezes` varchar(25) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`azonosito`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ugynok_kategoriak`
--

INSERT INTO `ugynok_kategoriak` (`azonosito`, `elnevezes`) VALUES
(1, 'admin'),
(2, 'default');

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `eladok`
--
ALTER TABLE `eladok`
  ADD CONSTRAINT `eladok_ibfk_1` FOREIGN KEY (`telepules`) REFERENCES `telepulesek` (`azonosito`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Megkötések a táblához `ingatlanok`
--
ALTER TABLE `ingatlanok`
  ADD CONSTRAINT `ingatlanok_ibfk_1` FOREIGN KEY (`tulajdonos`) REFERENCES `eladok` (`azonosito`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `ingatlanok_ibfk_2` FOREIGN KEY (`telepules`) REFERENCES `telepulesek` (`azonosito`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `ingatlanok_ibfk_3` FOREIGN KEY (`kategoria`) REFERENCES `ingatlan_kategoriak` (`azonosito`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `ingatlanok_ibfk_4` FOREIGN KEY (`allapot`) REFERENCES `ingatlan_allapotok` (`azonosito`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `ingatlanok_ibfk_5` FOREIGN KEY (`ugynok`) REFERENCES `ugynokok` (`azonosito`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Megkötések a táblához `ugynokok`
--
ALTER TABLE `ugynokok`
  ADD CONSTRAINT `ugynokok_ibfk_1` FOREIGN KEY (`kategoria`) REFERENCES `ugynok_kategoriak` (`azonosito`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
