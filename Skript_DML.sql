USE inventarisierungsloesung;

INSERT INTO town(zip, town)
VALUES
('9043', 'Trogen'),
('9999', 'Hobbingen'),
('9000', 'St. Gallen'),
('6000', 'Luzern'),
('8400', 'Winterthur');

INSERT INTO address(town_fk, streetname, streetnumber, country, additive, po_box)
VALUES
(2,'Auenlandstrasse','5b','Auenland', 'Postkasten ist hinter Höhle' , null),
(1,'Befang','5','Schweiz', null , null),
(3,'Zürcherstrasse','300C','Schweiz', null , '203'),
(4,'Löwenstrasse','26','Schweiz', null , '100'),
(5,'Rudolfstrasse','17A','Schweiz', null , '100'),
(3,'Langgass','35A','Schweiz', null , null);


INSERT INTO person(firstname, lastname)
VALUES
('Nina','Schmid'),
('Bilbo','Beutlin'),
('Patrick','Keist'),
('Larissa', 'Fitze'),
('Francesco' , 'Rauseo'),
('Ronny','Wyss'),
('Max','Muster');

INSERT INTO kundenkonto(kundenkonto_id)
VALUES
(1),(2),(3),(4),(5),(6),(7),(8);

INSERT INTO customer(person_fk, address_fk, kundenkonto_fk, tel, eMail, url, auth)
VALUES
(1, 2, 'CU0139', '079 666 20 14', 'nina.schmid@test.ch','www.nina.ch','xxx'),
(2, 1, 'CU0137', 'Dose mit Schnur', 'bilbo@auenland.xx',null,'xxx'),
(3, 3, 'CU0144', '078 878 90 43', 'p.keist@hotmail.com',null,'xxx'),
(6, 4, 'CU0145', '077 777 77 77', 'ronny@wyss.ch',null,'xxx');

INSERT INTO contact( person_fk, priority)
VALUES
(2,3),
(1,2),
(3,1),
(4,2),
(5,1);

INSERT INTO location( address_fk, designation, building, room)
VALUES
(1, 'Vertriebszentrum Tabak', 2, 4),
(2, 'Absteige',5,9),
(3, 'Consult & Pepper', 6,9);


INSERT INTO pointofdelivery(customer_person_fk, contact_person_fk, location_fk, designation, timezone, timeZonePositiv, ntpServerIp)
VALUES
(2,2,1,'Auenland','10:00:00',1, '1.1.1.10'),
(1,1,3, 'Consult & Pepper Trogen', '01:00:00', 1 , '178.198.222.68'),
(3,4,2,'ZbW', '01:00:00', 1 , '192.168.1.1');

INSERT INTO Network (network_id, subnet, mask, vlan, description)
VALUES
(1,'10.36.0.0','255.255.0.0',1,'Kunde xy'),
(2,'10.8.0.0','255.255.0.0',1,''),
(3,'172.129.0.0','255.255.255.0',1,'Test'),
(4,'192.168.1.0','255.255.255.0',1,'Labor'),
(5,'192.168.128.0','255.255.255.127',1,'Integration');

INSERT INTO DeviceType (manufacturer, model, version)
VALUES
('Cisco','Router',''),
('Avaya','PBX',''),
('Nortel','PBX',''),
('Siemens','Telephon',''),
('Cisco','FireWall','');


INSERT INTO Device (location_fk, deviceType_fk, inventoryDate, deactivateDate, hostname, domain, description)
VALUES
(1,1,'2018-12-31','2019-12-31','CiscoR1','ch.zbw','Keller'),
(1,1,'2007-10-29','2008-10-29','CSTA003','ch.zbw','OG6'),
(2,1,'2018-12-10','2018-02-12','TelCo099','ch.aruper','RZ'),
(3,1,'2018-06-06','2019-02-12','CiscoR006','ch.scs','Keller'),
(1,1,'2018-02-01','2020-12-02','Cisco-PRT-032','ch.zbw','Kantine');


INSERT INTO Transportmedium (description)
VALUES
('LWL'),
('RJ45'),
('RJ11'),
('COM');

INSERT INTO Deviceport (description, device_fk, transportmedium_fk)
VALUES
('GigabitEthernet 0/1', 1, 3),
('FastEtherne 0/1', 2, 1),
('FastEtherne 0/1', 2, 1),
('Etherne 0/1', 3, 2),
('FastEtherne 0/1', 2, 1);

INSERT INTO operatingsystem (operatingsystem_id, operatingsystemName, model, version)
VALUES
(1,'CISCO IO','Cisco','9.5'),
(2,'AVAYALX','Linux','19.4.0.1'),
(3,'Unify','Debian','9.2'),
(4,'NOOS','RH','0.2.8'),
(5,'Linux','RedHead','17.3');

INSERT INTO DeviceType_has_operatingsystem (deviceType_fk, operatingsystem_fk)
VALUES
(1,1),
(2,2),
(3,4),
(4,3),
(5,1);

INSERT INTO Log (logMessage, timestamp, level, is_acknowledged, device_fk)
VALUES
('Loged In',now(),'Low',0,1),
('Loged Out',now(),'Low',0,1),
('Loged In',now(),'Low',0,2),
('Virus detected',now(),'High',0,3)
;


INSERT INTO Credentials (credentials_id, benutzername,passwort,snmp)
VALUES
(1,'Larissa','1111','snmp1'),
(2,'Patrick','1111','snmp2'),
(3,'Francesco','1111','snmp3'),
(4,'Ronny','1111','snmp4');

INSERT INTO Devices_has_Credentials (Devices_devices_id, credentials_credentials_id)
VALUES
(1,1),
(2,2),
(3,4),
(4,3);

INSERT INTO v_logentries(pod, location, hostname, severity, `timestamp`, message)
VALUES
("test1", "St. Gallen", "schokoladenweg", 5, now(), "Das ist eine aufwändige Aufgabe"),
("test2", "Appenzell", "Fählensee", 3, now(), "Gruss aus dem Alpstein"),
("test3", "Abtwil", "Zbw", 3, now(), "Keine Lust mehr auf Schulabende..");

INSERT INTO Interface (interface_id, network_fk, device_fk, ip_adress_v4, mac_adresse, isFullDuplex, bandwith, is_in_use, description)
VALUES
(1,3,1,'172.129.1.5','0025:96FF:FE12:3456',1,10000,0,''),
(2,3,4,'172.129.1.6','0025:96FF:FE12:3457',1,10000,0,''),
(3,1,5,'10.36.0.253','0025:96FF:FE12:3458',1,10000,0,''),
(4,5,4,'192.168.128.192','0025:96FF:FE12:3459',1,10000,0,''),
(5,3,3,'172.129.5.9','0025:96FF:FE12:3455',1,100,0,'');

INSERT INTO Abrechnung (kundenkonto_fk, location_fk, device_fk, interface_fk)
VALUES
(1,1,1,1),
(1,1,1,1);

INSERT INTO SoftwareDienstleistung (stundenaufwand, abrechung_fk)
VALUES
(240,1);

INSERT INTO Produktegruppe (hardware, software, sonstigeArtikel, abrechung_fk)
VALUES
('Hardware','PP','ss',1),
('Hardware','PP','ss',1),
('HH','Software','ss',2),
('HH','SS','sonstigeArtikel',1);

INSERT INTO Produkte (artikelname, preis, produktegruppe_fk)
VALUES
('Laptop',50, 1),
('Bildschirm',150, 1),
('AdobeReader',20, 1),
('Bürostuhl',10, 1);