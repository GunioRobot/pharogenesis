consolidateDB
	"Write all database files to disk."
	rootFilename notNil
		ifTrue: [Transcript show: 'Saving mail database ''' , rootFilename , '''...']
		ifFalse: [Transcript show: 'Saving mail database...'].
	messageFile notNil ifTrue: [messageFile save].
	indexFile notNil ifTrue: [indexFile save].
	categoriesFile notNil ifTrue: [categoriesFile save].
	Transcript show: 'Done.';
	 cr