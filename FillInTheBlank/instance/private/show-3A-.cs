show: fillInView
	| savedArea |
	savedArea := Form fromDisplay: fillInView displayBox.
	fillInView display.
	contents isEmpty
		ifFalse: [fillInView lastSubView controller selectFrom: 1 to: contents size].
	(fillInView lastSubView containsPoint: Sensor cursorPoint)
		ifFalse: [fillInView lastSubView controller centerCursorInView].
	fillInView controller startUp.
	fillInView release.
	savedArea displayOn: Display at: fillInView viewport topLeft.
	^ contents