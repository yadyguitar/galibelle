-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema galibelle
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `galibelle` ;

-- -----------------------------------------------------
-- Schema galibelle
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `galibelle` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `galibelle` ;

-- -----------------------------------------------------
-- Table `galibelle`.`colores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `galibelle`.`colores` (
  `id_colores` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `nombre_color` VARCHAR(45) NOT NULL COMMENT '',
  PRIMARY KEY (`id_colores`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `galibelle`.`textura`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `galibelle`.`textura` (
  `id_textura` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `nombre_textura` VARCHAR(45) NOT NULL COMMENT '',
  PRIMARY KEY (`id_textura`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `galibelle`.`modelos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `galibelle`.`modelos` (
  `id_modelos` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `nombre_modelo` VARCHAR(45) NOT NULL COMMENT '',
  PRIMARY KEY (`id_modelos`)  COMMENT '')
ENGINE = InnoDB
COMMENT = '							';


-- -----------------------------------------------------
-- Table `galibelle`.`sucursales`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `galibelle`.`sucursales` (
  `id_sucursales` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `nombre_sucursal` VARCHAR(45) NOT NULL COMMENT '',
  `direccion_sucursal` VARCHAR(100) NULL COMMENT '',
  `telefono_sucursal` VARCHAR(15) NULL COMMENT '',
  PRIMARY KEY (`id_sucursales`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `galibelle`.`usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `galibelle`.`usuarios` (
  `id_usuario` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `id_sucursales` INT NOT NULL COMMENT '',
  `usuario` VARCHAR(45) NOT NULL COMMENT '',
  `password` VARCHAR(45) NOT NULL COMMENT '',
  PRIMARY KEY (`id_usuario`)  COMMENT '',
  INDEX `fk_usuarios_sucursales1_idx` (`id_sucursales` ASC)  COMMENT '',
  CONSTRAINT `fk_usuarios_sucursales1`
    FOREIGN KEY (`id_sucursales`)
    REFERENCES `galibelle`.`sucursales` (`id_sucursales`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `galibelle`.`tipo_strap`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `galibelle`.`tipo_strap` (
  `id_tipo_strap` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `id_colores` INT NOT NULL COMMENT '',
  `id_textura` INT NOT NULL COMMENT '',
  `combo` INT NOT NULL DEFAULT 0 COMMENT '',
  `imagen` VARCHAR(200) NULL COMMENT '',
  PRIMARY KEY (`id_tipo_strap`)  COMMENT '',
  INDEX `fk_tipo_strap_colores_idx` (`id_colores` ASC)  COMMENT '',
  INDEX `fk_tipo_strap_textura1_idx` (`id_textura` ASC)  COMMENT '',
  CONSTRAINT `fk_tipo_strap_colores`
    FOREIGN KEY (`id_colores`)
    REFERENCES `galibelle`.`colores` (`id_colores`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tipo_strap_textura1`
    FOREIGN KEY (`id_textura`)
    REFERENCES `galibelle`.`textura` (`id_textura`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `galibelle`.`straps`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `galibelle`.`straps` (
  `id_straps` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `codigo_strap` VARCHAR(5) NOT NULL COMMENT '',
  `id_modelos` INT NOT NULL COMMENT '',
  `letra_strap` VARCHAR(2) NOT NULL COMMENT '',
  `precio_strap` FLOAT NOT NULL COMMENT '',
  PRIMARY KEY (`id_straps`)  COMMENT '',
  INDEX `fk_straps_modelos1_idx` (`id_modelos` ASC)  COMMENT '',
  CONSTRAINT `fk_straps_modelos1`
    FOREIGN KEY (`id_modelos`)
    REFERENCES `galibelle`.`modelos` (`id_modelos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `galibelle`.`suelas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `galibelle`.`suelas` (
  `id_suelas` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `id_modelos` INT NOT NULL COMMENT '',
  `nombre_suela` VARCHAR(20) NOT NULL COMMENT '',
  `precio_suela` FLOAT NOT NULL COMMENT '',
  `imagen_suela` VARCHAR(200) NULL COMMENT '',
  PRIMARY KEY (`id_suelas`)  COMMENT '',
  INDEX `fk_suelas_modelos1_idx` (`id_modelos` ASC)  COMMENT '',
  CONSTRAINT `fk_suelas_modelos1`
    FOREIGN KEY (`id_modelos`)
    REFERENCES `galibelle`.`modelos` (`id_modelos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `galibelle`.`stock_straps`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `galibelle`.`stock_straps` (
  `id_stock_straps` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `id_straps` INT NOT NULL COMMENT '',
  `id_tipo_strap` INT NOT NULL COMMENT '',
  `id_sucursales` INT NOT NULL COMMENT '',
  `size_strap` VARCHAR(2) NOT NULL COMMENT '',
  `cantidad` INT NULL DEFAULT 0 COMMENT '',
  `temporada` INT NULL COMMENT '',
  PRIMARY KEY (`id_stock_straps`, `id_straps`, `id_tipo_strap`)  COMMENT '',
  INDEX `fk_stock_straps_straps1_idx` (`id_straps` ASC)  COMMENT '',
  INDEX `fk_stock_straps_tipo_strap1_idx` (`id_tipo_strap` ASC)  COMMENT '',
  INDEX `fk_stock_straps_sucursales1_idx` (`id_sucursales` ASC)  COMMENT '',
  CONSTRAINT `fk_stock_straps_straps1`
    FOREIGN KEY (`id_straps`)
    REFERENCES `galibelle`.`straps` (`id_straps`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_stock_straps_tipo_strap1`
    FOREIGN KEY (`id_tipo_strap`)
    REFERENCES `galibelle`.`tipo_strap` (`id_tipo_strap`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_stock_straps_sucursales1`
    FOREIGN KEY (`id_sucursales`)
    REFERENCES `galibelle`.`sucursales` (`id_sucursales`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `galibelle`.`stock_suelas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `galibelle`.`stock_suelas` (
  `id_stock_suelas` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `id_suelas` INT NOT NULL COMMENT '',
  `talla_suela` FLOAT NOT NULL COMMENT '',
  `cantidad_suela` INT NOT NULL DEFAULT 0 COMMENT '',
  `id_sucursales` INT NOT NULL COMMENT '',
  `temporada` INT NULL COMMENT '',
  PRIMARY KEY (`id_stock_suelas`)  COMMENT '',
  INDEX `fk_stock_suelas_suelas1_idx` (`id_suelas` ASC)  COMMENT '',
  INDEX `fk_stock_suelas_sucursales1_idx` (`id_sucursales` ASC)  COMMENT '',
  CONSTRAINT `fk_stock_suelas_suelas1`
    FOREIGN KEY (`id_suelas`)
    REFERENCES `galibelle`.`suelas` (`id_suelas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_stock_suelas_sucursales1`
    FOREIGN KEY (`id_sucursales`)
    REFERENCES `galibelle`.`sucursales` (`id_sucursales`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
COMMENT = '													';


-- -----------------------------------------------------
-- Table `galibelle`.`pedidos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `galibelle`.`pedidos` (
  `id_pedidos` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `id_suelas` INT NOT NULL COMMENT '',
  `id_straps` INT NOT NULL COMMENT '',
  `id_sucursales` INT NOT NULL COMMENT '',
  PRIMARY KEY (`id_pedidos`, `id_straps`)  COMMENT '',
  INDEX `fk_pedidos_suelas1_idx` (`id_suelas` ASC)  COMMENT '',
  INDEX `fk_pedidos_straps1_idx` (`id_straps` ASC)  COMMENT '',
  INDEX `fk_pedidos_sucursales1_idx` (`id_sucursales` ASC)  COMMENT '',
  CONSTRAINT `fk_pedidos_suelas1`
    FOREIGN KEY (`id_suelas`)
    REFERENCES `galibelle`.`suelas` (`id_suelas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_pedidos_straps1`
    FOREIGN KEY (`id_straps`)
    REFERENCES `galibelle`.`straps` (`id_straps`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_pedidos_sucursales1`
    FOREIGN KEY (`id_sucursales`)
    REFERENCES `galibelle`.`sucursales` (`id_sucursales`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `galibelle`.`ventas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `galibelle`.`ventas` (
  `id_ventas` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `fecha_venta` DATETIME NOT NULL COMMENT '',
  `precio_Total` DOUBLE NOT NULL COMMENT '',
  `id_sucursales` INT NOT NULL COMMENT '',
  PRIMARY KEY (`id_ventas`)  COMMENT '',
  INDEX `fk_ventas_sucursales1_idx` (`id_sucursales` ASC)  COMMENT '',
  CONSTRAINT `fk_ventas_sucursales1`
    FOREIGN KEY (`id_sucursales`)
    REFERENCES `galibelle`.`sucursales` (`id_sucursales`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `galibelle`.`vendido`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `galibelle`.`vendido` (
  `id_producto_vendido` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `id_stock_straps` INT NOT NULL COMMENT '',
  `id_stock_suelas` INT NOT NULL COMMENT '',
  `id_ventas` INT NOT NULL COMMENT '',
  PRIMARY KEY (`id_producto_vendido`)  COMMENT '',
  INDEX `fk_vendido_stock_straps1_idx` (`id_stock_straps` ASC)  COMMENT '',
  INDEX `fk_vendido_stock_suelas1_idx` (`id_stock_suelas` ASC)  COMMENT '',
  INDEX `fk_vendido_ventas1_idx` (`id_ventas` ASC)  COMMENT '',
  CONSTRAINT `fk_vendido_stock_straps1`
    FOREIGN KEY (`id_stock_straps`)
    REFERENCES `galibelle`.`stock_straps` (`id_stock_straps`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_vendido_stock_suelas1`
    FOREIGN KEY (`id_stock_suelas`)
    REFERENCES `galibelle`.`stock_suelas` (`id_stock_suelas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_vendido_ventas1`
    FOREIGN KEY (`id_ventas`)
    REFERENCES `galibelle`.`ventas` (`id_ventas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
COMMENT = '	';


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `galibelle`.`colores`
-- -----------------------------------------------------
START TRANSACTION;
USE `galibelle`;
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (1, 'black');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (2, 'blue');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (3, 'ocean');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (4, 'orange');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (5, 'red');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (6, 'yellow');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (7, 'gold');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (8, 'jaguar');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (9, 'raw');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (10, 'pink');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (11, 'royal');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (12, 'dark blue');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (13, 'black silver');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (14, 'blue silver');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (15, 'green silver');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (16, 'pewter');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (17, 'silver');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (18, 'floral');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (19, 'income silver');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (20, 'multicolor');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (21, 'black / white');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (22, 'caramel');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (23, 'navy blue');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (24, 'nude');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (25, 'pearl');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (26, 'zebra');
INSERT INTO `galibelle`.`colores` (`id_colores`, `nombre_color`) VALUES (27, 'white');

COMMIT;


-- -----------------------------------------------------
-- Data for table `galibelle`.`textura`
-- -----------------------------------------------------
START TRANSACTION;
USE `galibelle`;
INSERT INTO `galibelle`.`textura` (`id_textura`, `nombre_textura`) VALUES (1, 'atanado');
INSERT INTO `galibelle`.`textura` (`id_textura`, `nombre_textura`) VALUES (2, 'canvas');
INSERT INTO `galibelle`.`textura` (`id_textura`, `nombre_textura`) VALUES (3, 'croco');
INSERT INTO `galibelle`.`textura` (`id_textura`, `nombre_textura`) VALUES (4, 'jeans');
INSERT INTO `galibelle`.`textura` (`id_textura`, `nombre_textura`) VALUES (5, 'lurex');
INSERT INTO `galibelle`.`textura` (`id_textura`, `nombre_textura`) VALUES (6, 'metal');
INSERT INTO `galibelle`.`textura` (`id_textura`, `nombre_textura`) VALUES (7, 'micropunto');
INSERT INTO `galibelle`.`textura` (`id_textura`, `nombre_textura`) VALUES (8, 'satin');
INSERT INTO `galibelle`.`textura` (`id_textura`, `nombre_textura`) VALUES (9, 'snake');
INSERT INTO `galibelle`.`textura` (`id_textura`, `nombre_textura`) VALUES (10, 'soft');
INSERT INTO `galibelle`.`textura` (`id_textura`, `nombre_textura`) VALUES (11, 'suede');
INSERT INTO `galibelle`.`textura` (`id_textura`, `nombre_textura`) VALUES (12, 'twill');
INSERT INTO `galibelle`.`textura` (`id_textura`, `nombre_textura`) VALUES (13, 'varnish');

COMMIT;


-- -----------------------------------------------------
-- Data for table `galibelle`.`modelos`
-- -----------------------------------------------------
START TRANSACTION;
USE `galibelle`;
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (1, 'gabriela');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (2, 'gabi');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (3, 'danni');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (4, 'bruna');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (5, 'deise');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (6, 'gal/galuxa');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (7, 'giovanna');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (8, 'gaya');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (9, 'karina');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (10, 'michelle');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (11, 'naomy');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (12, 'noya');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (13, 'sara');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (14, 'yasmin');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (15, 'marimar');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (16, 'ivete');
INSERT INTO `galibelle`.`modelos` (`id_modelos`, `nombre_modelo`) VALUES (17, 'eva');

COMMIT;


-- -----------------------------------------------------
-- Data for table `galibelle`.`sucursales`
-- -----------------------------------------------------
START TRANSACTION;
USE `galibelle`;
INSERT INTO `galibelle`.`sucursales` (`id_sucursales`, `nombre_sucursal`, `direccion_sucursal`, `telefono_sucursal`) VALUES (1, 'almacen', 'no se', '2291404225');
INSERT INTO `galibelle`.`sucursales` (`id_sucursales`, `nombre_sucursal`, `direccion_sucursal`, `telefono_sucursal`) VALUES (2, 'mocambo', 'jardines de mocambo', '2291467689');

COMMIT;


-- -----------------------------------------------------
-- Data for table `galibelle`.`usuarios`
-- -----------------------------------------------------
START TRANSACTION;
USE `galibelle`;
INSERT INTO `galibelle`.`usuarios` (`id_usuario`, `id_sucursales`, `usuario`, `password`) VALUES (1, 1, 'admi', 'admi');
INSERT INTO `galibelle`.`usuarios` (`id_usuario`, `id_sucursales`, `usuario`, `password`) VALUES (2, 2, 'suc1', 'suc1');

COMMIT;

