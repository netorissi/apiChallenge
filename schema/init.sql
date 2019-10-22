
CREATE DATABASE IF NOT EXISTS poll_challenge;
USE poll_challenge;

CREATE TABLE IF NOT EXISTS `options` (
  `option_id` int(11) NOT NULL,
  `poll_id` int(11) NOT NULL,
  `option_description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `polls` (
  `poll_id` int(11) NOT NULL,
  `poll_description` text NOT NULL,
  `views` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `votes` (
  `vote_id` int(11) NOT NULL,
  `option_id` int(11) NOT NULL,
  `qty` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE `options`
  ADD PRIMARY KEY (`option_id`),
  ADD KEY `poll_id` (`poll_id`);

ALTER TABLE `polls`
  ADD PRIMARY KEY (`poll_id`);

ALTER TABLE `votes`
  ADD PRIMARY KEY (`vote_id`),
  ADD KEY `option_id` (`option_id`);

ALTER TABLE `options`
  MODIFY `option_id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `polls`
  MODIFY `poll_id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `votes`
  MODIFY `vote_id` int(11) NOT NULL AUTO_INCREMENT;
