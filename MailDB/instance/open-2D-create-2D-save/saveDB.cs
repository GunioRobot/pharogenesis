saveDB
	"Write all database files to disk.  noRemovals specifies whether any messages were removed from the database -- if so, then the index file doesn't need to be re-saved"

	"Return quietly if the database is no longer in use"
	rootFilename isNil
		ifTrue: [^self].

	Transcript show: 'Saving mail database ''' , (rootFilename ifNil: ['']) , '''...'.

	messageFile notNil ifTrue: [messageFile save].
	indexFile notNil ifTrue: [indexFile save].
	categoriesFile notNil ifTrue: [categoriesFile save].

	Transcript show: 'Done.'; cr