delete
	| label |
	(label _ self findA: NameStringInHalo) ifNotNil:
		[label hasFocus ifTrue:
			[label lostFocusWithoutAccepting]].
	super delete