﻿ALTER TABLE [dbo].[Person]
    ADD CONSTRAINT [PK_tblPerson] PRIMARY KEY CLUSTERED ([PersonID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

