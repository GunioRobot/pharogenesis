primitiveNext
	"PrimitiveNext will succeed only if the stream's array is in the atCache.
	Otherwise failure will lead to proper message lookup of at: and
	subsequent installation in the cache if appropriate."
	| stream array index limit result atIx |
	stream _ self stackTop.
	((self isPointers: stream)
		and: [(self lengthOf: stream) >= (StreamReadLimitIndex + 1)])
		ifFalse: [^ self primitiveFail].

	array _ self fetchPointer: StreamArrayIndex ofObject: stream.
	index _ self fetchInteger: StreamIndexIndex ofObject: stream.
	limit _ self fetchInteger: StreamReadLimitIndex ofObject: stream.
	atIx _ array bitAnd: AtCacheMask.
	(index < limit and: [(atCache at: atIx+AtCacheOop) = array])
		ifFalse: [^ self primitiveFail].

	"OK -- its not at end, and the array is in the cache"
	index _ index + 1.
	result _ self commonVariable: array at: index cacheIndex: atIx.
	"Above may cause GC, so can't use stream, array etc. below it"
	successFlag ifTrue:
		[stream _ self stackTop.
		self storeInteger: StreamIndexIndex ofObject: stream withValue: index.
		^ self pop: 1 thenPush: result].
