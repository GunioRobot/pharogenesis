saveSession

	self deprecated: 'Use SmalltalkImage current saveSession'.
	SmalltalkImage current snapshot: true andQuit: false