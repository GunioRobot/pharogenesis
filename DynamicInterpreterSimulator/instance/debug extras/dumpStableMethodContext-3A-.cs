dumpStableMethodContext: aContext
	| sp ip rcvr isp elt |
	sp _ self fetchPointer: StackPointerIndex ofObject: aContext.
	ip _ self fetchPointer: InstructionPointerIndex ofObject: aContext.
	rcvr _ self fetchPointer: ReceiverIndex ofObject: aContext.
	^String streamContents: [:str |
		str	nextPutAll: (self printStableContext: aContext); cr;
			nextPutAll: '	ip		'	, (self shortPrint: ip); cr;
			nextPutAll: '	sp		'	, (self shortPrint: sp); cr;
			nextPutAll: ' 	rcvr	'	, (self shortPrint: rcvr); cr;
			nextPutAll: '	stack	{ '.
		isp _ self integerValueOf: sp.
		0 to: isp - 1 do: [ :off |
			elt _ self fetchPointer: off + TempFrameStart ofObject: aContext.
			str nextPutAll: (self shortPrint: elt).
			off == (isp - 1) ifFalse: [str cr; nextPutAll: '			  '].
		].
		str nextPutAll: ' }'.].