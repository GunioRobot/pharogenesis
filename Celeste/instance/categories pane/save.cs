save
	"Snapshot the database to disk."
	mailDB ifNil: [ ^self ].
	mailDB saveDB; saveTokens.
