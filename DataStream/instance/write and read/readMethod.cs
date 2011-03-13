readMethod
	"PRIVATE -- Read the contents of an arbitrary instance.
	 ASSUMES: readDataFrom:size: sends me beginReference: after it
	   instantiates the new object but before reading nested objects.
	 NOTE: We must restore the current reference position after
	   recursive calls to next.
	Let the instance, not the class read the data.  "
	| instSize refPosn newClass className xxHeader nLits byteCodeSizePlusTrailer newMethod lits |

	instSize _ (byteStream nextNumber: 4) - 1.
	refPosn _ self getCurrentReference.
	className _ self next.
	newClass _ Smalltalk at: className asSymbol.

	xxHeader _ self next.
		"nArgs _ (xxHeader >> 24) bitAnd: 16rF."
		"nTemps _ (xxHeader >> 18) bitAnd: 16r3F."
		"largeBit _ (xxHeader >> 17) bitAnd: 1."
	nLits _ (xxHeader >> 9) bitAnd: 16rFF.
		"primBits _ ((xxHeader >> 19) bitAnd: 16r600) + (xxHeader bitAnd: 16r1FF)."
	byteCodeSizePlusTrailer _ instSize - (newClass instSize "0") - (nLits + 1 * 4).

	newMethod _ newClass 
		newMethod: byteCodeSizePlusTrailer
		header: xxHeader.

	self setCurrentReference: refPosn.  "before readDataFrom:size:"
	self beginReference: newMethod.
	lits _ newMethod numLiterals + 1.	"counting header"
	2 to: lits do:
		[:ii | newMethod objectAt: ii put: self next].
	lits*4+1 to: newMethod basicSize do:
		[:ii | newMethod basicAt: ii put: byteStream next].
			"Get raw bytes directly from the file"
	self setCurrentReference: refPosn.  "before returning to next"
	^ newMethod