squeakletDirectory

	| squeakletDirectoryName |
	squeakletDirectoryName _ 'Squeaklets'.
	(FileDirectory default directoryExists: squeakletDirectoryName) ifFalse: [
		FileDirectory default createDirectory: squeakletDirectoryName
	].
	^FileDirectory default directoryNamed: squeakletDirectoryName