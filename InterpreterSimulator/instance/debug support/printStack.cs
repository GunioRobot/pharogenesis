printStack
	| ctxt classAndSel home |
	ctxt _ activeContext.
	^ String streamContents:
		[:strm |
			[home _ (self fetchClassOf: ctxt) = (self splObj: ClassBlockContext)
				ifTrue: [self fetchPointer: HomeIndex ofObject: ctxt]
				ifFalse: [ctxt].
			classAndSel _ self
				classAndSelectorOfMethod: (self fetchPointer: MethodIndex ofObject: home)
				forReceiver: (self fetchPointer: ReceiverIndex ofObject: home).
			strm cr; nextPutAll: ctxt hex8.
			ctxt = home ifFalse: [strm nextPutAll: ' [] in'].
			strm space; nextPutAll: (self nameOfClass: classAndSel first).
			strm nextPutAll: '>>'; nextPutAll: (self shortPrint: classAndSel last).
			(ctxt _ (self fetchPointer: SenderIndex ofObject: ctxt)) = nilObj]
				whileFalse: [].
		]