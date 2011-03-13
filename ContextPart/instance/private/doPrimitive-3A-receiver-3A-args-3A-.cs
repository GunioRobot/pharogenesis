doPrimitive: primitiveIndex receiver: receiver args: arguments 
	"Simulate a primitive method whose index is primitiveIndex.  The
	simulated receiver and arguments are given as arguments to this message."
	| primitiveMethod value |
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
		ifTrue: [^self send: (arguments at: 1) to: receiver
					with: (arguments copyFrom: 2 to: arguments size)
					super: false].
	arguments size > 6 ifTrue: [^#simulatorFail].
	primitiveMethod _ TryPrimitiveMethods at: arguments size + 1.
	"slam num into primitive instead of 100 such messages in Object"
	primitiveMethod bePrimitive: primitiveIndex.
	"Class flushCache."  "in case interp caches primitive #"
	value _ receiver perform: (TryPrimitiveSelectors at: arguments size+1)
				withArguments: arguments.
	value == #simulatorFail
		ifTrue: [^ #simulatorFail]
		ifFalse: [^ self push: value]