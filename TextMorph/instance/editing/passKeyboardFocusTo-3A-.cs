passKeyboardFocusTo: otherMorph
	| w |
	w _ self world.
	w notNil ifTrue: 
		[w hands do:
			[:h | h keyboardFocus == self
				ifTrue: [h newKeyboardFocus: otherMorph]]].
	"Release control unless some hand is still holding on"
	self releaseEditor.
