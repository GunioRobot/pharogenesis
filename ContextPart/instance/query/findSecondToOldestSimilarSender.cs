findSecondToOldestSimilarSender
	"Search the stack for the second-to-oldest occurance of self's method.  Very useful for an infinite recursion.  Gets back to the second call so you can see one complete recursion cycle, and how it was called at the beginning."

	| sec ctxt bot |
	sec _ self.
	ctxt _ self.
	[	bot _ ctxt findSimilarSender.
		bot isNil
	] whileFalse: [
		sec _ ctxt.
		ctxt _ bot.
	].
	^ sec
