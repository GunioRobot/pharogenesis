internalQuickCheckForInterrupts
	"Internal version of quickCheckForInterrupts for use within jumps."

	((interruptCheckCounter _ interruptCheckCounter - 1) <= 0) ifTrue: [
		interruptCheckCounter _ 1000.
		self externalizeIPandSP.
		self checkForInterrupts.
		self internalizeIPandSP.
	].
