wantsRolloverIndicator: aBoolean

	wantsRolloverIndicator _ aBoolean.
	wantsRolloverIndicator ifTrue: [
		self setEventHandlers: true.
	].