addressOf: rcvr startingAt: byteOffset size: byteSize
	| rcvrClass rcvrSize addr |
	(interpreterProxy isBytes: rcvr) ifFalse:[^interpreterProxy primitiveFail].
	(byteOffset > 0) ifFalse:[^interpreterProxy primitiveFail].
	rcvrClass _ interpreterProxy fetchClassOf: rcvr.
	rcvrSize _ interpreterProxy byteSizeOf: rcvr.
	rcvrClass == interpreterProxy classExternalAddress ifTrue:[
		(rcvrSize = 4) ifFalse:[^interpreterProxy primitiveFail].
		addr _ interpreterProxy fetchWord: 0 ofObject: rcvr.
		"don't you dare to read from object memory!"
		(addr == 0 or:[interpreterProxy isInMemory: addr])
			ifTrue:[^interpreterProxy primitiveFail].
	] ifFalse:[
		(byteOffset+byteSize-1 <= rcvrSize)
			ifFalse:[^interpreterProxy primitiveFail].
		addr _ self cCoerce: (interpreterProxy firstIndexableField: rcvr) to: 'int'.
	].
	addr _ addr + byteOffset - 1.
	^addr