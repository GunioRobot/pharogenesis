passKeyboardFocusTo: otherMorph
	| w |
self flag: #arNote. "Do we need this?!"
	(w _ self world) == nil ifFalse:
		[w handsDo:
			[:h | h keyboardFocus == self
				ifTrue: [h newKeyboardFocus: otherMorph]]].
