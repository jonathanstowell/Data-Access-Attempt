ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [DataAccessTest], FILENAME = '$(DefaultDataPath)$(DatabaseName).mdf', SIZE = 3072 KB, FILEGROWTH = 1024 KB) TO FILEGROUP [PRIMARY];

