doPrimitive: primitiveIndex method: meth receiver: receiver args: arguments 
	"Simulate a primitive method whose index is primitiveIndex.  The
	simulated receiver and arguments are given as arguments to this message."

	| value |
	<primitive: 19> "Simulation guard"
	"If successful, push result and return resuming context,
		else ^ PrimitiveFailToken"
	(primitiveIndex = 19) ifTrue:[
		Debugger 
			openContext: self
			label:'Code simulation error'
			contents: nil].

	(primitiveIndex = 80 and: [receiver isKindOf: ContextPart])
		ifTrue: [^self push: ((BlockContext newForMethod: receiver home method)
						home: receiver home
						startpc: pc + 2
						nargs: (arguments at: 1))].
	(primitiveIndex = 81 and: [receiver isMemberOf: BlockContext])
		ifTrue: [^receiver pushArgs: arguments from: self].
	primitiveIndex = 83 "afr 9/11/1998 19:50"
		ifTrue: [^ self send: arguments first to: receiver
					with: arguments allButFirst
					super: false].
	primitiveIndex = 84 "afr 9/11/1998 19:50"
		ifTrue: [^ self send: arguments first to: receiver
					with: (arguments at: 2)
					super: false].
	arguments size > 6 ifTrue: [^ PrimitiveFailToken].
	primitiveIndex = 117 
		ifTrue:[value _ self tryNamedPrimitiveIn: meth for: receiver withArgs: arguments]
		ifFalse:[value _ receiver tryPrimitive: primitiveIndex withArgs: arguments].
	value == PrimitiveFailToken
		ifTrue: [^ PrimitiveFailToken]
		ifFalse: [^ self push: value]