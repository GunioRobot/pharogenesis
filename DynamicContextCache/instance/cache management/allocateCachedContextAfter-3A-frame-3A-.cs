allocateCachedContextAfter: activeContext frame: fp
	"Answer a new cached context, initialised with the given frame pointer,
	and set activeCachedContext to point to it.  If the context cache overflows then eject the lowest
	cached context to make space available.  If the stack cache overflows, wrap it implicitly by setting
	the framePointer in the new context to a usable stack location, and set stackOverflow to true to
	alert the caller.  The caller is *obliged* to check this flag: if it is true then the caller must fetch
	the frame pointer that was actually allocated out of the new context, and use it instead of the
	the frame pointer originally requested.  The caller is also responsible for copying any arguments
	or other values from the top of the stack cache to the new frame's location during stack overflow,
	and for resetting the stackOverflow flag to false once this is done.

	The new cached context has the pseudoContext and sender fields set to 0, the framePointer field
	set to the actual location of the stack frame, the home field set to the supplied home pointer
	(which will be 0 for methods), and the temporaryPointer field set to the base of the temporary
	frame (this is either the same as the framePointer [methods], the frame pointer of the [cached]
	home context, or the address of the first indexable field in the [stable] home context).

								Note:	This method can cause a GC!

	This in turn obliges the caller to truncate the active context's stack AFTER calling this method."

	| newCachedContext |
	self inline: true.

	newCachedContext _ self cachedContextAfter: activeContext.
	newCachedContext = lowestCachedContext ifTrue: [
		self ejectFromCache: newCachedContext.
		lowestCachedContext _ self cachedContextAfter: newCachedContext.
	].

	self initializeCachedContext: newCachedContext.
	activeCachedContext _ newCachedContext.

	fp >= stackCacheFence ifTrue: [
		self cachedFramePointerAt: newCachedContext put: stackCache.	"wrap the stack"
		stackOverflow _ true.
		^newCachedContext.
	].
	self cachedFramePointerAt: newCachedContext put: fp.
	^newCachedContext