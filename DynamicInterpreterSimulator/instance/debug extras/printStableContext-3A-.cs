printStableContext: aContext
	| classAndSel home |
	^ String streamContents: [:strm |
		home _ (self fetchClassOf: aContext) = (self splObj: ClassBlockContext)
			ifTrue: [self fetchPointer: HomeIndex ofObject: aContext]
			ifFalse: [aContext].
		classAndSel _ self
			classAndSelectorOfMethod: (self fetchPointer: MethodIndex ofObject: home)
			forReceiver: (self fetchPointer: ReceiverIndex ofObject: home).
		aContext = home ifFalse: [strm nextPutAll: '[] in '].
		strm nextPutAll: (self nameOfClass: classAndSel first).
		strm nextPutAll: '>>'; nextPutAll: (self shortPrint: classAndSel last).]