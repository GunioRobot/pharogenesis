openOn: rootFilename
	"Open a MailReader on the mail database with the given root filename."
	|database |

	(MailDB isADBNamed: rootFilename)
		ifTrue: [ database _  MailDB openOn: rootFilename. ]
		ifFalse: [ database _ nil.  "open an empty Celeste with a welcome message" ].

	^self openOnDatabase: database