printCachedContext: aContext
	| classAndSel meth recv |
	^ String streamContents: [:strm |
		"Find receiver and method"
		meth _ self cachedMethodAt: aContext.
		recv _ self cachedReceiverAt: aContext.
		classAndSel _ self classAndSelectorOfMethod: meth forReceiver: recv.
		(self isCachedBlockContext: aContext) ifTrue: [strm nextPutAll: '[] in '].
		strm nextPutAll: (self nameOfClass: classAndSel first).
		strm nextPutAll: '>>'; nextPutAll: (self shortPrint: classAndSel last).]