externalizeSources   
	"Write the sources and changes streams onto external files."
 	"Smalltalk externalizeSources"

	| sourcesName changesName aFile |
	sourcesName _ self sourcesName.
	(FileDirectory default fileExists: sourcesName)
		ifTrue: [^ self inform:
'Sorry, you must first move or remove the
file named ', sourcesName].
	changesName _ self changesName.
	(FileDirectory default fileExists: changesName)
		ifTrue: [^ self inform:
'Sorry, you must first move or remove the
file named ', changesName].

	aFile _  FileStream newFileNamed: sourcesName.
	aFile nextPutAll: SourceFiles first originalContents.
	aFile close.
	SourceFiles at: 1 put: (FileStream readOnlyFileNamed: sourcesName).

	aFile _ FileStream newFileNamed: self changesName.
	aFile nextPutAll: SourceFiles last contents.
	aFile close.
	SourceFiles at: 2 put: (FileStream oldFileNamed: changesName).

	self inform: 'Sources successfully externalized'.
