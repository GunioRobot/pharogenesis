streamForFile: fileName
	"Return a readonly stream for file <fileName>.
	If the file does not exist return nil."

	| stream |
	[stream _ self uploadsDirectory oldFileNamed: fileName]
		on: FileDoesNotExistException do: [^nil].
	^stream