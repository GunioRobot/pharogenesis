addCustomMenuItems: aCustomMenu hand: aHandMorph
	"Add morph-specific items to the given menu which was invoked by the given hand."

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'change font...' action: #changeFont.
	romanNumerals
		ifTrue: [aCustomMenu add: 'use latin numerals' action: #toggleRoman]
		ifFalse: [aCustomMenu add: 'use roman numerals' action: #toggleRoman].
	aCustomMenu add: 'toggle antialiasing' action: #toggleAntialias.
	aCustomMenu add: 'change hands color...' action: #changeHandsColor.
	aCustomMenu add: 'change center color...' action: #changeCenterColor