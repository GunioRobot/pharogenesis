keyboardFocusChange: aBoolean
	| w |
	aBoolean
		ifTrue: ["A hand is wanting to send us characters..."
				self hasFocus ifFalse: [self installEditor]]
		ifFalse: ["A hand has clicked elsewhere..."
				w _ self world.
				(w notNil and: 
					[(w hands collect: [:h | h keyboardFocus]) includes: self])
					ifFalse: ["Release control unless some hand is still holding on"
							self releaseEditor]].
