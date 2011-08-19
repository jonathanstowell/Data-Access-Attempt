ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [DataAccessTest_log], FILENAME = '$(DefaultLogPath)$(DatabaseName)_log.ldf', SIZE = 2560 KB, MAXSIZE = 2097152 MB, FILEGROWTH = 10 %);

