readWordLike
	| refPosn aSymbol newClass anObject |
	"Can be used by any class that is bits and not bytes (WordArray, Bitmap, SoundBuffer, etc)."

	refPosn _ self getCurrentReference.
	aSymbol _ self next.
	newClass _ Smalltalk at: aSymbol asSymbol.
	anObject _ newClass newFromStream: byteStream.
	"Size is number of long words."
	self setCurrentReference: refPosn.  "before returning to next"
	^ anObject
