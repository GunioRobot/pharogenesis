doPrimitive: primitiveIndex method: meth receiver: receiver args: arguments 
	"Simulate a primitive method whose index is primitiveIndex.  The
	simulated receiver and arguments are given as arguments to this message."

	| value |
	<primitive: 19> "Simulation guard"
	"If successful, push result and return resuming context,
		else ^ PrimitiveFailToken"
		
		
	(primitiveIndex = 19) ifTrue:[
		ToolSet 
			debugContext: self
			label:'Code simulation error'
			contents: nil].

	(primitiveIndex = 80 and: [receiver isKindOf: ContextPart])
		ifTrue: [^self push: ((BlockContext newForMethod: receiver home method)
						home: receiver home
						startpc: pc + 2
						nargs: (arguments at: 1))].
	(primitiveIndex = 81 and: [receiver isMemberOf: BlockContext])
		ifTrue: [^receiver pushArgs: arguments from: self].
	(primitiveIndex = 82 and: [receiver isMemberOf: BlockContext])
		ifTrue: [^receiver pushArgs: arguments first from: self].

	primitiveIndex = 83 "afr 9/11/1998 19:50"
		ifTrue: [^ self send: arguments first to: receiver
					with: arguments allButFirst
					super: false].
	primitiveIndex = 84 "afr 9/11/1998 19:50"
		ifTrue: [^ self send: arguments first to: receiver
					with: (arguments at: 2)
					super: false].
	primitiveIndex = 186 ifTrue: [ "closure value"
		| m |
		m _ receiver method.
		arguments size = m numArgs ifFalse: [^ PrimitiveFailToken].
		^ self activateMethod: m
			withArgs: arguments
			receiver: receiver
			class: receiver class].
	primitiveIndex = 187 ifTrue: [ "closure valueWithArguments:"
		| m args |
		m _ receiver method.
		args _ arguments first.
		args size = m numArgs ifFalse: [^ PrimitiveFailToken].
		^ self activateMethod: m
			withArgs: args
			receiver: receiver
			class: receiver class].
	primitiveIndex = 188 ifTrue: [ "object withArgs:executeMethod:"
		| m args |
		args _ arguments first.
		m _ arguments second.
		args size = m numArgs ifFalse: [^ PrimitiveFailToken].
		^ self activateMethod: m
			withArgs: args
			receiver: receiver
			class: receiver class].
	arguments size > 6 ifTrue: [^ PrimitiveFailToken].
	primitiveIndex = 117 
		ifTrue:[value _ self tryNamedPrimitiveIn: meth for: receiver withArgs: arguments]
		ifFalse:[value _ receiver tryPrimitive: primitiveIndex withArgs: arguments].
	value == PrimitiveFailToken
		ifTrue: [^ PrimitiveFailToken]
		ifFalse: [^ self push: value]