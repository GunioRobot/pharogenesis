copyBitsFrom: aBitBlt
	"Simulate the copyBits primitive"
	| proxy bb |
	proxy _ InterpreterProxy new.
	proxy loadStackFrom: thisContext sender home.
	bb _ self simulatorClass new.
	bb initialiseModule.
	bb setInterpreter: proxy.
	proxy success: (bb loadBitBltFrom: aBitBlt).
	bb copyBits.
	proxy failed ifFalse:[
		proxy showDisplayBits: aBitBlt destForm Left: bb affectedLeft Top: bb affectedTop Right: bb affectedRight Bottom: bb affectedBottom].
	^proxy stackValue: 0