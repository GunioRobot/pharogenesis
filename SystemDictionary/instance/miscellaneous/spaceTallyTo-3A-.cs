spaceTallyTo: aFileName

	| answer s |
	Smalltalk garbageCollect.
	answer _ Smalltalk spaceTally.
	(FileDirectory default fileExists: aFileName) ifTrue: [
		FileDirectory default deleteFileNamed: aFileName
	].
	s _ FileDirectory default fileNamed: aFileName.
	answer do: [ :each | s nextPutAll: each printString; cr].
	s close

