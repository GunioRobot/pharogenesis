primitiveResponseForCachedReceiver

	| thisReceiver ctx result cp |
	self inline: true.
	successFlag _ true.
	primitiveIndex >= 256
		ifTrue:
			[thisReceiver _ self popStack.
			primitiveIndex < 264
				ifTrue: ["Quick return of self or a constant"
						primitiveIndex = 256 ifTrue: [self push: thisReceiver. ^true].
						primitiveIndex = 257 ifTrue: [self push: trueObj. ^true].
						primitiveIndex = 258 ifTrue: [self push: falseObj. ^true].
						primitiveIndex = 259 ifTrue: [self push: nilObj. ^true].
						primitiveIndex = 260 ifTrue: [self push: ConstMinusOne. ^true].
						primitiveIndex = 261 ifTrue: [self push: ConstZero. ^true].
						primitiveIndex = 262 ifTrue: [self push: ConstOne. ^true].
						primitiveIndex = 263 ifTrue: [self push: ConstTwo. ^true].
						^ true]
				ifFalse: ["Quick return of an instance field"
						self assertIsPseudoContext: thisReceiver.
						self assertIsPseudoActiveContext: thisReceiver.
						cp _ self pseudoCachedContextAt: thisReceiver.
						ctx _ self flushCacheFrom: cp.
						result _ (self fetchPointer: primitiveIndex-264 ofObject: ctx).
						self copyContextToCache: ctx.
						self fetchContextRegisters: activeCachedContext.
						self push: result.
						^ true]]
		ifFalse:
			[^ false]