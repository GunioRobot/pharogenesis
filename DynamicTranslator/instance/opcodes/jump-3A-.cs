jump: offset
	self inline: true.

	localIP _ localIP + (offset "* 8").
	offset < 0 ifTrue: [
		"backward jump means we're in a loop; check for possible interrupts"
		self internalQuickCheckForInterrupts.
	]