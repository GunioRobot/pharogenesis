createDB
	"Create a new mail database."

	(self confirm:
'Shall I create a new mail database
named: ', rootFilename, '?')
		ifFalse:	"abort create operation"
			[rootFilename _ nil.
			 self release.
			^nil].
	self openDB.							"creates new DB files"
	self saveDB.							"save the new mail database to disk"