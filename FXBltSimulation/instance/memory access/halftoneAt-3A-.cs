halftoneAt: idx
	"Return a value from the halftone pattern."
	^interpreterProxy longAt: halftoneBase + (idx \\ halftoneHeight * 4)