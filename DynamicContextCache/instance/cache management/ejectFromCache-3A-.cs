ejectFromCache: cp
	"We're ejecting cp, the lowest cached context, to make room for a new active cached
	context.  Fetch the PseudoContext for the ejected context, turn it into a real context,
	and fill it in from the cache.  Fix the sender field in the following cached context to
	point to the newly stabilised context.  Answer the new stable context.
	Assumes:	The cached sender of cp is a stable context.
	Notes:		This method can provoke a GC."

	| ctx |
	self inline: false.
	self assertIsCachedContext: cp.
	ctx _ self pseudoContextFor: cp.
	self assertIsPseudoContext: ctx.
	self copyCache: cp toPseudoContext: ctx setSender: true.
	self assertIsStableContext: ctx.
	self cachedSenderAt: (self cachedContextAfter: cp) put: ctx.
	^ctx