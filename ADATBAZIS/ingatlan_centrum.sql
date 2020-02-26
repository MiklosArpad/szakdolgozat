-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2020. Feb 26. 15:32
-- Kiszolgáló verziója: 10.4.11-MariaDB
-- PHP verzió: 7.4.2

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
  `telepules` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
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
(1, 'Jakab', 'Csaba', 2147483647, 'Ásotthalom', 'Jászai Mari tér 12', '06309241515', 'jcsaba@gmail.com'),
(2, 'Latinovits', 'Zoltán', 2147483647, 'Nagylak', 'Balatoni utca 7', '0613125553', 'zoltanaszinesz@citromail.hu'),
(3, 'Stohl', 'András', 2147483647, 'Ferencszállás', 'Kiskunság utca 5', '06705558965', 'tequila@freemail.hu'),
(4, 'Dayka', 'Margit', 2147483647, 'Csanytelek', 'Nagyerdő 7', '06206667266', 'dayka1907@gmail.com'),
(5, 'Rudolf', 'Péter', 2147483647, 'Ambrózfalva', 'Könyves Kálmán körút 77', '06205267822', 'pepe5@freemail.hu'),
(6, 'Somlai', 'Edina', 2147483647, 'Balástya', 'Erős János utca 3', '06302802719', 'edobaba@gmail.com');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `hirdetesek`
--

DROP TABLE IF EXISTS `hirdetesek`;
CREATE TABLE IF NOT EXISTS `hirdetesek` (
  `azonosito` int(11) NOT NULL AUTO_INCREMENT,
  `ingatlan` int(11) NOT NULL,
  `ugynok` varchar(6) COLLATE utf8_hungarian_ci NOT NULL,
  `hirdetes_dauma` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `aktiv` tinyint(1) NOT NULL,
  PRIMARY KEY (`azonosito`),
  KEY `ingatlan` (`ingatlan`),
  KEY `ugynok` (`ugynok`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `hirdetesek`
--

INSERT INTO `hirdetesek` (`azonosito`, `ingatlan`, `ugynok`, `hirdetes_dauma`, `aktiv`) VALUES
(1, 1, 'XYZ987', '2020-02-26 14:31:04', 1),
(2, 2, 'ABC123', '2020-02-26 14:32:16', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ingatlanok`
--

DROP TABLE IF EXISTS `ingatlanok`;
CREATE TABLE IF NOT EXISTS `ingatlanok` (
  `azonosito` int(11) NOT NULL AUTO_INCREMENT,
  `leiras` varchar(150) COLLATE utf8_hungarian_ci NOT NULL,
  `tulajdonos` int(11) NOT NULL,
  `telepules` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  `ar` int(11) NOT NULL,
  `alapterulet` int(11) NOT NULL,
  `kategoria` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `allapot` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`azonosito`),
  KEY `tulajdonos` (`tulajdonos`),
  KEY `kategoria` (`kategoria`),
  KEY `allapot` (`allapot`),
  KEY `telepules` (`telepules`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ingatlanok`
--

INSERT INTO `ingatlanok` (`azonosito`, `leiras`, `tulajdonos`, `telepules`, `ar`, `alapterulet`, `kategoria`, `allapot`) VALUES
(1, 'Nagy ház', 5, 'Makó', 12000000, 1234, 'kert', 'használt'),
(2, 'Kis panellakás a városban!', 6, 'Nagylak', 2000000, 1356, 'bérleti jog', 'felújítandó'),
(3, 'Nagy villa', 1, 'Ferencszállás', 12000000, 13000, 'családi ház', 'használt'),
(4, 'Kis Panel', 4, 'Csanytelek', 17000000, 35, 'bérleti jog', 'használt'),
(5, 'Családi fészek', 2, 'Ambrózfalva', 23000000, 148, 'családi ház', 'használt'),
(6, 'Polgári Palota', 5, 'Balástya', 40500000, 187, 'családi ház', 'használt');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ingatlan_allapotok`
--

DROP TABLE IF EXISTS `ingatlan_allapotok`;
CREATE TABLE IF NOT EXISTS `ingatlan_allapotok` (
  `elnevezes` varchar(25) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`elnevezes`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ingatlan_allapotok`
--

INSERT INTO `ingatlan_allapotok` (`elnevezes`) VALUES
('felújítandó'),
('használt'),
('új');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ingatlan_kategoriak`
--

DROP TABLE IF EXISTS `ingatlan_kategoriak`;
CREATE TABLE IF NOT EXISTS `ingatlan_kategoriak` (
  `elnevezes` varchar(25) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`elnevezes`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ingatlan_kategoriak`
--

INSERT INTO `ingatlan_kategoriak` (`elnevezes`) VALUES
('bérleti jog'),
('családi ház'),
('garázs'),
('kert'),
('panel'),
('tanya'),
('tégla'),
('termőföld');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `telepulesek`
--

DROP TABLE IF EXISTS `telepulesek`;
CREATE TABLE IF NOT EXISTS `telepulesek` (
  `nev` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`nev`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `telepulesek`
--

INSERT INTO `telepulesek` (`nev`) VALUES
('Algyő'),
('Ambrózfalva'),
('Apátfalva'),
('Árpádhalom'),
('Ásotthalom'),
('Baks'),
('Balástya'),
('Bordány'),
('Csanádalberti'),
('Csanádpalota'),
('Csanytelek'),
('Csengele'),
('Csongrád'),
('Derekegyház'),
('Deszk'),
('Dóc'),
('Domaszék'),
('Eperjes'),
('Fábiánsebestyén'),
('Felgyő'),
('Ferencszállás'),
('Forráskút'),
('Földeák'),
('Hódmezővásárhely'),
('Királyhegyes'),
('Kistelek'),
('Kiszombor'),
('Klárafalva'),
('Kövegy'),
('Kübekháza'),
('Magyarcsanád'),
('Makó'),
('Nagyér'),
('Nagylak'),
('Nagymágocs'),
('Nagytőke'),
('Óföldeák'),
('Ópusztaszer'),
('Pitvaros'),
('Pusztamérges'),
('Pusztaszer'),
('Röszke'),
('Rúzsa'),
('Sándorfalva'),
('Szatymaz'),
('Szeged'),
('Szegvár'),
('Székkutas'),
('Szentes'),
('Tiszasziget'),
('Tömörkény'),
('Újszantiván'),
('Üllés'),
('Zákányszék'),
('Zsombó');

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
  `jogosultsag` varchar(11) COLLATE utf8_hungarian_ci NOT NULL,
  `aktiv` tinyint(1) NOT NULL,
  PRIMARY KEY (`azonosito`),
  KEY `kategoria` (`jogosultsag`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ugynokok`
--

INSERT INTO `ugynokok` (`azonosito`, `jelszo`, `vezeteknev`, `keresztnev`, `telefonszam`, `jogosultsag`, `aktiv`) VALUES
('ABC123', 'Ugynok12', 'Miklós', 'Árpád', '06202346794', 'admin', 1),
('XYZ987', 'Ugynok13', 'Teszt', 'Elek', '06302134112', 'default', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ugynok_jogosultsagok`
--

DROP TABLE IF EXISTS `ugynok_jogosultsagok`;
CREATE TABLE IF NOT EXISTS `ugynok_jogosultsagok` (
  `elnevezes` varchar(25) COLLATE utf8_hungarian_ci NOT NULL,
  `leiras` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`elnevezes`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ugynok_jogosultsagok`
--

INSERT INTO `ugynok_jogosultsagok` (`elnevezes`, `leiras`) VALUES
('admin', 'bármely adatokhoz hozzáférő és kezelő ügynök'),
('default', 'saját adatokhoz hozzáférő és kezelő ügynök');

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `eladok`
--
ALTER TABLE `eladok`
  ADD CONSTRAINT `eladok_ibfk_1` FOREIGN KEY (`telepules`) REFERENCES `telepulesek` (`nev`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Megkötések a táblához `hirdetesek`
--
ALTER TABLE `hirdetesek`
  ADD CONSTRAINT `hirdetesek_ibfk_1` FOREIGN KEY (`ingatlan`) REFERENCES `ingatlanok` (`azonosito`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `hirdetesek_ibfk_2` FOREIGN KEY (`ugynok`) REFERENCES `ugynokok` (`azonosito`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Megkötések a táblához `ingatlanok`
--
ALTER TABLE `ingatlanok`
  ADD CONSTRAINT `ingatlanok_ibfk_1` FOREIGN KEY (`tulajdonos`) REFERENCES `eladok` (`azonosito`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `ingatlanok_ibfk_3` FOREIGN KEY (`kategoria`) REFERENCES `ingatlan_kategoriak` (`elnevezes`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `ingatlanok_ibfk_4` FOREIGN KEY (`allapot`) REFERENCES `ingatlan_allapotok` (`elnevezes`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `ingatlanok_ibfk_5` FOREIGN KEY (`telepules`) REFERENCES `telepulesek` (`nev`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Megkötések a táblához `ugynokok`
--
ALTER TABLE `ugynokok`
  ADD CONSTRAINT `ugynokok_ibfk_1` FOREIGN KEY (`jogosultsag`) REFERENCES `ugynok_jogosultsagok` (`elnevezes`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
