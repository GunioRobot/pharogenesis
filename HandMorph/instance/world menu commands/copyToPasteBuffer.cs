copyToPasteBuffer
	"Save this morph in the paste buffer. This is mostly useful for copying morphs between projects."

	argument isMorph
		ifTrue: [Cursor wait showWhile: 
					[argument okayToDuplicate ifTrue:
						[PasteBuffer _ argument topRendererOrSelf veryDeepCopy.
						PasteBuffer aboutToBeGrabbedBy: self]]]
		ifFalse: [PasteBuffer _ nil].

