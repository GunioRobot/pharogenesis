printCallStackOf: aContext

	| ctxt home methClass methodSel message |
	self inline: false.
	ctxt _ aContext.
	[ctxt = nilObj] whileFalse: [
		(self fetchClassOf: ctxt) = (self splObj: ClassBlockContext)
			ifTrue: [ home _ self fetchPointer: HomeIndex ofObject: ctxt ]
			ifFalse: [ home _ ctxt ].
		methClass _
			self findClassOfMethod: (self fetchPointer: MethodIndex ofObject: home)
					   forReceiver: (self fetchPointer: ReceiverIndex ofObject: home).
		methodSel _
			self findSelectorOfMethod: (self fetchPointer: MethodIndex ofObject: home)
						 forReceiver: (self fetchPointer: ReceiverIndex ofObject: home).
		self printNum: ctxt.
		self print: ' '.
		ctxt = home ifFalse: [ self print: '[] in ' ].
		self printNameOfClass: methClass count: 5.
		self print: '>'.
		methodSel = nilObj
			ifTrue: [self print: '?']
			ifFalse: [self printStringOf: methodSel].
		methodSel = (self splObj: SelectorDoesNotUnderstand) ifTrue: [
			"print arg message selector"
			message _ self fetchPointer: 0 + TempFrameStart ofObject: home.
			methodSel _ self fetchPointer: MessageSelectorIndex ofObject: message.
			self print: ' '.
			self printStringOf: methodSel.
		].
		self cr.

		ctxt _ (self fetchPointer: SenderIndex ofObject: ctxt).
	].