open
	"Open it with the standard db:"
	| database dbName |
	dbName _ Celeste defaultDBName.
	(MailDB isADBNamed: dbName)
		ifTrue: [database _ MailDB openOn: dbName]
		ifFalse: [self error: 'I need a valid Mail DB to process: Please setup Celeste before opening CelesteAddressBook'].
	^ self new openOn: database