directoryNamed: localFileName
	| newDir |
	newDir _ super directoryNamed: localFileName.
	newDir altUrl: (self altUrl , '/' , localFileName).
	^newDir