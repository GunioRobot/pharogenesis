wantsKeyboardFocusFor: aSubmorph
	aSubmorph wouldAcceptKeyboardFocus ifTrue: [^ true].
	^ super wantsKeyboardFocusFor: aSubmorph