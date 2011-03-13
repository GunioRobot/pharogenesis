readWordLike
	| refPosn newClass anObject className |
	"Can be used by any class that is bits and not bytes (WordArray, Bitmap, SoundBuffer, etc)."

	refPosn _ self getCurrentReference.
	className _ self next asSymbol.
	className _ renamed at: className ifAbsent: [className].
	newClass _ Smalltalk at: className.
	anObject _ newClass newFromStream: byteStream.
	"Size is number of long words."
	self setCurrentReference: refPosn.  "before returning to next"
	^ anObject
