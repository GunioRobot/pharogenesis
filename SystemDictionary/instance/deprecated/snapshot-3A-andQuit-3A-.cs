snapshot: save andQuit: quit

	self deprecated: 'Use SmalltalkImage current snapshot: save andQuit: quit'.
	^self snapshot: save andQuit: quit embedded: false