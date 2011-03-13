streamForFile: fileName
	"Return a readonly stream for file <fileName>.
	If the file does not exist return nil."

	| stream |
	[stream := StandardFileStream oldFileNamed: (self uploadsDirectory fullNameFor: fileName)]
		on: FileDoesNotExistException do: [^nil].
	^stream