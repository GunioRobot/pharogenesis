install: inStream  usingBaseName: basename
	"find a changeset name that is not used"
	| num changesetName stream |
	num _ 0.
	[  	changesetName _ basename.
	   	num > 0 ifTrue:[ changesetName _ changesetName, '-', num printString. ].
		(ChangeSorter changeSetNamed: changesetName) notNil ]
	whileTrue: [ num _ num + 1 ].
	
	"decompress if necessary"
	inStream peek asInteger = 16r1F
		ifTrue: [ stream _ ReadStream on: ((GZipReadStream on: inStream) upToEnd) asString ]
		ifFalse: [ stream _ inStream ].
		
	ChangeSorter newChangesFromStream: stream named: changesetName