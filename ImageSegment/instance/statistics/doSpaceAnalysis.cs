doSpaceAnalysis
	"Capture statistics about the IS and print the number of instances per class and space usage"
	| index sz word hdrBits cc instCount instSpace |
	state == #activeCopy ifFalse:[self errorWrongState].
	instCount _ IdentityDictionary new.
	instSpace _ IdentityDictionary new.
	index _ 2. 	"skip version word, first object"
	"go past extra header words"
	hdrBits _ (segment at: index) bitAnd: 3.
	hdrBits = 1 ifTrue: [index _ index+1].
	hdrBits = 0 ifTrue: [index _ index+2].
	[index > segment size] whileFalse:[
		hdrBits _ (word _ segment at: index) bitAnd: 3.
		hdrBits = 2 ifTrue:[sz _ word bitAnd: 16rFFFFFFFC].
		hdrBits = 0 ifTrue:[sz _ ((segment at: index-2) bitAnd: 16rFFFFFFFC) + 8].
		hdrBits = 1 ifTrue:[sz _ (word bitAnd: "SizeMask" 252) + 4].
		hdrBits = 3 ifTrue:[sz _ word bitAnd: "SizeMask" 252].
		hdrBits = 2 
			ifTrue:[cc _ #freeChunk]
			ifFalse:[cc _ self classNameAt: index].
		instCount at: cc put: (instCount at: cc ifAbsent:[0]) + 1.
		instSpace at: cc put: (instSpace at: cc ifAbsent:[0]) + sz.
		index _ self objectAfter: index].
	^{instCount. instSpace}