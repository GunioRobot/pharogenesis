mouseDown: evt
	(owner wantsKeyboardFocusFor: self) ifTrue:
		[putSelector ifNotNil: [self launchMiniEditor: evt]]