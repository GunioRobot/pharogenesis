layoutChanged

	"A submorph could have moved, thus changing my localBounds. Invalidate the cache."
	localBounds _ nil.

	^super layoutChanged