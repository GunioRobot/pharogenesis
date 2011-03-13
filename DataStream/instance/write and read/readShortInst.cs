readShortInst
	"Read the contents of an arbitrary instance that has a short header.
	 ASSUMES: readDataFrom:size: sends me beginReference: after it
	   instantiates the new object but before reading nested objects.
	 NOTE: We must restore the current reference position after
	   recursive calls to next.
	Let the instance, not the class read the data.  "
	| instSize aSymbol refPosn anObject newClass |

	instSize _ (byteStream next) - 1.	"one byte of size"
	refPosn _ self getCurrentReference.
	aSymbol _ self readShortRef.	"class symbol in two bytes of file pos"
	newClass _ Smalltalk at: aSymbol asSymbol.
	anObject _ newClass isVariable 	"Create object here"
			ifFalse: [newClass basicNew]
			ifTrue: [newClass basicNew: instSize - (newClass instSize)].
	self setCurrentReference: refPosn.  "before readDataFrom:size:"
	anObject _ anObject readDataFrom: self size: instSize.
	self setCurrentReference: refPosn.  "before returning to next"
	^ anObject