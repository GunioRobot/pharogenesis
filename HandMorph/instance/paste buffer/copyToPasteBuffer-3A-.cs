copyToPasteBuffer: aMorph
	"Save this morph in the paste buffer. This is mostly useful for copying morphs between projects."
	aMorph ifNil:[^PasteBuffer _ nil].
	Cursor wait showWhile:[
		PasteBuffer _ aMorph topRendererOrSelf veryDeepCopy.
		PasteBuffer privateOwner: nil].

