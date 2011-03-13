copyToPasteBuffer
	"Save this morph in the paste buffer. This is mostly useful for copying morphs between projects."

	argument isMorph
		ifTrue: [PasteBuffer _ argument usableDuplicate]
		ifFalse: [PasteBuffer _ nil].

