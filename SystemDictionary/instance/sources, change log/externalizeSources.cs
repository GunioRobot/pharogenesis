externalizeSources   
	"Write the sources and changes streams onto external files.
		1/29/96 sw"
 	"Smalltalk externalizeSources"

	"NB: openSourceFiles, actualContents, and fileExistsNamed: are symbols not yet in AST image 1/25/96 sw"

	| sourcesName changesName aFile |
	sourcesName _ self sourcesName.
	(FileDirectory default includesKey: sourcesName) ifTrue:
		[^ self inform: 'Sorry, you must first move or remove the
file named ', sourcesName].
	changesName _ self changesName.
	(FileDirectory default includesKey: changesName) ifTrue:
		[^ self inform: 'Sorry, you must first move or remove the
file named ', changesName].


	aFile _  FileStream newFileNamed: sourcesName.
	aFile nextPutAll: SourceFiles first originalContents.
	aFile close.
	SourceFiles at: 1 put: (FileStream readOnlyFileNamed: sourcesName).

	aFile _ FileStream newFileNamed: self changesName.
	aFile nextPutAll: SourceFiles last contents.
	aFile close.
	SourceFiles at: 2 put: (FileStream oldFileNamed: changesName).

	self inform: 'Sources successfully externalized'