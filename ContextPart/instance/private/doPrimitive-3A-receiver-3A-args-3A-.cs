doPrimitive: primitiveIndex receiver: receiver args: arguments 
	"Simulate a primitive method whose index is primitiveIndex.  The
	simulated receiver and arguments are given as arguments to this message."
"
	NOTE: In order for perform:WithArguments: to work reliably here,
	this method must be forced to invoke a large context.  This is done
	by adding extra temps until the following expression evaluates as true:
		(ContextPart compiledMethodAt: #doPrimitive:receiver:args:) frameSize > 20
"
	| value t1 t2 t3 |
	"If successful, push result and return resuming context,
		else ^ #simulatorFail"
	(primitiveIndex = 80 and: [receiver isKindOf: ContextPart])
		ifTrue: [^self push: 
					((BlockContext new: receiver size)
						home: receiver home
						startpc: pc + 2
						nargs: (arguments at: 1))].
	(primitiveIndex = 81 and: [receiver isMemberOf: BlockContext])
		ifTrue: [^receiver pushArgs: arguments from: self].
	primitiveIndex = 83 
		ifTrue: [^ self send: arguments first to: receiver
					with: arguments allButFirst
					super: false].
	arguments size > 6 ifTrue: [^#simulatorFail].
	value _ receiver tryPrimitive: primitiveIndex withArgs: arguments.
	value == #simulatorFail
		ifTrue: [^ #simulatorFail]
		ifFalse: [^ self push: value]