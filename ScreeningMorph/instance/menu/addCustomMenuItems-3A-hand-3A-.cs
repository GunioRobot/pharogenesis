addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	submorphs size = 0 ifTrue:
		[^ aCustomMenu add: '*Please add a source morph*' action: #itself].
	submorphs size = 1 ifTrue:
		[^ aCustomMenu add: '*Please add a screen morph*' action: #itself].
	submorphs size > 2 ifTrue:
		[^ aCustomMenu add: '*I have too many submorphs*' action: #itself].
	aCustomMenu add: 'show screen only' action: #showScreenOnly.
	aCustomMenu add: 'show source only' action: #showSourceOnly.
	aCustomMenu add: 'show screen over source' action: #showScreenOverSource.
	aCustomMenu add: 'show source screened' action: #showScreened.
	aCustomMenu add: 'exchange source and screen' action: #exchange.
	displayMode == #showScreenOnly ifTrue:
		[aCustomMenu add: 'choose passing color' action: #choosePassingColor.
		aCustomMenu add: 'choose blocking color' action: #chooseBlockingColor].
