openOn: rootFilename
	"Open or create a mail database with the given root filename. If an instance of me exists with the given root filename, return a reference to that instance rather than creating a new one. This allows multiple MailReaders to be open on the same database without synchronization problems."

	| alreadyOpenDB |
	alreadyOpenDB _ self allSubInstances
		detect:
			[: db |
			 (db rootFilename notNil) and:
			 [db rootFilename = rootFilename]]
		ifNone: [nil].
	(alreadyOpenDB notNil)
		ifTrue: [^alreadyOpenDB reopenDB]
		ifFalse: [^(self new) openOn: rootFilename].