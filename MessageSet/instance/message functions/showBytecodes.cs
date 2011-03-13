showBytecodes
	"Show the bytecodes of the selected method."
	"Set a mode for contents!"

	((self messageListIndex = 0) | (self okToChange not))
		ifTrue: [^ self changed: #flash].
	contents _ (self selectedClassOrMetaClass compiledMethodAt: 
					self selectedMessageName) symbolic asText.
	self changed: #contents.
