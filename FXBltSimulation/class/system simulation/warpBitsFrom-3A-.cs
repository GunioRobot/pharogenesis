warpBitsFrom: aBitBlt
	"Simulate the warpBits primitive"
	| proxy bb |
	proxy _ InterpreterProxy new.
	proxy loadStackFrom: thisContext sender.
	bb _ self simulatorClass new.
	bb setInterpreter: proxy.
	proxy success: (bb loadWarpBltFrom: aBitBlt).
	bb copyBits.
	proxy failed ifFalse:[
		proxy showDisplayBits: aBitBlt destForm 
				Left: bb affectedLeft Top: bb affectedTop 
				Right: bb affectedRight Bottom: bb affectedBottom].
	^proxy stackValue: 0