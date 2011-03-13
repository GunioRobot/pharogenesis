blockReturnTop
	"Return from a block with Top Of Stack as result.
	The following instruction will be branched to from somewhere, and will
	therefore trigger a stackMerge, so it is important that the stack be emptied."

	self pop.
	self emptyStack.