printCallStack

	| ctxt home methodClass methodSel |
	ctxt _ activeContext.
	[ctxt = nilObj] whileFalse: [
		(self fetchClassOf: ctxt) = (self splObj: ClassBlockContext)
			ifTrue: [ home _ self fetchPointer: HomeIndex ofObject: ctxt ]
			ifFalse: [ home _ ctxt ].
		methodClass _
			self findClassOfMethod: (self fetchPointer: MethodIndex ofObject: home)
					   forReceiver: (self fetchPointer: ReceiverIndex ofObject: home).
		methodSel _
			self findSelectorOfMethod: (self fetchPointer: MethodIndex ofObject: home)
						 forReceiver: (self fetchPointer: ReceiverIndex ofObject: home).
		self printNum: ctxt.
		self print: ' '.
		ctxt = home ifFalse: [ self print: '[] in ' ].
		self printNameOfClass: methodClass count: 5.
		self print: '>'.
		self printStringOf: methodSel.
		self cr.

		ctxt _ (self fetchPointer: SenderIndex ofObject: ctxt).
	].