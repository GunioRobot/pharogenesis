openOn: rootFilename
	"Open a MailReader on the mail database with the given root filename."
	|database |

	database _  MailDB openOn: rootFilename.
	database ifNotNil: [ ^ self openOnDatabase: database ].