-- 1. Tworzenie bazy danych (jeśli nie istnieje)
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PatientDB')
BEGIN
    CREATE DATABASE PatientDB;
END;
GO

USE PatientDB;
GO

-- 2. Tworzenie tabeli Patients (jeśli nie istnieje)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Patients')
BEGIN
    CREATE TABLE Patients (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(50) NOT NULL,
        Surname NVARCHAR(50) NOT NULL,
        Email NVARCHAR(100) NOT NULL,
        PESEL CHAR(11) NOT NULL UNIQUE,
        Address NVARCHAR(200) NOT NULL,
        AreaCode VARCHAR(5) NOT NULL DEFAULT '+48',
        PhoneNumber VARCHAR(15) NOT NULL
    );
END;
GO

-- 3. Wstawianie 50 gotowych rekordów z numerami telefonów
INSERT INTO Patients (Name, Surname, Email, PESEL, Address, AreaCode, PhoneNumber)
VALUES
('Jan', 'Kowalski', 'jan.kowalski1@example.com', '90010112347', 'ul. Długa 1, Warszawa', '+48', '501 234 567'),
('Anna', 'Nowak', 'anna.nowak2@example.com', '85021509880', 'ul. Krótka 5, Kraków', '+48', '602 345 678'),
('Piotr', 'Wiśniewski', 'piotr.wisniewski3@example.com', '92031004512', 'ul. Miodowa 12, Wrocław', '+48', '703 456 789'),
('Maria', 'Wójcik', 'maria.wojcik4@example.com', '78042011246', 'ul. Słoneczna 3, Poznań', '+48', '514 567 890'),
('Krzysztof', 'Kowalczyk', 'krzysztof.kowalczyk5@example.com', '65050503138', 'ul. Lipowa 8, Gdańsk', '+48', '625 678 901'),
('Katarzyna', 'Kamińska', 'katarzyna.kaminska6@example.com', '01261205423', 'ul. Polna 15, Szczecin', '+48', '736 789 012'),
('Tomasz', 'Lewandowski', 'tomasz.lewandowski7@example.com', '95071908753', 'ul. Ogrodowa 22, Bydgoszcz', '+48', '507 890 123'),
('Ewa', 'Zielińska', 'ewa.zielinska8@example.com', '88082502167', 'ul. Leśna 4, Lublin', '+48', '618 901 234'),
('Michał', 'Szymański', 'michal.szymanski9@example.com', '03290306371', 'ul. Parkowa 9, Białystok', '+48', '729 012 345'),
('Agnieszka', 'Woźniak', 'agnieszka.wozniak10@example.com', '72101101984', 'ul. Szkolna 11, Katowice', '+48', '530 123 456'),
('Paweł', 'Dąbrowski', 'pawel.dabrowski11@example.com', '81110507818', 'ul. Kwiatowa 7, Gdynia', '+48', '641 234 567'),
('Zofia', 'Kozłowska', 'zofia.kozlowska12@example.com', '99123103429', 'ul. Fabryczna 19, Częstochowa', '+48', '752 345 678'),
('Marcin', 'Jankowski', 'marcin.jankowski13@example.com', '05211508934', 'ul. Rynek 2, Radom', '+48', '503 456 789'),
('Magdalena', 'Mazur', 'magdalena.mazur14@example.com', '93022804560', 'ul. Polna 30, Sosnowiec', '+48', '614 567 890'),
('Jakub', 'Wojciechowski', 'jakub.wojciechowski15@example.com', '87031401275', 'ul. Zielona 14, Toruń', '+48', '725 678 901'),
('Barbara', 'Kwiatkowska', 'barbara.kwiatkowska16@example.com', '74040809881', 'ul. Cicha 6, Kielce', '+48', '536 789 012'),
('Grzegorz', 'Krawczyk', 'grzegorz.krawczyk17@example.com', '69051806399', 'ul. Nowa 25, Rzeszów', '+48', '647 890 123'),
('Małgorzata', 'Kaczmarek', 'malgorzata.kaczmarek18@example.com', '02262202102', 'ul. Jasna 10, Gliwice', '+48', '758 901 234'),
('Łukasz', 'Piotrowski', 'lukasz.piotrowski19@example.com', '91070707831', 'ul. Prosta 18, Zabrze', '+48', '509 012 345'),
('Karolina', 'Grabowska', 'karolina.grabowska20@example.com', '83081903448', 'ul. Zamkowa 3, Olsztyn', '+48', '610 123 456'),
('Marek', 'Zając', 'marek.zajac21@example.com', '77091208953', 'ul. Wesoła 12, Bielsko-Biała', '+48', '721 234 567'),
('Natalia', 'Pawłowska', 'natalia.pawlowska22@example.com', '04210304561', 'ul. Spacerowa 5, Bytom', '+48', '532 345 678'),
('Kamil', 'Michalski', 'kamil.michalski23@example.com', '96112401272', 'ul. Polna 40, Zielona Góra', '+48', '643 456 789'),
('Joanna', 'Król', 'joanna.krol24@example.com', '89120609889', 'ul. Dębowa 8, Rybnik', '+48', '754 567 890'),
('Maciej', 'Wieczorek', 'maciej.wieczorek25@example.com', '00211706392', 'ul. Sosnowa 16, Ruda Śląska', '+48', '505 678 901'),
('Dorota', 'Jabłońska', 'dorota.jablonska26@example.com', '76022802105', 'ul. Brzozowa 21, Tychy', '+48', '616 789 012'),
('Mikołaj', 'Wróbel', 'mikolaj.wrobel27@example.com', '94030907837', 'ul. Kolejowa 9, Opole', '+48', '727 890 123'),
('Monika', 'Nowakowska', 'monika.nowakowska28@example.com', '82041503444', 'ul. Portowa 2, Gorzów Wielkopolski', '+48', '538 901 234'),
('Mateusz', 'Majewski', 'mateusz.majewski29@example.com', '06252008955', 'ul. Polna 50, Dąbrowa Górnicza', '+48', '649 012 345'),
('Marta', 'Olszewska', 'marta.olszewska30@example.com', '71061104568', 'ul. Główna 7, Elbląg', '+48', '750 123 456'),
('Adam', 'Adamczyk', 'adam.adamczyk31@example.com', '98070301278', 'ul. Długa 100, Płock', '+48', '501 987 654'),
('Klaudia', 'Jaworska', 'klaudia.jaworska32@example.com', '86082209886', 'ul. Krótka 15, Wałbrzych', '+48', '602 876 543'),
('Patryk', 'Malinowski', 'patryk.malinowski33@example.com', '08291006394', 'ul. Słoneczna 88, Włocławek', '+48', '703 765 432'),
('Aleksandra', 'Stępień', 'aleksandra.stepien34@example.com', '79100402103', 'ul. Lipowa 33, Tarnów', '+48', '514 654 321'),
('Sebastian', 'Górecki', 'sebastian.gorecki35@example.com', '93111807830', 'ul. Parkowa 12, Chorzów', '+48', '625 543 210'),
('Szymon', 'Pawlak', 'szymon.pawlak36@example.com', '84122903451', 'ul. Szkolna 4, Koszalin', '+48', '736 432 109'),
('Alicja', 'Mazurek', 'alicja.mazurek37@example.com', '01210808940', 'ul. Kwiatowa 50, Kalisz', '+48', '507 321 098'),
('Adrian', 'Rutkowski', 'adrian.rutkowski38@example.com', '75021904550', 'ul. Leśna 17, Legnica', '+48', '618 210 987'),
('Izabela', 'Michalak', 'izabela.michalak39@example.com', '97033101264', 'ul. Cicha 23, Grudziądz', '+48', '729 109 876'),
('Bartłomiej', 'Sikora', 'bartlomiej.sikora40@example.com', '80041209873', 'ul. Nowa 44, Jaworzno', '+48', '530 098 765'),
('Dominika', 'Baran', 'dominika.baran41@example.com', '07252506387', 'ul. Jasna 8, Słupsk', '+48', '641 987 654'),
('Filip', 'Szewczyk', 'filip.szewczyk42@example.com', '73060602113', 'ul. Prosta 9, Jastrzębie-Zdrój', '+48', '752 876 543'),
('Weronika', 'Ostrowska', 'weronika.ostrowska43@example.com', '92072107840', 'ul. Zamkowa 14, Nowy Sącz', '+48', '503 765 432'),
('Dawid', 'Duda', 'dawid.duda44@example.com', '85080303452', 'ul. Wesoła 31, Jelenia Góra', '+48', '614 654 321'),
('Roksana', 'Pietrzak', 'roksana.pietrzak45@example.com', '09291408948', 'ul. Spacerowa 77, Siedlce', '+48', '725 543 210'),
('Krystian', 'Marciniak', 'krystian.marciniak46@example.com', '70102704571', 'ul. Dębowa 3, Mysłowice', '+48', '536 432 109'),
('Oliwia', 'Włodarczyk', 'oliwia.wlodarczyk47@example.com', '96110901268', 'ul. Sosnowa 11, Konin', '+48', '647 321 098'),
('Igor', 'Dudek', 'igor.dudek48@example.com', '81122209871', 'ul. Brzozowa 5, Piotrków Trybunalski', '+48', '758 210 987'),
('Kinga', 'Jasinska', 'kinga.jasinska49@example.com', '03210406380', 'ul. Kolejowa 80, Inowrocław', '+48', '509 109 876'),
('Hubert', 'Wysocki', 'hubert.wysocki50@example.com', '74021602112', 'ul. Ogrodowa 1, Lubin', '+48', '610 098 765');
GO