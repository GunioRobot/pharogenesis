mouseMove: evt
	(evt anyButtonPressed)
		ifTrue: [self doTargetAction: evt cursorPoint]