internalQuickCheckForInterrupts
	"Internal version of quickCheckForInterrupts for use within jumps."

	self inline: true.
	((interruptCheckCounter _ interruptCheckCounter - 1) <= 0) ifTrue: [
		self externalizeIPandSP.
		self checkForInterrupts.

		self browserPluginReturnIfNeeded.

		self internalizeIPandSP].
