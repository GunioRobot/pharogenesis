flushInlineCache
	"Called from several places, just after a call to flushMethodCache"

	EagerInlineCacheFlush ifFalse:
		[translationCycle _ translationCycle + 2].		"ConstOne minus the tag bit"