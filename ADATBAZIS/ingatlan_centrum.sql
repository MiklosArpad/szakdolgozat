-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2020. Ápr 02. 16:36
-- Kiszolgáló verziója: 10.4.11-MariaDB
-- PHP verzió: 7.2.28

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
CREATE DATABASE IF NOT EXISTS `ingatlan_centrum` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `ingatlan_centrum`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `eladok`
--

DROP TABLE IF EXISTS `eladok`;
CREATE TABLE IF NOT EXISTS `eladok` (
  `adoazonosito` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  `vezeteknev` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  `keresztnev` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  `telepules` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  `lakcim` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  `telefonszam` varchar(11) COLLATE utf8_hungarian_ci NOT NULL,
  `email` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`adoazonosito`),
  KEY `telepules` (`telepules`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `eladok`
--

INSERT INTO `eladok` (`adoazonosito`, `vezeteknev`, `keresztnev`, `telepules`, `lakcim`, `telefonszam`, `email`) VALUES
('0123456789', 'Latinovits', 'Zoltán', 'Nagylak', 'Balatoni utca 7', '0613125553', 'zoltanaszinesz@citromail.hu'),
('1122334455', 'Stohl', 'András', 'Ferencszállás', 'Kiskunság utca 5', '06705558965', 'tequila@freemail.hu'),
('2147483647', 'Jakab', 'Csaba', 'Ásotthalom', 'Jászai Mari tér 12', '06309241515', 'jcsaba@gmail.com'),
('5544332211', 'Somlai', 'Edina', 'Balástya', 'Erős János utca 3', '06302802719', 'edobaba@gmail.com'),
('5566778899', 'Dayka', 'Margit', 'Csanytelek', 'Nagyerdő 7', '06206667266', 'dayka1907@gmail.com'),
('9988776655', 'Rudolf', 'Péter', 'Ambrózfalva', 'Könyves Kálmán körút 77', '06205267822', 'pepe5@freemail.hu');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalok`
--

DROP TABLE IF EXISTS `felhasznalok`;
CREATE TABLE IF NOT EXISTS `felhasznalok` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `felhasznalonev` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  `jelszo` varchar(8) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `felhasznalonev` (`felhasznalonev`),
  UNIQUE KEY `jelszo` (`jelszo`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `felhasznalok`
--

INSERT INTO `felhasznalok` (`id`, `felhasznalonev`, `jelszo`) VALUES
(1, 'kisjanos12', '12345');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `hirdetesek`
--

DROP TABLE IF EXISTS `hirdetesek`;
CREATE TABLE IF NOT EXISTS `hirdetesek` (
  `azonosito` int(11) NOT NULL AUTO_INCREMENT,
  `cim` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  `leiras` varchar(500) COLLATE utf8_hungarian_ci NOT NULL,
  `ar` int(11) NOT NULL,
  `ingatlan` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  `ugynok` varchar(6) COLLATE utf8_hungarian_ci NOT NULL,
  `hirdetes_datuma` timestamp NOT NULL DEFAULT current_timestamp(),
  `aktiv` tinyint(1) NOT NULL,
  PRIMARY KEY (`azonosito`),
  KEY `ugynok` (`ugynok`),
  KEY `ingatlan` (`ingatlan`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `hirdetesek`
--

INSERT INTO `hirdetesek` (`azonosito`, `cim`, `leiras`, `ar`, `ingatlan`, `ugynok`, `hirdetes_datuma`, `aktiv`) VALUES
(1, 'Nagy ház', 'Zöld, fákkal teli kertes házikó kerül eladásra Makó kertvárosi övezetében! 2 konyhás, 2 fürdőszobás, emeletes használt ingatlan!', 12000000, '10980', 'XYZ987', '2020-02-26 16:12:54', 1),
(2, 'Kis panellakás a városban!', 'Nagylakon kiadó, elegáns, kis panel lakás közel a határhoz! Két hónap kaució szükséges!', 2000000, '11003', 'ABC123', '2020-02-26 16:12:57', 1),
(3, 'Nagy villa', 'Mindig is vágytál álmaid házára? Pláne hogyha palota! Ferencszálláson eladó használt családi villánk!', 12000000, '06/4', 'XYZ987', '2020-02-27 11:12:30', 1),
(4, 'Kis panel', 'Kiadó Csanyteleken bútorozott panellakás! Két hónap kaució szükséges, 1 konyhás, 1 fürdőszobás kényelem.', 17000000, '98/5', 'ABC123', '2020-02-27 11:13:19', 1),
(5, 'Családi fészek', 'Ambrózfalvi családi ház eladó! Az ár alkuképes!', 23000000, '10003', 'XYZ987', '2020-02-27 11:13:54', 1),
(6, 'Polgári palota', 'Használt családi ház eladó, 2 fürdőszobával, konyhával!', 40500000, '3000', 'ABC123', '2020-02-27 11:14:36', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ingatlanok`
--

DROP TABLE IF EXISTS `ingatlanok`;
CREATE TABLE IF NOT EXISTS `ingatlanok` (
  `helyrajzi_szam` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  `telepules` varchar(75) COLLATE utf8_hungarian_ci NOT NULL,
  `alapterulet` int(11) NOT NULL,
  `szobak_szama` int(11) NOT NULL,
  `kategoria` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `allapot` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `elado` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`helyrajzi_szam`),
  KEY `kategoria` (`kategoria`),
  KEY `allapot` (`allapot`),
  KEY `telepules` (`telepules`),
  KEY `elado` (`elado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ingatlanok`
--

INSERT INTO `ingatlanok` (`helyrajzi_szam`, `telepules`, `alapterulet`, `szobak_szama`, `kategoria`, `allapot`, `elado`) VALUES
('06/05', 'Bordány', 1300, 4, 'kert', 'új', '1122334455'),
('06/4', 'Ferencszállás', 13000, 6, 'családi ház', 'használt', '2147483647'),
('0725', 'Algyő', 2470, 4, 'kert', 'új', '9988776655'),
('10003', 'Ambrózfalva', 148, 6, 'családi ház', 'használt', '0123456789'),
('10980', 'Makó', 1234, 5, 'kert', 'használt', '9988776655'),
('11003', 'Nagylak', 1356, 4, 'bérleti jog', 'felújítandó', '5544332211'),
('3000', 'Balástya', 187, 4, 'családi ház', 'használt', '1122334455'),
('8700/5', 'Baks', 100, 1, 'garázs', 'új', '0123456789'),
('98/5', 'Csanytelek', 35, 3, 'bérleti jog', 'használt', '5566778899');

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
  PRIMARY KEY (`azonosito`),
  KEY `kategoria` (`jogosultsag`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ugynokok`
--

INSERT INTO `ugynokok` (`azonosito`, `jelszo`, `vezeteknev`, `keresztnev`, `telefonszam`, `jogosultsag`) VALUES
('ABC123', 'arPad19730', 'Miklós', 'Árpád', '06202346794', 'admin'),
('XYZ987', 'ElEk6919Ab', 'Teszt', 'Elek', '06302134112', 'default');

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
  ADD CONSTRAINT `hirdetesek_ibfk_2` FOREIGN KEY (`ugynok`) REFERENCES `ugynokok` (`azonosito`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `hirdetesek_ibfk_3` FOREIGN KEY (`ingatlan`) REFERENCES `ingatlanok` (`helyrajzi_szam`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Megkötések a táblához `ingatlanok`
--
ALTER TABLE `ingatlanok`
  ADD CONSTRAINT `ingatlanok_ibfk_1` FOREIGN KEY (`kategoria`) REFERENCES `ingatlan_kategoriak` (`elnevezes`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `ingatlanok_ibfk_2` FOREIGN KEY (`allapot`) REFERENCES `ingatlan_allapotok` (`elnevezes`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `ingatlanok_ibfk_3` FOREIGN KEY (`telepules`) REFERENCES `telepulesek` (`nev`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `ingatlanok_ibfk_4` FOREIGN KEY (`elado`) REFERENCES `eladok` (`adoazonosito`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Megkötések a táblához `ugynokok`
--
ALTER TABLE `ugynokok`
  ADD CONSTRAINT `ugynokok_ibfk_1` FOREIGN KEY (`jogosultsag`) REFERENCES `ugynok_jogosultsagok` (`elnevezes`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
