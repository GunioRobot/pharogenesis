close
	"Save and close the messageFile."
	self consolidateDB.
	messageFile notNil ifTrue: [messageFile close].
	rootFilename _ nil.
	messageFile _ indexFile _ categoriesFile _ nil