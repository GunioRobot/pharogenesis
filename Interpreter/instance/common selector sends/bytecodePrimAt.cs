bytecodePrimAt
	"BytecodePrimAt will only succeed if the receiver is in the atCache.
	Otherwise it will fail so that the more general primitiveAt will put it in the
	cache after validating that message lookup results in a primitive response."
	| index rcvr result atIx |
	index _ self internalStackTop.
	rcvr _ self internalStackValue: 1.
	successFlag _ (self isIntegerObject: rcvr) not and: [self isIntegerObject: index].
	successFlag ifTrue:
		[atIx _ rcvr bitAnd: AtCacheMask.  "Index into atCache = 4N, for N = 0 ... 7"
		(atCache at: atIx+AtCacheOop) = rcvr
		ifTrue: [result _ self commonVariableInternal: rcvr at: (self integerValueOf: index) cacheIndex: atIx.
			successFlag ifTrue:
				[self fetchNextBytecode.
				^self internalPop: 2 thenPush: result]]].

	messageSelector _ self specialSelector: 16.
	argumentCount _ 1.
	self normalSend.
