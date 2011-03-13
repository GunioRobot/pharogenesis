menuButtonMouseDown: event
	"The menu button has been clicked."
	
	event hand showTemporaryCursor: nil.
	self use: menuSelector orMakeModelSelectorFor: 'MenuButtonPressed:'
		in: [:sel | menuSelector := sel.  model perform: sel with: event].
	Preferences gradientScrollbarLook ifFalse: [^self].
	self menuButtonMouseLeave: event