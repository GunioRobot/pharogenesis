updateProgressWatcher: text
	progress subLabel:  text.
	progress done: (completedTests / totalTests) asFloat.
	World doOneCycleNow.
	running ifFalse:[self error:'Run stopped'].