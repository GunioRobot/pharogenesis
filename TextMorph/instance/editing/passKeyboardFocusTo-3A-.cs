passKeyboardFocusTo: otherMorph
	| w |
	(w _ self world) == nil ifFalse:
		[w handsDo:
			[:h | h keyboardFocus == self
				ifTrue: [h newKeyboardFocus: otherMorph]]].
