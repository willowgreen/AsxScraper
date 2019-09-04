SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+10:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `asx_scraper`
--

-- --------------------------------------------------------

--
-- Table structure for table `datapoints`
--

CREATE TABLE `datapoints` (
  `code` varchar(3) NOT NULL,
  `datetime` datetime NOT NULL,
  `isin_code` varchar(12) NOT NULL,
  `desc_full` varchar(100) NOT NULL,
  `last_price` float NOT NULL,
  `open_price` float NOT NULL,
  `day_high_price` float NOT NULL,
  `day_low_price` float NOT NULL,
  `change_price` float NOT NULL,
  `change_in_percent` varchar(10) NOT NULL,
  `volume` bigint(20) NOT NULL,
  `bid_price` float NOT NULL,
  `offer_price` float NOT NULL,
  `previous_close_price` float NOT NULL,
  `previous_day_percentage_change` varchar(10) NOT NULL,
  `year_high_price` float NOT NULL,
  `last_trade_date` datetime NOT NULL,
  `year_high_date` datetime NOT NULL,
  `year_low_price` float NOT NULL,
  `year_low_date` datetime NOT NULL,
  `year_open_price` float NOT NULL,
  `year_open_date` datetime NOT NULL,
  `year_change_price` float NOT NULL,
  `year_change_in_percentage` varchar(10) NOT NULL,
  `pe` float NOT NULL,
  `eps` float NOT NULL,
  `average_daily_volume` bigint(20) NOT NULL,
  `annual_dividend_yield` float NOT NULL,
  `market_cap` bigint(20) NOT NULL,
  `number_of_shares` bigint(20) NOT NULL,
  `suspended` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `entities`
--

CREATE TABLE `entities` (
  `code` varchar(3) NOT NULL,
  `name` varchar(100) NOT NULL,
  `gics` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `datapoints`
--
ALTER TABLE `datapoints`
  ADD PRIMARY KEY (`code`,`datetime`);

--
-- Indexes for table `entities`
--
ALTER TABLE `entities`
  ADD PRIMARY KEY (`code`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
