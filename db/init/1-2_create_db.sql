SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

CREATE DATABASE IF NOT EXISTS `school` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci;
USE `school`;

CREATE TABLE `allergens` (
  `id` int(11) NOT NULL,
  `description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `allergen_presences` (
  `allergen_id` int(11) NOT NULL,
  `ingredient_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `allergen_sensitivities` (
  `child_id` int(11) NOT NULL,
  `allergen_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `children` (
  `user_id` int(11) NOT NULL,
  `class_id` int(11) NOT NULL,
  `food_preference` enum('meat','veggie','vegan') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `classes` (
  `id` int(11) NOT NULL,
  `description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `hot_meals` (
  `id` int(11) NOT NULL,
  `description` varchar(255) NOT NULL,
  `recipe` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `hot_meal_choices` (
  `date` date NOT NULL,
  `meal_choice_child_id` int(11) NOT NULL,
  `hot_meal_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `ingredients` (
  `id` int(11) NOT NULL,
  `description` varchar(255) NOT NULL,
  `type` enum('meat','veggie','vegan') NOT NULL,
  `unit_of_measurement` enum('kg','l','') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `meal_choices` (
  `date` date NOT NULL,
  `child_id` int(11) NOT NULL,
  `choice` enum('home','cold','hot') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `meal_ingredients` (
  `hot_meal_id` int(11) NOT NULL,
  `ingredient_id` int(11) NOT NULL,
  `quantity` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `parental_relations` (
  `parent_id` int(11) NOT NULL,
  `child_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `parents` (
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `scheduled_hot_meals` (
  `date` date NOT NULL,
  `hot_meal_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `staff` (
  `user_id` int(11) NOT NULL,
  `role` enum('kitchen','teaching','management') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `teachers` (
  `staff_id` int(11) NOT NULL,
  `class_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

ALTER TABLE `allergens`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `allergen_presences`
  ADD PRIMARY KEY (`allergen_id`,`ingredient_id`),
  ADD KEY `fk__allergen_presences__ingredient_id` (`ingredient_id`);

ALTER TABLE `allergen_sensitivities`
  ADD PRIMARY KEY (`child_id`,`allergen_id`),
  ADD KEY `fk__allergen_sensitivities__allergen_id` (`allergen_id`);

ALTER TABLE `children`
  ADD PRIMARY KEY (`user_id`),
  ADD KEY `fk__children__class_id` (`class_id`);

ALTER TABLE `classes`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `hot_meals`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `hot_meal_choices`
  ADD PRIMARY KEY (`date`,`meal_choice_child_id`,`hot_meal_id`),
  ADD KEY `fk__hot_meal_choices__hot_meal_id` (`hot_meal_id`),
  ADD KEY `fk__hot_meal_choices__scheduled_hot_meal_composite` (`date`,`hot_meal_id`);

ALTER TABLE `ingredients`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `meal_choices`
  ADD PRIMARY KEY (`date`,`child_id`),
  ADD KEY `fk__meal_choices__child_id` (`child_id`);

ALTER TABLE `meal_ingredients`
  ADD PRIMARY KEY (`hot_meal_id`,`ingredient_id`),
  ADD KEY `fk__meal_ingredients__ingredient_id` (`ingredient_id`);

ALTER TABLE `parental_relations`
  ADD PRIMARY KEY (`parent_id`,`child_id`),
  ADD KEY `fk__parental_relations__child_id` (`child_id`);

ALTER TABLE `parents`
  ADD PRIMARY KEY (`user_id`);

ALTER TABLE `scheduled_hot_meals`
  ADD PRIMARY KEY (`date`,`hot_meal_id`),
  ADD KEY `fk__scheduled_hot_meals__hot_meal_id` (`hot_meal_id`);

ALTER TABLE `staff`
  ADD PRIMARY KEY (`user_id`);

ALTER TABLE `teachers`
  ADD PRIMARY KEY (`staff_id`,`class_id`),
  ADD KEY `fk__teachers__class_id` (`class_id`);

ALTER TABLE `allergens`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `classes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `hot_meals`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `ingredients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `allergen_presences`
  ADD CONSTRAINT `fk__allergen_presences__allergen_id` FOREIGN KEY (`allergen_id`) REFERENCES `allergens` (`id`),
  ADD CONSTRAINT `fk__allergen_presences__ingredient_id` FOREIGN KEY (`ingredient_id`) REFERENCES `ingredients` (`id`);

ALTER TABLE `allergen_sensitivities`
  ADD CONSTRAINT `fk__allergen_sensitivities__allergen_id` FOREIGN KEY (`allergen_id`) REFERENCES `allergens` (`id`),
  ADD CONSTRAINT `fk__allergen_sensitivities__child_id` FOREIGN KEY (`child_id`) REFERENCES `children` (`user_id`);

ALTER TABLE `children`
  ADD CONSTRAINT `fk__children__class_id` FOREIGN KEY (`class_id`) REFERENCES `classes` (`id`),
  ADD CONSTRAINT `fk__children__user_id` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`id`);

ALTER TABLE `hot_meal_choices`
  ADD CONSTRAINT `fk__hot_meal_choices__meal_choice_composite` FOREIGN KEY (`date`,`meal_choice_child_id`) REFERENCES `meal_choices` (`date`, `child_id`),
  ADD CONSTRAINT `fk__hot_meal_choices__scheduled_hot_meal_composite` FOREIGN KEY (`date`,`hot_meal_id`) REFERENCES `scheduled_hot_meals` (`date`, `hot_meal_id`);

ALTER TABLE `meal_choices`
  ADD CONSTRAINT `fk__meal_choices__child_id` FOREIGN KEY (`child_id`) REFERENCES `children` (`user_id`);

ALTER TABLE `meal_ingredients`
  ADD CONSTRAINT `fk__meal_ingredients__hot_meal_id` FOREIGN KEY (`hot_meal_id`) REFERENCES `hot_meals` (`id`),
  ADD CONSTRAINT `fk__meal_ingredients__ingredient_id` FOREIGN KEY (`ingredient_id`) REFERENCES `ingredients` (`id`);

ALTER TABLE `parental_relations`
  ADD CONSTRAINT `fk__parental_relations__child_id` FOREIGN KEY (`child_id`) REFERENCES `children` (`user_id`),
  ADD CONSTRAINT `fk__parental_relations__parent_id` FOREIGN KEY (`parent_id`) REFERENCES `parents` (`user_id`);

ALTER TABLE `parents`
  ADD CONSTRAINT `fk__parents__user_id` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`id`);

ALTER TABLE `scheduled_hot_meals`
  ADD CONSTRAINT `fk__scheduled_hot_meals__hot_meal_id` FOREIGN KEY (`hot_meal_id`) REFERENCES `hot_meals` (`id`);

ALTER TABLE `staff`
  ADD CONSTRAINT `fk__staff__user_id` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`id`);

ALTER TABLE `teachers`
  ADD CONSTRAINT `fk__teachers__class_id` FOREIGN KEY (`class_id`) REFERENCES `classes` (`id`),
  ADD CONSTRAINT `fk__teachers__staff_id` FOREIGN KEY (`staff_id`) REFERENCES `staff` (`user_id`);
  
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
