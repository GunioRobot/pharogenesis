printCallStack

	| ctxt home methodClass methodSel stable meth recv iptr |
	activeCachedContext = 0 ifFalse: [
		ctxt _ activeCachedContext.
		self stackPointer = -1 ifTrue: [
			self print: 'Warning: stackPointer is internal -- backtrace might be incorrect!'.
			self cr.
			self fetchContextRegisters: activeCachedContext.
		].
		stable _ 0.
		[stable = 0] whileTrue: [
			"Find receiver and method"
			(self isCachedMethodContext: ctxt) ifTrue: [
				meth _ self cachedMethodAt: ctxt.
				recv _ self cachedReceiverAt: ctxt.
				iptr _ self cachedInstructionIndexAt: ctxt.
			] ifFalse: [
				home _ self cachedHomeAt: ctxt.
				(self isPseudoContext: home) ifTrue: [
					meth _ self cachedMethodAt: (self pseudoCachedContextAt: home).
					recv _ self cachedReceiverAt: (self pseudoCachedContextAt: home).
					iptr _ self cachedInstructionIndexAt: (self pseudoCachedContextAt: home).
				] ifFalse: [
					meth _ self fetchPointer: MethodIndex ofObject: home.
					recv _ self fetchPointer: ReceiverIndex ofObject: home.
					iptr _ self fetchPointer: InstructionPointerIndex ofObject: home.
				].
			].
			methodClass _ self findClassOfMethod: meth forReceiver: recv.
			methodSel _ self findSelectorOfMethod: meth forReceiver: recv.
			self print: '* '; printNum: ctxt; print: '	'.
			self printNum: (self integerValueOf: iptr); print: '	'.
			(self isCachedMethodContext: ctxt) ifTrue: [ self print: '[] in ' ].
			self printNameOfClass: methodClass count: 5; print: '>>'; printStringOf: methodSel; cr.
			ctxt = lowestCachedContext
				ifTrue: [stable _ self cachedSenderAt: ctxt.  ctxt _ 0]
				ifFalse: [ctxt _ self cachedContextBefore: ctxt].
		].
	].
	ctxt _ stable.
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
		self print: '+ '.
		self printNum: ctxt.
		self print: '	'.
		self printNum: (self integerValueOf: (self fetchPointer: InstructionPointerIndex ofObject: ctxt)); print: '	'.
		ctxt = home ifFalse: [ self print: '[] in ' ].
		self printNameOfClass: methodClass count: 5.
		self print: '>>'.
		self printStringOf: methodSel.
		self cr.

		ctxt _ (self fetchPointer: SenderIndex ofObject: ctxt).
	].