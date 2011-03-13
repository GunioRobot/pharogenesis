delete
	| label |
	target ifNotNil:[target hasHalo: false].
	(label _ self findA: NameStringInHalo) ifNotNil:
		[label hasFocus ifTrue:
			[label lostFocusWithoutAccepting]].
	super delete