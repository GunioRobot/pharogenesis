initializeCacheIndices		"ContextCache initialize"

	"Method contexts"
	CacheSenderIndex				_ 0.						"caller of this method context"
	CacheInstructionPointerIndex		_ 1.						"raw instruction pointer (points into method body)"
	CacheStackPointerIndex			_ 2.						"raw stack pointer (points into stack cache)"
	CacheMethodIndex				_ 3.						"method (home method for blocks)"
	CacheReceiverIndex				_ 4.						"receiver (home receiver for blocks)"

	"Block contexts"
	CacheCallerIndex				_ CacheSenderIndex.		"caller of this block context"
	CacheBlockArgumentCountIndex	_ 5.						"number of arguments (used only in stabilisation)"
	CacheInitialIPIndex				_ 6.						"initial IP (used only in stabilisation)"
	CacheHomeIndex					_ 7.						"home context (stable or pseudo) (0 for methods)"

	"All contexts"
	CachePseudoContextIndex			_ 8.						"allocated PseudoContext (0 if unallocated)"
	CacheFramePointerIndex			_ 9.						"address of stack frame (first temp) in cache"
	CacheTempPointerIndex			_ 10.					"address of first temporary in cache or heap context"
	CacheTranslatedMethodIndex		_ 11.					"translated method corresponding to method"
	"CacheContextReceiverFlagIndex	_ 12."					"non-nil if receiver is a context"

	CachedContextSize				_ 12.