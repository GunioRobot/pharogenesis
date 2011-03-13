readInstance
	"PRIVATE -- Read the contents of an arbitrary instance.
	 ASSUMES: readDataFrom:size: sends me beginReference: after it
	   instantiates the new object but before reading nested objects.
	 NOTE: We must restore the current reference position after
	   recursive calls to next."
	| instSize aSymbol refPosn anObject |

	instSize _ (byteStream nextNumber: 4) - 1.
	refPosn _ self getCurrentReference.
	aSymbol _ self next.
	self setCurrentReference: refPosn.  "before readDataFrom:size:"
	aSymbol endsWithDigit ifTrue: [
		self flag: #hot.
		"Remove this once we know no Alias123 are written"
		aSymbol _ aSymbol stemAndNumericSuffix at: 1].
	anObject _ (Smalltalk at: aSymbol asSymbol)
		readDataFrom: self size: instSize.
	self setCurrentReference: refPosn.  "before returning to next"
	^ anObject