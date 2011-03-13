browseChanges
	"Browse the selected file in fileIn format."

	fileName
		ifNotNil:
			[ChangeList browseStream: (directory readOnlyFileNamed: fileName)]
		ifNil:
			[self beep].
