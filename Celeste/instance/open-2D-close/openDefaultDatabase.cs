openDefaultDatabase
	"open the default database, creating it if it isn't present"
	self openOnDatabase: (MailDB openOn: Celeste defaultDBName).
	self changed: #categoryList.