internalExecuteNewMethod
	| primIndex |
	self inline: true.

	primIndex _ primitiveIndex.
	primIndex > 0
		ifTrue: [(primIndex > 255 and: [primIndex < 520])
				ifTrue: ["Internal return instvars"
						primIndex >= 264
						ifTrue:
						[^ self internalPop: 1 thenPush:
								(self fetchPointer: primIndex-264
										ofObject: self internalStackTop)]
						ifFalse:
						["Internal return constants"
						primIndex = 256 ifTrue: [^ nil "^ self"].
						primIndex = 257 ifTrue: [^ self internalPop: 1 thenPush: trueObj].
						primIndex = 258 ifTrue: [^ self internalPop: 1 thenPush: falseObj].
						primIndex = 259 ifTrue: [^ self internalPop: 1 thenPush: nilObj].
						^ self internalPop: 1 thenPush: (self integerObjectOf: primIndex-261)]]
				ifFalse: 	[self externalizeIPandSP.
						self primitiveResponse.
						self internalizeIPandSP.
						successFlag ifTrue: [^ nil]]].

	"if not primitive, or primitive failed, activate the method"
	self internalActivateNewMethod.

	"check for possible interrupts at each real send"
	self internalQuickCheckForInterrupts.
