browseChanges
	"Browse the selected file in fileIn format."

	fileName
		ifNotNil:
			[ChangeList browseStream: (directory oldFileNamed: fileName)]
		ifNil:
			[self beep].
