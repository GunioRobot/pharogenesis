closeAllViews  "Transcript closeAllViews"

	self dependents do:
		[:d |
		(d isKindOf: PluggableTextView) ifTrue: [d topView controller closeAndUnscheduleNoTerminate].
		(d isKindOf: SystemWindow) ifTrue: [d delete]]