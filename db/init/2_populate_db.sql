SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

USE `school`;

INSERT INTO `allergens` (`id`, `description`) VALUES
(1, 'soy'),
(2, 'fish'),
(3, 'gluten');

INSERT INTO `users` (`id`, `first_name`, `last_name`) VALUES
(1, 'Jeroen', 'Reinenbergh'),
(2, 'Milo', 'Reinenbergh'),
(3, 'Theo', 'Reinenbergh'),
(4, 'Ellen', 'Vandevyvere'),
(5, 'Kodi', 'Reinenbergh'),
(6, 'Mason', 'Huppeldepup'),
(7, 'Antonio', 'Huppeldepup'),
(8, 'Odette', 'Hopsasa'),
(9, 'Francine', 'Pompom');
COMMIT;

INSERT INTO `classes` (`id`, `description`) VALUES
(1, 'Preschool'),
(2, 'Kindergarten'),
(3, 'Dog school');

INSERT INTO `children` (`user_id`, `class_id`, `food_preference`) VALUES
(2, 2, 'meat'),
(3, 1, 'vegan'),
(5, 3, 'meat'),
(6, 2, 'veggie'),
(8, 2, 'vegan');

INSERT INTO `allergen_sensitivities` (`child_id`, `allergen_id`) VALUES
(2, 1),
(6, 1),
(3, 2),
(8, 2),
(5, 3);

INSERT INTO `hot_meals` (`id`, `description`, `recipe`) VALUES
(1, 'Spaghetti', 'Tomatoes, pasta, meat balls, ...'),
(2, 'Vegetable lasagna', 'Pasta, carrots, tomatoes, zucchini, ...'),
(3, 'Croque monsieur', 'Sandwich, cheese, ham, ...'),
(4, 'Fish stew', 'Salmon, potatoes, sprouts, ...'),
(5, 'Tofu with peanut sauce', 'Tofu, peanuts, ...');

INSERT INTO `scheduled_hot_meals` (`date`, `hot_meal_id`) VALUES
('2025-04-01', 1),
('2025-03-28', 5),
('2025-04-01', 5);

INSERT INTO `meal_choices` (`date`, `child_id`, `choice`) VALUES
('2025-03-27', 2, 'home'),
('2025-03-27', 3, 'home'),
('2025-03-27', 5, 'home'),
('2025-03-27', 6, 'cold'),
('2025-03-27', 8, 'home'),
('2025-03-28', 2, 'home'),
('2025-03-28', 3, 'home'),
('2025-03-28', 6, 'home'),
('2025-03-28', 8, 'hot'),
('2025-04-01', 2, 'hot'),
('2025-04-01', 3, 'hot'),
('2025-04-01', 6, 'cold'),
('2025-04-01', 8, 'hot');

INSERT INTO `hot_meal_choices` (`date`, `meal_choice_child_id`, `hot_meal_id`) VALUES
('2025-04-01', 2, 1),
('2025-03-28', 8, 5),
('2025-04-01', 3, 5),
('2025-04-01', 8, 5);

INSERT INTO `parents` (`user_id`) VALUES
(1),
(4),
(7),
(9);

INSERT INTO `parental_relations` (`parent_id`, `child_id`) VALUES
(1, 2),
(4, 2),
(1, 3),
(4, 3),
(1, 5),
(4, 5),
(7, 6),
(9, 8);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
