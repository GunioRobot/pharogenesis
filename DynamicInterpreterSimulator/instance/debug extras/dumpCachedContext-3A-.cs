dumpCachedContext: aContext
	| sp ip rcvr elt lo hi |
	sp _ self cachedStackIndexAt: aContext.
	ip _ self cachedInstructionIndexAt: aContext.
	rcvr _ (self isCachedMethodContext: aContext)
				ifTrue: [self cachedReceiverAt: aContext]
				ifFalse: [0].
	^String streamContents: [:str |
		str	nextPutAll: (self printCachedContext: aContext); cr;
			nextPutAll: '	ip		'	, (self shortPrint: ip); cr;
			nextPutAll: '	sp		'	, (self shortPrint: sp); cr.
		rcvr = 0 ifFalse: [str nextPutAll: ' 	rcvr	'	, (self shortPrint: rcvr); cr].
		str nextPutAll: '	stack	{ '.
		lo _ self cachedFramePointerAt: aContext.
		hi _ self cachedStackPointerAt: aContext.
		lo to: hi by: 4 do: [ :ptr |
			elt _ self longAt: ptr.
			str nextPutAll: (self shortPrint: elt).
			ptr == hi ifFalse: [str cr; nextPutAll: '			  '].
		].
		str nextPutAll: ' }'.].