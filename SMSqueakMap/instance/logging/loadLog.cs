loadLog
	"Pick the current logfile - if there is none, create a new and return.
	Otherwise we load the creation date (stored in the beginning).
	Then load all cards in it and build the model. If the creation date is older than 6 months
	we recreate a new logfile in a condensed form and rotate to that."
	
	| file creationDate |
	[file _ self openLogFile.
	file ifNil: [^self createNewLog].
	creationDate _ self loadDateFrom: file.
	self loadUpdatesFrom: file log: false. "we don't log since we are reading from it!"
	(creationDate < (Date today subtractDays: daysBacklog))
		ifTrue:[self saveNewLog]] ensure: [file ifNotNil: [file close]]