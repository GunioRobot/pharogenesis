dumpStableBlockContext: aContext
	| sp ip isp elt home |
	sp _ self fetchPointer: StackPointerIndex ofObject: aContext.
	ip _ self fetchPointer: InstructionPointerIndex ofObject: aContext.
	home _ self fetchPointer: HomeIndex ofObject: aContext.
	^String streamContents: [:str |
		str	nextPutAll: (self printStableContext: aContext); cr;
			nextPutAll: '	ip		'	, (self shortPrint: ip); cr;
			nextPutAll: '	sp		'	, (self shortPrint: sp); cr;
			nextPutAll: '	stack	{ '.
		isp _ self integerValueOf: sp.
		0 to: isp - 1 do: [ :off |
			elt _ self fetchPointer: off + TempFrameStart ofObject: aContext.
			str nextPutAll: (self shortPrint: elt).
			off == (isp - 1) ifFalse: [str cr; nextPutAll: '			  '].
		].
		str nextPutAll: ' }'; cr; nextPutAll: '	home	' , (self dumpStableContext: home).
].