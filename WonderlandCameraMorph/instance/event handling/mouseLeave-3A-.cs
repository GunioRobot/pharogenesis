mouseLeave: evt
	"When the mouse leaves our window release the keyboard focus"

	evt hand newKeyboardFocus: nil.

	mode = #paint ifTrue: [evt hand showTemporaryCursor: nil]
