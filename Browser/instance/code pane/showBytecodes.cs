showBytecodes
	"Show the bytecodes of the selected method."
	"Set a mode for contents!"

	((self messageListIndex = 0) | (self okToChange not))
		ifTrue: [^ self changed: #flash].
	editSelection _ #byteCodes.
	self changed: #contents.
