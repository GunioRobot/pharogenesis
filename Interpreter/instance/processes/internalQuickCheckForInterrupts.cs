internalQuickCheckForInterrupts
	"Internal version of quickCheckForInterrupts for use within jumps."

	self inline: true.
	((interruptCheckCounter _ interruptCheckCounter - 1) <= 0) ifTrue: [
		self externalizeIPandSP.
		self checkForInterrupts.

		"When Squeak runs as a browser plugin, it must return control to the browser periodically. This should done only when the state of the currently running Squeak thread is safely stored in the object heap, as is the case at this point. Since this method is inlined, the message 'ReturnFromInterpret' is actually a C macro that returns control from the interpret() method to the browser that called it."
		GenerateBrowserPlugin ifTrue: [
			self plugInTimeToReturn ifTrue: [self ReturnFromInterpret]].

		self internalizeIPandSP].
